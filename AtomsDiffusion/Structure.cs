using System;
using System.Threading.Tasks;

namespace AtomsDiffusion
{
    public partial class Structure 
    {
        /// <summary>
        /// Потенциал Стиллинджера-Вебера.
        /// </summary>
        private PotentialLennard pLennard;

        /// <summary>
        /// Кубическая кристаллическая решётка.
        /// </summary>
        public readonly Atom[] Struct;

        /// <summary>
        /// Количество атомов в элементарной атомной ячейке.
        /// </summary>
        public const int NumberAtoms = 4;

        /// <summary>
        /// Выбранный потенциал.
        /// </summary>
        public Potential SelPotential
        {
            private set { selPotential = value; }
            get { return selPotential; }
        }
        private Potential selPotential;

        /// <summary>
        /// Количество атомов в структуре.
        /// </summary>
        public readonly int StructNumAtoms;

        /// <summary>
        /// Размер структуры.
        /// </summary>
        public readonly int StructLength;

        /// <summary>
        /// Параметр решётки структуры.
        /// </summary>
        public readonly double StructLatPar;

        /// <summary>
        /// Создание кубической структуры.
        /// </summary>
        /// <param name="length">Размер структуры.</param>
        public Structure(int length, bool Ar, bool Si, bool Sn)
        {
            // Задание параметров.
            this.StructLength = (length);
            this.StructNumAtoms = TotalNumAtoms(this.StructLength);
            this.StructLatPar = AtomLatticeParam(Ar, Si, Sn);
            this.Struct = new Atom[this.StructNumAtoms];

            this.pLennard = new PotentialLennard(AtomsParams.LATPAR_AR, AtomsParams.LATPAR_SI, AtomsParams.LATPAR_SN, this.StructLatPar);
            this.SetPotential();

            AtomType setType = AtomType.Ar;
            if (Si == true)
            {
                setType = AtomType.Si;
            }
            if (Sn == true)
            {
                setType = AtomType.Sn;
            }

            // Размещение атомов.
            int atomIdx = -1;
            for (int x = 0; x < (this.StructLength); ++x)
                for (int y = 0; y < (this.StructLength); ++y)
                    for (int z = 0; z < (this.StructLength); ++z)
                    {
                        double koeff = this.StructLatPar / 2 ;

                        Vector posCell = new Vector(x, y, z) * this.StructLatPar;

                        this.Struct[++atomIdx] = new Atom(posCell, setType, atomIdx);
                        this.Struct[++atomIdx] = new Atom(new Vector(0, 1, 1) * koeff + posCell, setType, atomIdx);
                        this.Struct[++atomIdx] = new Atom(new Vector(1, 0, 1) * koeff + posCell, setType, atomIdx);
                        this.Struct[++atomIdx] = new Atom(new Vector(1, 1, 0) * koeff + posCell, setType, atomIdx);
                    }

            this.SearchNeighbours();
        }

        /// <summary>
        /// Количество атомов в структуре.
        /// </summary>
        /// <param name="length">Размер структуры.</param>
        /// <returns></returns>
        public static int TotalNumAtoms(int length)
        {
            return (length) * (length) * (length) * NumberAtoms;
        }

        /// <summary>
        /// Потенциал взаимодействия.
        /// </summary>
        public void SetPotential()
        {
            this.SelPotential = pLennard;
        }
        /// <summary>
        /// Параметр решётки структуры.
        /// </summary>
        /// <returns></returns>
        public static double AtomLatticeParam(bool Ar, bool Si, bool Sn)
        {
            double Param = 0;
            if (Ar == true && Si == false && Sn == false)
            {
                Param = AtomsParams.LATPAR_AR;
            }
            if (Ar == false && Si == true && Sn == false)
            {
                Param = AtomsParams.LATPAR_SI;
            }
            if (Ar == false && Si == false && Sn == true)
            {
                Param = AtomsParams.LATPAR_SN;
            }
            return Param;
        }

        /// <summary>
        /// Поиск соседей у всех атомов структуры.
        /// </summary>
        public void SearchNeighbours()
        {
            double L = this.StructLength * this.StructLatPar;
            //double radiusOfNeighbours = new Vector(this.StructLatPar * 0.5d, this.StructLatPar * 0.5d, this.StructLatPar * 0.5d).Magnitude();
            double radiusOfNeighbours = Math.Sqrt(2) * this.StructLatPar / 2;

            for (int i = 0; i < this.StructNumAtoms; i++)
            {
                this.Struct[i].SearchFirstNeighbours(this.Struct, L, radiusOfNeighbours);
                this.Struct[i].SumNeighbours();
            }

            for (int j = 0; j < this.StructNumAtoms; j++)
            {
                this.Struct[j].SearchSecondNeighbours();
                this.Struct[j].SumNeighbours();
            }
        }

        /// <summary>
        /// Энергия равновесного состояния (эВ).
        /// </summary>
        /// <param name="temperature">Температура (в Кельвинах).</param>
        /// <param name="numAtoms">Количество атомов структуры.</param>
        /// <returns></returns>
        public static double TemperatureEnergy(double temperature, int numAtoms)
        {
            return (3.0d / 2.0d) * AtomsParams.BOLTZMANN * numAtoms * temperature;
        }

        /// <summary>
        /// Подсчёт потенциальной и кинетической энергии части структуры.
        /// </summary>
        /// <param name="potEnergy">Потенциальная энергия.</param>
        /// <param name="kinEnergy">Кинетическая энергия.</param>
        /// <param name="startIdx">Начальный индекс атома.</param>
        /// <param name="endIdx">Конечный индекс атома.</param>
        public void Energy(out double potEnergy, out double kinEnergy, int startIdx, int endIdx)
        {
            potEnergy = 0.0d;
            kinEnergy = 0.0d;
            double L = this.StructLength * this.StructLatPar;

            for (int i = startIdx; i < endIdx; i++)
            {
                this.Struct[i].PotentialEnergy(this.SelPotential, L, false);

                potEnergy += this.Struct[i].PotEnergy;
                kinEnergy += this.Struct[i].KineticEnergy();
            }
        }
        /// <summary>
        /// Подсчёт полной потенциальной энергии системы.
        /// </summary>
        /// <returns></returns>
        public double PotentialEnergy()
        {
            double sumEnergy = 0.0d;
            double L = this.StructLength * this.StructLatPar;

            for (int i = 0; i < this.StructNumAtoms; i++)
            {
                this.Struct[i].PotentialEnergy( this.SelPotential, L, false);

                sumEnergy += this.Struct[i].PotEnergy;
            }

            return sumEnergy;
        }
        /// <summary>
        /// Суммирование подсчитанной потенциальной энергии атомов структуры.
        /// </summary>
        /// <returns></returns>
        public double SumPotentialEnergy()
        {
            double potEnergy = 0.0d;

            for (int i = 0; i < this.StructNumAtoms; i++)
                potEnergy += this.Struct[i].PotEnergy;

            return potEnergy;
        }
        /// <summary>
        /// Подсчёт потенциальной и кинетической энергии.
        /// </summary>
        /// <param name="potEnergy">Потенциальная энергия.</param>
        /// <param name="kinEnergy">Кинетическая энергия.</param>
        public void Energy(out double potEnergy, out double kinEnergy)
        {
            potEnergy = 0.0d;
            kinEnergy = 0.0d;
            double L = this.StructLength * this.StructLatPar;

            for (int i = 0; i < this.StructNumAtoms; i++)// Перебор атомов в ячейке
            {
                this.Struct[i].PotentialEnergy(this.SelPotential, L, false);

                potEnergy += this.Struct[i].PotEnergy;
                kinEnergy += this.Struct[i].KineticEnergy();
            }
        }

    }
}
