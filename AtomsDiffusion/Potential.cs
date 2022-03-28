using System;

namespace AtomsDiffusion
{
    /// <summary>
    /// Потенциал взаимодействия.
    /// </summary>
    public abstract class Potential
    {
        public abstract double PotentialEnergy(Atom selAtom, double lengthSystem, bool force = false);
        public abstract double ForceAtom(Atom selAtom, double lengthSystem, bool x, bool y, bool z);
    }

    public class PotentialLennard : Potential
    {

        /// <summary>
        /// Параметры потенциала Леннарда - Джонса.
        /// </summary>
        private struct ParamPotential
        {
            public double D /* модуль потенциальной энергии взаимодейтсвия между атомами при равновесии*/, a /*сигма*/, r;
            public ParamPotential(double D, double a, double r)
            {
                this.D = D;//эпсилон
                this.a = a;//сигма
                this.r = r;
            }
        }
        /// <summary>
        /// Кубическая кристаллическая решётка.
        /// </summary>
        public readonly Atom[] Struct;
        /// <summary>
        /// Параметры для различных соединений атомов.
        /// </summary>
        private ParamPotential paramOfAr, paramOfSi, paramOfSn;
        public PotentialLennard(double latParAR, double latParSI, double latParGE, double latStruct)
        {
            double ar = 0.3314;
            double si = 0.2095;
            double sn = 0.2492;
            //latParSn * Math.Sqrt(3) / (4 * Math.Pow(2, 1 / 6.0));
            double r_ar = 0.5260d;
            double r_si = 0.54307d;
            double r_sn = 0.6489d;

            paramOfAr = new ParamPotential(0.0103, ar, r_ar); 
            paramOfSi = new ParamPotential(2.17, si, r_si);
            paramOfSn = new ParamPotential(1.56, sn, r_sn);
        }

        /// <summary>
        /// Потенциал Леннарда - Джонса
        /// </summary>
        /// <param name="potential">Параметры потенциала.</param>
        /// <param name="radius">Расстояние до атома-соседа.</param>
        /// <returns></returns>
        private double PE_FunctionCutoff(ParamPotential potential, double radius)
        {
            return  4.0 * potential.D * (Math.Pow(potential.a / radius, 12) - Math.Pow(potential.a / radius, 6));
        }

        private double Force_FuncCutOff(ParamPotential potential, double radius, double delta)
        {
            return -12.0 * potential.D * Math.Pow(potential.r, 6) * (Math.Pow(potential.r / radius, 6) - 1.0) * (delta / Math.Pow(radius, 8));
        }

        private double dxyz(double sel1, double sel2)
        {
            return sel1 - sel2;
        }

        /// <summary>
        /// Потенциальная энергия выбранного атома.
        /// </summary>
        /// <param name="sel">Выбранный атом.</param>
        /// <param name="lengthSystem">Размер кубической расчётной ячейки.</param>
        /// <param name="force">Расчёт энергии взаимодействия выбранного атома.</param>
        /// <returns></returns>
        public override double PotentialEnergy(Atom sel, double lengthSystem, bool force = false)
        {
            double atomEnergyDuo = 0.0;

            for (int j = 0; j < sel.Neighbours.Length; j++)
            {
                double Rij = Vector.MagnitudePeriod(sel.Coordinate, sel.Neighbours[j].Coordinate, lengthSystem);

                ParamPotential potentialIJ = paramOfSi;
                if (sel.Type == AtomType.Ar && sel.Type == AtomType.Ar) potentialIJ = paramOfAr;
                if (sel.Type == AtomType.Si && sel.Type == AtomType.Si) potentialIJ = paramOfSi;
                if (sel.Type == AtomType.Sn && sel.Type == AtomType.Sn) potentialIJ = paramOfSn;

                atomEnergyDuo += PE_FunctionCutoff(potentialIJ, Rij);
            }

            double atomEnergy = 0.0;
            atomEnergy = atomEnergyDuo/2;

            return atomEnergy;
        }

        public override double ForceAtom(Atom sel, double lengthSystem, bool x, bool y, bool z)
        {
            double force = 0.0;

            for( int j = 0; j < sel.Neighbours.Length; j++)
            {
                double Rijk = Vector.MagnitudePeriod(sel.Coordinate, sel.Neighbours[j].Coordinate, lengthSystem);

                ParamPotential potentialIJ = paramOfSi;
                if (sel.Type == AtomType.Ar && sel.Type == AtomType.Ar) potentialIJ = paramOfAr;
                if (sel.Type == AtomType.Si && sel.Type == AtomType.Si) potentialIJ = paramOfSi;
                if (sel.Type == AtomType.Sn && sel.Type == AtomType.Sn) potentialIJ = paramOfSn;
                double delta = 0.0;

                if (x == true)
                {
                    delta = dxyz(sel.Coordinate.x, sel.Neighbours[j].Coordinate.x);
                    force += Force_FuncCutOff(potentialIJ, Rijk, delta);
                }
                else if( y == true)
                {
                    delta = dxyz(sel.Coordinate.y, sel.Neighbours[j].Coordinate.y);
                    force += Force_FuncCutOff(potentialIJ, Rijk, delta);
                }
                else if( z == true)
                {
                    delta = dxyz(sel.Coordinate.z, sel.Neighbours[j].Coordinate.z);
                    force += Force_FuncCutOff(potentialIJ, Rijk, delta);
                }

            }
            return force;
        }
    }
}
