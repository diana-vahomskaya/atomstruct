using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomsDiffusion
{
    public class Motion
    {
        Structure str;
        Atom[] atoms;
        Random rand, randShift;
        public TimeSpan ProcTime; //1 итерация/100 перестановок
        public double TimeIter, TimeSwap;


        double[] masTimeStep;
        double[] masKinEnergy, masPotEnergy;
        List<double> listKinEnergy, listPotEnergy, listTimeStep;
        // int[] timeDevStep;
        int timeDevStep;
        int[] halfSize;
        double[] kE;
        double[] pE;

        double temperature, timeRelax, valueStep, Ekravn, time;
        double shiftAtom;
        int numStep, step, normStep;
        bool removeRelax, tmprVeloc;

        string listText = string.Empty;
        public bool End = false, BREAK = false, corrFunc = false;


        public string GetListText
        {
            get { return listText; }
        }

        public int GetNumStep
        {
            get { return numStep; }
        }

        public int GetStep
        {
            get { return step; }
        }

        public double[] GetMasKinEnergy
        {
            get { return masKinEnergy; }
        }
        public double[] GetMasPotEnergy
        {
            get { return masPotEnergy; }
        }
        public double[] GetMasTimeStep
        {
            get { return masTimeStep; }
        }

        public Motion(Structure str)
        {
            this.str = str;
        }

        public void CalculatedTime()
        {
            atoms = new Atom[str.Struct.Length];
            for (int a = 0; a < str.Struct.Length; a++)
            {
                atoms[a] = new Atom(str.Struct[a].Coordinate, str.Struct[a].Type, str.Struct[a].Index);
                atoms[a].Coordinate = str.Struct[a].Coordinate;
                atoms[a].Velocity = str.Struct[a].Velocity;
                atoms[a].Type = str.Struct[a].Type;
                atoms[a].KinEnergy = str.Struct[a].KinEnergy;
                atoms[a].PotEnergy = str.Struct[a].PotEnergy;
            }

            if (shiftAtom != 0.0d)
                str.ShiftAtoms(shiftAtom, rand);
            if (tmprVeloc)
                str.TemperatureVelocity(temperature);

            double pot = 0.0d, kin = 0.0d;
            str.Energy(out pot, out kin);


            // Алгоритм Верле
            for (int x = 0; x < str.StructNumAtoms; x++)
                str.AlgorithmVerlet(ref str.Struct[x], valueStep);

            // Подсчёт энергии
            double kinEnergy = 0.0d, potEnergy = 0.0d;
            Task[] calcEnergy = new Task[8]
            {
                    new Task(delegate { str.Energy(out pE[0], out kE[0], halfSize[0], halfSize[1]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[1], out kE[1], halfSize[1], halfSize[2]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[2], out kE[2], halfSize[2], halfSize[3]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[3], out kE[3], halfSize[3], halfSize[4]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[4], out kE[4], halfSize[4], halfSize[5]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[5], out kE[5], halfSize[5], halfSize[6]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[6], out kE[6], halfSize[6], halfSize[7]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[7], out kE[7], halfSize[7], halfSize[8]); }, TaskCreationOptions.AttachedToParent)
            };

            for (int task = 0; task < calcEnergy.Length; task++)
                calcEnergy[task].Start();
            Task.WaitAll(calcEnergy);

            for (int e = 0; e < kE.Length; e++)
            {
                kinEnergy += kE[e];
                potEnergy += pE[e];
            }

            for (int t = 0; t < calcEnergy.Length; t++)
                calcEnergy[t].Dispose();

            DateTime endTimeIter = DateTime.Now;

            for (int a = 0; a < str.Struct.Length; a++)
            {
                str.Struct[a].Coordinate = atoms[a].Coordinate;
                str.Struct[a].Velocity = atoms[a].Velocity;
                str.Struct[a].Type = atoms[a].Type;
                str.Struct[a].KinEnergy = atoms[a].KinEnergy;
                str.Struct[a].PotEnergy = atoms[a].PotEnergy;
            };

        }

        public void Initialization(Random randSwap, Random randShift, double temperature, double shiftAtom, 
            int timeDevStep, double modStep, int numStep, int normStep)
        {
            this.rand = randSwap;
            this.randShift = randShift;
            this.temperature = temperature;
            this.numStep = numStep;
            this.normStep = normStep;
            this.timeDevStep = timeDevStep;
            this.shiftAtom = shiftAtom;


            time = AtomsParams.PERIOD_OSCILL;// 1.018e-13 //расчёт по формуле
            valueStep = modStep * time;// Чем выше температура, тем меньше шаг!

            Ekravn = Structure.TemperatureEnergy(temperature, str.StructNumAtoms);

            listKinEnergy = new List<double>();
            listPotEnergy = new List<double>();
            listTimeStep = new List<double>();

            timeRelax = 0;


            // разбиение индексов атомов, для передачи их в потоковые методы
            int half = str.StructNumAtoms / 8;
            halfSize = new int[9] { 0, half, half * 2, half * 3, half * 4, half * 5, half * 6, half * 7, str.StructNumAtoms };
            kE = new double[8];
            pE = new double[8];
        }

        public void Iterations()
        {
            listText = "[Запуск моделирования]" + Environment.NewLine + Environment.NewLine;

            // начальное условие: либо сдвиг по координате, либо задание скорости
            if (shiftAtom != 0)
                str.ShiftAtoms(shiftAtom, randShift);
            if (tmprVeloc)
                str.TemperatureVelocity(temperature);

            // подсчёт начальной энергии
            double pot = 0, kin = 0;
            str.Energy(out pot, out kin);
            listKinEnergy.Add(kin);
            listPotEnergy.Add(pot);
            listTimeStep.Add(0);
            listText += Structure.OutputConsole(0, 0, 0, 0, kin, pot, 0, pot);

            for (step = 1; step <= numStep; step++)
            {
                if (BREAK) break;

                for (int s = 0; s < numStep; s += timeDevStep)
                    if (step == timeDevStep + s) valueStep /= 2;

                // Алгоритм Верле
                for (int x = 0; x < str.StructNumAtoms; x++)
                    str.AlgorithmVerlet(ref str.Struct[x], valueStep);

                // Подсчёт энергии
                double kinEnergy = 0, potEnergy = 0;
                Task[] calcEnergy = new Task[8]
                {
                    new Task(delegate { str.Energy(out pE[0], out kE[0], halfSize[0], halfSize[1]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[1], out kE[1], halfSize[1], halfSize[2]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[2], out kE[2], halfSize[2], halfSize[3]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[3], out kE[3], halfSize[3], halfSize[4]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[4], out kE[4], halfSize[4], halfSize[5]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[5], out kE[5], halfSize[5], halfSize[6]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[6], out kE[6], halfSize[6], halfSize[7]); }, TaskCreationOptions.AttachedToParent),
                    new Task(delegate { str.Energy(out pE[7], out kE[7], halfSize[7], halfSize[8]); }, TaskCreationOptions.AttachedToParent)
                };

                for (int task = 0; task < calcEnergy.Length; task++)
                    calcEnergy[task].Start();
                Task.WaitAll(calcEnergy);

                for (int e = 0; e < kE.Length; e++)
                {
                    kinEnergy += kE[e];
                    potEnergy += pE[e];
                }

                for (int t = 0; t < calcEnergy.Length; t++)
                    calcEnergy[t].Dispose();

                double E1 = listKinEnergy[step - 1] + listPotEnergy[step - 1];
                double E2 = kinEnergy + potEnergy;
                double deltaEnergy = E2 - E1;

                double changeKineticEnergy = kinEnergy - listKinEnergy[step - 1];
                double changePotentialEnergy = potEnergy - listPotEnergy[step - 1];

                timeRelax += valueStep / time;

                listKinEnergy.Add(kinEnergy);
                listPotEnergy.Add(potEnergy);
                listTimeStep.Add(timeRelax);

                listText += Structure.OutputConsole(step, timeRelax, changeKineticEnergy, changePotentialEnergy, kinEnergy, potEnergy, deltaEnergy, pot);

                // Нормировка скоростей
                if (normStep != 0 && step % normStep == 0)
                {
                    double beta = Math.Sqrt(Ekravn / kinEnergy);
                    if (temperature == 0) beta = 0.5;
                    str.NormalizeVelocity(beta);
                }


            }

            // записываем в массивы энергию и шаг по времени
            masKinEnergy = listKinEnergy.ToArray();
            masPotEnergy = listPotEnergy.ToArray();
            masTimeStep = listTimeStep.ToArray();

            // сброс структуры
            if (removeRelax)
            {
                for (int a = 0; a < str.Struct.Length; a++)
                {
                    str.Struct[a].Coordinate = atoms[a].Coordinate;
                    str.Struct[a].Velocity = atoms[a].Velocity;
                    str.Struct[a].Type = atoms[a].Type;
                    str.Struct[a].KinEnergy = atoms[a].KinEnergy;
                    str.Struct[a].PotEnergy = atoms[a].PotEnergy;
                }
            }

            // обязательное поле, для закрытия окна информации
            End = true;
        }
    }
    partial class Structure
    {
        /// <summary>
        /// Вывод информации о релаксации и запись в Excel
        /// </summary>
        /// <param name="step">Номер шага по времени</param>
        /// <param name="timeStep">Шаг по времени</param>
        /// <param name="changeKinEnergy">Изменение кинетической энергии</param>
        /// <param name="changePotEnergy">Изменение потенциальной энергии</param>
        /// <param name="kinEnergy">Кинетическая энергия</param>
        /// <param name="potEnergy">Потенциальная энергия</param>
        /// <param name="deltaEnergy">Разница между полными энергиями</param>
        /// <param name="startPotEnergy">Начальная потенциальная энергия</param>
        public static string OutputConsole(int step, double timeStep, double changeKinEnergy, double changePotEnergy,
    double kinEnergy, double potEnergy, double deltaEnergy, double startPotEnergy)
        {
            // выравнивание столбцов энергий
            string ep = String.Format("  Ep = {0:f6} эВ", potEnergy);
            string ek = String.Format("  Ek = {0:f6} эВ", kinEnergy);
            if (ek.Length < ep.Length)
            {
                ek = ek.PadRight(ep.Length, ' ');
            }
            else if (ek.Length > ep.Length)
            {
                ep = ep.PadRight(ek.Length, ' ');
            }

            string text = String.Format("Шаг №{0}:" + Environment.NewLine, step);
            text += String.Format("{0}\tdEp = {1:E} эВ" + Environment.NewLine,
                ep, changePotEnergy);
            text += String.Format("{0}\tdEk = {1:E} эВ" + Environment.NewLine,
                ek, changeKinEnergy);
            text += String.Format("  E2 - E1 = {0:f6} эВ" + Environment.NewLine + Environment.NewLine,
                deltaEnergy);


            //OutputInfo.WriteEnergyFile(step, timeStep, kinEnergy, potEnergy, startPotEnergy);

            return text;
        }

        /// <summary>
        /// Формула трёхточечного дифференцирования для расчёта производной потенциальной энергии.
        /// </summary>
        /// <param name="selAtom">Выбранный атом.</param>
        /// <param name="delta">Смещение.</param>
        /// <returns></returns>
        private double ThreePointDifferentiation(Atom selAtom, bool x, bool y, bool z)
        {
            double L = this.StructLength * this.StructLatPar;
            Vector coord = selAtom.Coordinate;
            double forceaa = 0.0;

            forceaa = selAtom.ForceAtom(this.SelPotential, L, x, y, z);

            selAtom.Coordinate = coord;

            return forceaa; // эВ
        }

        /// <summary>
        /// Сила, действующая на выбранный атом.
        /// </summary>
        /// <param name="selAtom">Выбранный атом.</param>
        /// <returns></returns>
        private Vector Force(Atom selAtom)
        {
            Vector force = new Vector();

            Atom a1 = (Atom)selAtom.Clone();
            Atom a2 = (Atom)selAtom.Clone();

            Task[] tasks = new Task[3]
            {
                new Task(delegate{force.x = -ThreePointDifferentiation(a1, true, false, false); }, TaskCreationOptions.AttachedToParent),
                new Task(delegate{force.y = -ThreePointDifferentiation(a2,  false, true, false); }, TaskCreationOptions.AttachedToParent),
                new Task(delegate{force.z = -ThreePointDifferentiation(selAtom, false, false, true); }, TaskCreationOptions.AttachedToParent)
            };
            for (int t = 0; t < tasks.Length; t++)
                tasks[t].Start();
            Task.WaitAll(tasks);

            for (int t = 0; t < tasks.Length; t++)
                tasks[t].Dispose();

            // Перевод из эВ в Дж с нм (Дж'), т.е Дж' = (кг * нм^2 / с^2).
            // А всё из-за того, что скорость измеряется в нм/c, а не в м/с!
            const double elecVoltToJoule = 0.1602176634d;
            return force * elecVoltToJoule;
        }

        /// <summary>
        /// Случайный сдвиг атомов в структуре.
        /// </summary>
        /// <param name="shift">Значение сдвига (нм).</param>
        /// <param name="rand">Генератор случайных чисел.</param>
        public void ShiftAtoms(double shift, Random rand)
        {
            if (shift == 0) return;

            double L = this.StructLength * this.StructLatPar;

            for (int a = 0; a < this.StructNumAtoms; a++)
            {
                Vector coord = this.Struct[a].Coordinate + new Vector(rand.Next(-1, 1) * shift, rand.Next(-1, 1) * shift, rand.Next(-1, 1) * shift);
                this.Struct[a].SetCoordinate(coord, L);
            }
        }
        /// <summary>
        /// Нормировка скоростей атомов структуры.
        /// </summary>
        /// <param name="beta">Коэффициент нормировки.</param>
        public void NormalizeVelocity(double beta)
        {
            for (int a = 0; a < this.StructNumAtoms; a++)
            {
                this.Struct[a].Velocity *= beta;
            }
        }

        /// <summary>
        /// Определение начальных скоростей атомов, пропорциональных заданной температуре (НЕКОРРЕКТНО РАБОТАЕТ!)
        /// </summary>
        /// <param name="temperature">Температура</param>
        public void TemperatureVelocity(double temperature)
        {
            double Ek = (3.0 / 2.0) * 8.6142e-5 * temperature / 6.24e+18;
            double mass = (AtomsParams.MASS_SI + AtomsParams.MASS_AR) / 2.0;
            double Vmax = Math.Sqrt(Ek / mass);
            Vmax *= 0.68e+9;

            for (int a = 0; a < this.StructNumAtoms; a++)
            {
                double x = Vmax;
                double y = Vmax;
                double z = Vmax;

                this.Struct[a].Velocity = new Vector(x, y, z);
            }
        }

        /// <summary>
        /// Алгоритм Верле.
        /// </summary>
        /// <param name="selAtom">Выбранный атом.</param>
        /// <param name="stepTime">Шаг по времени.</param>
        public void AlgorithmVerlet(ref Atom selAtom, double stepTime)
        {
            Vector speedup = Force(selAtom);// An(м/с^2)
            Vector coordinate = (selAtom.Coordinate) + (selAtom.Velocity * stepTime) + (speedup * Math.Pow(stepTime, 2) / (2.0 * selAtom.Mass));// нм

            double L = this.StructLength * this.StructLatPar;
            selAtom.SetCoordinate(coordinate, L);

            speedup += Force(selAtom);// An+1

            Vector velocity = selAtom.Velocity + (speedup * stepTime / (2.0 * selAtom.Mass));
            selAtom.Velocity = velocity;// нм/с
        }


    }
}
