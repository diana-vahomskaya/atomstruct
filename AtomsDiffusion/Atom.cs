using System;
using System.Collections.Generic;

namespace AtomsDiffusion
{ //Выбор типа атома
    public enum AtomType
    {
        Ar,
        Si,
        Sn
    }

    //Параметры атомов
    public class AtomsParams
    {
        /// <summary>
        /// Перевод атомной единицы массы (а.е.м.) в килограмм (кг).
        /// </summary>
        public const double AtomicMassUnitToKg = 1.66054e-27;

        /// <summary>
        /// Масса атома аргона (кг).
        /// </summary>
        public const double MASS_AR = 39.948d * AtomicMassUnitToKg;

        /// <summary>
        /// Масса атома кремния (кг).
        /// </summary>
        public const double MASS_SI = 28.085d * AtomicMassUnitToKg;

        /// <summary>
        /// Масса атома олова (кг).
        /// </summary>
        public const double MASS_SN = 118.710d * AtomicMassUnitToKg;

        /// <summary>
        /// Параметр решётки атома  аргона(нм).
        /// </summary>
        public const double LATPAR_AR = 0.5260d;

        /// <summary>
        /// Параметр решётки атома кремния (нм).
        /// </summary>
        public const double LATPAR_SI = 0.54307d;

        /// <summary>
        /// Параметр решётки атома олова (нм).
        /// </summary>
        public const double LATPAR_SN = 0.6489d;

        /// <summary>
        /// Постоянная Больцмана (эВ/К).
        /// </summary>
        public const double BOLTZMANN = 8.6142e-5;

        /// <summary>
        /// Период оптических колебаний атомов в решётке сплава (сек).
        /// </summary>
        public const double PERIOD_OSCILL = 1.018e-13;
    }
    public class Atom : ICloneable
    {
        /// <summary>
        /// Координата атома (нм);
        /// для передачи значения с использованием периодических граничных условий вызвать <see cref="Atom.SetCoordinate(Vector, double)"/>.
        /// </summary>
        public Vector Coordinate
        {
            set { _coordinate = value; }
            get { return _coordinate; }
        }
        private Vector _coordinate;

        /// <summary>
        /// Скорость атома (нм/с).
        /// </summary>
        public Vector Velocity
        {
            set
            {
                _velocity = value;
            }
            get { return _velocity; }
        }
        private Vector _velocity;

        /// <summary>
        /// Масса атома (кг), изменяется вместе с типом атома <see cref="Atom.Type"/>.
        /// </summary>
        public double Mass
        {
            get { return _mass; }
            private set { _mass = value; }
        }
        private double _mass;

        /// <summary>
        /// Тип атома.
        /// </summary>
        public AtomType Type
        {
            set
            {
                _type = value;
                if (_type == AtomType.Ar)
                {
                    this.Mass = AtomsParams.MASS_AR;
                }
                if (_type == AtomType.Si)
                {
                    this.Mass = AtomsParams.MASS_SI;
                }
                if (_type == AtomType.Sn)
                {
                    this.Mass = AtomsParams.MASS_SN;
                }
            }
            get { return _type; }
        }
        private AtomType _type;

        /// <summary>
        /// Индекс атома.
        /// </summary>
        public int Index
        {
            get { return _index; }
            private set { _index = value; }
        }
        private int _index;

        /// <summary>
        /// Первые и вторые соседи атома (<see cref="Atom.FirstNeighbours"/> и <see cref="Atom.SecondNeighbours"/>).
        /// </summary>
        public Atom[] Neighbours
        {
            private set { _neighbours = value; }
            get { return _neighbours; }
        }
        private Atom[] _neighbours;

        /// <summary>
        /// Потенциальная энергия атома (эВ), вычисляется в методе <see cref="PotentialEnergy(Potential, double, bool)"/> при bool = false.
        /// </summary>
        public double PotEnergy;


        public double EnergyAtomDuo;

        public double EnergyAtomTrio;
        /// <summary>
        /// Кинетическая энергия атома (эВ), вычисляется в методе <see cref="KineticEnergy"/>.
        /// </summary>
        public double KinEnergy;

        /// <summary>
        /// Первые соседи атома.
        /// </summary>
        public readonly List<Atom> FirstNeighbours = new List<Atom>();

        /// <summary>
        /// Вторые соседи атома.
        /// </summary>
        public readonly List<Atom> SecondNeighbours = new List<Atom>();

        /// <summary>
        /// Cоздание атома.
        /// </summary>
        /// <param name="coord">Координата атома.</param>
        /// <param name="type">Тип атома.</param>
        /// <param name="idx">Индекс атома в системе.</param>
        public Atom(Vector coord, AtomType type, int idx)
        {
            this.Coordinate = coord;
            this.Velocity = Vector.Zero;
            this.Type = type;
            this.Index = idx;
        }

        /// <summary>
        /// Клонировать объект с сохранением ссылочных переменных.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Кинетическая энергия атома (эВ).
        /// </summary>
        /// <returns>Кинетическая энергия.</returns>
        public double KineticEnergy()
        {
            double sum = 0.0d;

            sum += Math.Pow(Velocity.x, 2);
            sum += Math.Pow(Velocity.y, 2);
            sum += Math.Pow(Velocity.z, 2);

            // Энергия в (эВ).
            // Без 1e+18, т.к. скорость в нм => при вычислении 1e-18 и 1e+18 сократятся.
            const double jouleToElecVolt = 6.24151d;
            double energy = sum * this.Mass * jouleToElecVolt / 2.0d;
            this.KinEnergy = energy;

            return energy;
        }

        /// <summary>
        /// Поиск первых соседей выбранного атома.
        /// </summary>
        /// <param name="sys">Система атомов в которой находится выбранный атом.</param>
        /// <param name="L">Размер кубической расчётной ячейки.</param>
        /// <param name="searchRadius">Радиус поиска соседей.</param>
        public void SearchFirstNeighbours(Atom[] sys, double L, double searchRadius)
        {
            this.FirstNeighbours.Clear();

            for (int a = 0; a < sys.Length; a++)
            {
                if (sys[a].Index == this.Index) continue;

                double radius = Vector.MagnitudePeriod(this.Coordinate, sys[a].Coordinate, L);
                radius = Math.Round(radius, 4);
                searchRadius = Math.Round(searchRadius, 4);
                if (radius <= searchRadius)
                {
                    this.FirstNeighbours.Add(sys[a]);
                }
            }
        }

        /// <summary>
        /// Подсчёт потенцальной энергии выбранного атома.
        /// </summary>
        /// <param name="pot">Тип потенциала.</param>
        /// <param name="L">Размер кубической расчётной ячейки.</param>
        /// <param name="impact">Подсчёт энергии взаимодействия (для расчёта силы).</param>
        /// <returns></returns>
        public double PotentialEnergy(Potential pot, double L, bool impact)
        {
            double energy = pot.PotentialEnergy(this, L, impact);
            if (!impact) this.PotEnergy = energy;

            return energy;
        }

        /// <summary>
        /// Подсчёт потенцальной энергии выбранного атома.
        /// </summary>
        /// <param name="pot">Тип потенциала.</param>
        /// <param name="L">Размер кубической расчётной ячейки.</param>
        /// <param name="impact">Подсчёт энергии взаимодействия (для расчёта силы).</param>
        /// <returns></returns>
        public double ForceAtom(Potential pot, double L, bool x, bool y, bool z)
        {
            double force = 0.0;
            force = pot.ForceAtom(this, L, x, y, z);

            return force;
        }

        /// <summary>
        /// Присваивание нового значения координаты атома с использованием периодических граничных условий.
        /// </summary>
        /// <param name="coord">Новая координата.</param>
        /// <param name="L">Размер кубической расчётной ячейки.</param>
        public void SetCoordinate(Vector coord, double L)
        {
            Vector newCoordinate = Vector.Zero;

            if (coord.x > L) newCoordinate.x = coord.x - L;
            else if (coord.x < 0.0d) newCoordinate.x = L + coord.x;
            else newCoordinate.x = coord.x;

            if (coord.y > L) newCoordinate.y = coord.y - L;
            else if (coord.y < 0.0d) newCoordinate.y = L + coord.y;
            else newCoordinate.y = coord.y;

            if (coord.z > L) newCoordinate.z = coord.z - L;
            else if (coord.z < 0.0d) newCoordinate.z = L + coord.z;
            else newCoordinate.z = coord.z;

            this.Coordinate = newCoordinate;
        }

        /// <summary>
        /// Поиск вторых соседей выбранного атома.
        /// </summary>
        public void SearchSecondNeighbours()
        {
            this.SecondNeighbours.Clear();

            for (int a = 0; a < this.FirstNeighbours.Count; a++)
            {
                Atom firstNeigh = this.FirstNeighbours[a];

                for (int n = 0; n < firstNeigh.FirstNeighbours.Count; n++)
                {
                    if (firstNeigh.FirstNeighbours[n].Index == this.Index) continue;

                    if (!this.SecondNeighbours.Contains(firstNeigh.FirstNeighbours[n]))
                    {
                        this.SecondNeighbours.Add(firstNeigh.FirstNeighbours[n]);
                    }
                }
            }
        }

        /// <summary>
        /// Вычисление первых и вторых соседей атома.
        /// </summary>
        public void SumNeighbours()
        {
            List<Atom> neigh = new List<Atom>(this.FirstNeighbours);
            neigh.AddRange(this.SecondNeighbours);
            this.Neighbours = neigh.ToArray();
        }
    }
}
