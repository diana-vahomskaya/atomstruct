using LibDrawingGraphs;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtomsDiffusion
{
    public partial class Form1 : Form
    {
        //Объект класса структуры
        Structure str;

        double CanvasZoom = 100;
        //Массивы энергий
        double[] kinEnergy, potEnergy, oPotEnergy, sumEnergy, masTimeEnergy;

        DrawingGraphs graphPot;
        DrawingGraphs graphKin, graphSum;

        Random RandShift, RandNumGen;
        public Form1()
        {
            InitializeComponent();
        }

        //Метод подсчёта количества атомов структуры в зависимости от её размера
        private void numUD_sizeCells_ValueChanged(object sender, EventArgs e)
        {
            int sizeStruct = (int)CubeCounter.Value;
            int numAtoms = Structure.TotalNumAtoms(sizeStruct);
            txt_numAtoms.Text = numAtoms.ToString();
        }

        private void btn_createStructure_Click(object sender, EventArgs e)
        {
            //Проверяем и очищаем файлы Excel 
            bool success0 = OutputInfo.ClearCoordAtomsFile();
            if (!success0)
                if (MessageBox.Show("Обнаружено открытие используемого файла Excel - данные не будут записаны. Продолжить выполнение?",
                    "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            bool success1 = OutputInfo.ClearFirstNeighboursdAtoms();
            if (!success1)
                if (MessageBox.Show("Обнаружено открытие используемого файла Excel - данные не будут записаны. Продолжить выполнение?",
                    "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            bool success2 = OutputInfo.ClearSecondNeighboursdAtoms();
            if (!success2)
                if (MessageBox.Show("Обнаружено открытие используемого файла Excel - данные не будут записаны. Продолжить выполнение?",
                    "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            bool success3 = OutputInfo.ClearCoordAtomsFileMathematica();
            if (!success3) if (MessageBox.Show("Обнаружено открытие используемого файла Excel - данные не будут записаны. Продолжить выполнение?",
                    "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            if (rdB_Ar.Checked)
            {
                str = new Structure((int)CubeCounter.Value, true, false, false);
            }
            if (rdB_Si.Checked)
            {
                str = new Structure((int)CubeCounter.Value, false, true, false);
            }
            if (rdB_Sn.Checked)
            {
                str = new Structure((int)CubeCounter.Value, false, false, true);
            }


            int sizeStruct = (int)CubeCounter.Value;
            int numAtoms = Structure.TotalNumAtoms(sizeStruct);
            for (int i = 0; i < numAtoms; i++)
            {
                OutputInfo.WriteCoordAtomFile(i + 1, Math.Round(str.Struct[i].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].Coordinate.z / str.StructLatPar, 3));

                OutputInfo.WriteCoordAtomFileMathematica(Math.Round(str.Struct[i].Coordinate.x / str.StructLatPar, 3),
                    Math.Round(str.Struct[i].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].Coordinate.z / str.StructLatPar, 3));

                OutputInfo.WriteFirstNeighboursdAtoms(i + 1,
                str.Struct[i].FirstNeighbours[0].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[0].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[0].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[0].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[1].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[1].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[1].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[1].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[2].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[2].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[2].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[2].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[3].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[3].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[3].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[3].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[4].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[4].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[4].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[4].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[5].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[5].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[5].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[5].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[6].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[6].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[6].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[6].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[7].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[7].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[7].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[7].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[8].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[8].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[8].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[8].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[9].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[9].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[9].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[9].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[10].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[10].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[10].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[10].Coordinate.z / str.StructLatPar, 3),
                str.Struct[i].FirstNeighbours[11].Index + 1, Math.Round(str.Struct[i].FirstNeighbours[11].Coordinate.x / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[11].Coordinate.y / str.StructLatPar, 3), Math.Round(str.Struct[i].FirstNeighbours[11].Coordinate.z / str.StructLatPar, 3));
                
                //OutputInfo.WriteSecondNeighboursdAtoms(i + 1,
                //str.Struct[i].SecondNeighbours[0].Index + 1, str.Struct[i].SecondNeighbours[0].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[0].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[0].Coordinate.z / str.StructLatPar,
                //str.Struct[i].SecondNeighbours[1].Index + 1, str.Struct[i].SecondNeighbours[1].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[1].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[1].Coordinate.z / str.StructLatPar,
                //str.Struct[i].SecondNeighbours[2].Index + 1, str.Struct[i].SecondNeighbours[2].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[2].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[2].Coordinate.z / str.StructLatPar,
                //str.Struct[i].SecondNeighbours[3].Index + 1, str.Struct[i].SecondNeighbours[3].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[3].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[3].Coordinate.z / str.StructLatPar,
                ///str.Struct[i].SecondNeighbours[4].Index + 1, str.Struct[i].SecondNeighbours[4].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[4].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[4].Coordinate.z / str.StructLatPar,
                //str.Struct[i].SecondNeighbours[5].Index + 1, str.Struct[i].SecondNeighbours[5].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[5].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[5].Coordinate.z / str.StructLatPar,
                ///str.Struct[i].SecondNeighbours[6].Index + 1, str.Struct[i].SecondNeighbours[6].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[6].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[6].Coordinate.z / str.StructLatPar,
                //str.Struct[i].SecondNeighbours[7].Index + 1, str.Struct[i].SecondNeighbours[7].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[7].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[7].Coordinate.z / str.StructLatPar,
                //str.Struct[i].SecondNeighbours[8].Index + 1, str.Struct[i].SecondNeighbours[8].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[8].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[8].Coordinate.z / str.StructLatPar,
                //str.Struct[i].SecondNeighbours[9].Index + 1, str.Struct[i].SecondNeighbours[9].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[9].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[9].Coordinate.z / str.StructLatPar,
                //str.Struct[i].SecondNeighbours[10].Index + 1, str.Struct[i].SecondNeighbours[10].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[10].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[10].Coordinate.z / str.StructLatPar,
                //str.Struct[i].SecondNeighbours[11].Index + 1, str.Struct[i].SecondNeighbours[11].Coordinate.x / str.StructLatPar, str.Struct[i].SecondNeighbours[11].Coordinate.y / str.StructLatPar, str.Struct[i].SecondNeighbours[11].Coordinate.z / str.StructLatPar);
            }
            

        }
        private void DrawGraph(int numStep, bool bTime)
        {
            string textAxisX;

            if (bTime)
            {
                textAxisX = "Шаг по времени";

                graphPot.AddGraph(potEnergy, masTimeEnergy, Color.DarkBlue);
                graphPot.DrawGraphs(textAxisX, "Энергия (эВ)", "График потенциальной энергии");
                pict_potEnergy.Image = graphPot.GetImage;

                double energy = Convert.ToDouble(txt_tmprEnergy.Text);
                graphKin.AddAxisX = true;
                graphKin.AddGraph(new double[] { energy, energy }, 0, masTimeEnergy.Max(), Color.Black);
                graphKin.AddGraph(kinEnergy, masTimeEnergy, Color.Red);
                graphKin.DrawGraphs(textAxisX, "Энергия (эВ)", "График кинетической энергии");
                pict_kinEnergy.Image = graphKin.GetImage;

                graphSum.AddAxisX = true;
                graphSum.AddGraph(sumEnergy, masTimeEnergy, Color.DarkGreen);
                graphSum.AddGraph(kinEnergy, masTimeEnergy, Color.Red);
                graphSum.AddGraph(oPotEnergy, masTimeEnergy, Color.DarkBlue);
                graphSum.DrawGraphs(textAxisX, "Энергия (эВ)", "График энергий");
                pict_3.Image = graphSum.GetImage;
            }
            else
            {
                textAxisX = "Номер шага по времени";

                graphPot.IntValueX = true;
                graphPot.AddGraph(potEnergy, 0, numStep, Color.DarkBlue);
                graphPot.DrawGraphs(textAxisX, "Энергия (эВ)", "График потенциальной энергии");
                pict_potEnergy.Image = graphPot.GetImage;
                graphPot.IntValueX = false;

                double energy = Convert.ToDouble(txt_tmprEnergy.Text);
                graphKin.IntValueX = true;
                graphKin.AddAxisX = true;
                graphKin.AddGraph(new double[] { energy, energy }, 0, numStep, Color.Black);
                graphKin.AddGraph(kinEnergy, 0, numStep, Color.Red);
                graphKin.DrawGraphs(textAxisX, "Энергия (эВ)", "График кинетической энергии");
                pict_kinEnergy.Image = graphKin.GetImage;
                graphKin.IntValueX = false;

                graphSum.IntValueX = true;
                graphSum.AddAxisX = true;
                graphSum.AddGraph(sumEnergy, 0, numStep, Color.DarkGreen);
                graphSum.AddGraph(kinEnergy, 0, numStep, Color.Red);
                graphSum.AddGraph(oPotEnergy, 0, numStep, Color.DarkBlue);
                graphSum.DrawGraphs(textAxisX, "Энергия (эВ)", "График энергий");
                pict_3.Image = graphSum.GetImage;
                graphSum.IntValueX = false;
            }
        }
        private void rdB_Ar_CheckedChanged(object sender, EventArgs e)
        {
            if(rdB_Ar.Checked)
            {
                textBox3.Text = Convert.ToString(AtomsParams.LATPAR_AR);
            }
        }

        private void rdB_Si_CheckedChanged(object sender, EventArgs e)
        {
            if (rdB_Si.Checked)
            {
                textBox3.Text = Convert.ToString(AtomsParams.LATPAR_SI);
            }
        }

        private void rdB_Sn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdB_Sn.Checked)
            {
                textBox3.Text = Convert.ToString(AtomsParams.LATPAR_SN);
            }
        }

        private void btn_calculateEnergy_Click(object sender, EventArgs e)
        {
            double energy = str.PotentialEnergy();
            txt_sumEnergy.Text = energy.ToString("f6");
            txt_atomEnergy.Text = (energy / str.StructNumAtoms).ToString("f6");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button_StartRelax_Click(object sender, EventArgs e)
        {
            //Определяем параметры
            int numStep = (int)numUD_numStepRelax.Value;
            double temperature = (double)numUD_tmpr.Value;
            double shift = (double)numUD_shiftAtoms.Value * AtomsParams.LATPAR_AR;
            int stepNorm = (int)numUD_stepNorm.Value;
            int stepDev = (int)numUD_step.Value;

            graphPot = new DrawingGraphs(pict_potEnergy.Width, pict_potEnergy.Height);
            graphKin = new DrawingGraphs(pict_kinEnergy.Width, pict_kinEnergy.Height);
            graphSum = new DrawingGraphs(pict_3.Width, pict_3.Height);


            RandShift = RandNumGen = new Random();

            Motion relax = new Motion(str);

            relax.Initialization(RandNumGen, RandShift, temperature, shift,
                    stepDev, (double)numUD_multStepRelax.Value, numStep, stepNorm);
  
            relax.CalculatedTime();
            
            
            //Проверяем и очищаем файлы Excel перед релаксацией
            bool success = OutputInfo.ClearEnergyFile();
            if (!success)
                if (MessageBox.Show("Обнаружено открытие используемого файла Excel - данные не будут записаны. Продолжить выполнение?",
                    "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            //Проводим релаксацию
            Task task = Task.Factory.StartNew(delegate { relax.Iterations(); }, TaskCreationOptions.LongRunning);

            FormConsole formConsole = new FormConsole(relax);
            formConsole.ShowDialog();

            
                btn_calculateEnergy_Click(null, null);


                //kinEnergy, potEnergy, oPotEnergy, sumEnergy, masTimeEnergy;
                kinEnergy = new double[relax.GetMasTimeStep.Length];
                potEnergy = new double[relax.GetMasTimeStep.Length];
                masTimeEnergy = new double[relax.GetMasTimeStep.Length];
                double[] time = new double[relax.GetMasTimeStep.Length];

                //Получаем энергию
                sumEnergy = new double[kinEnergy.Length];
                oPotEnergy = new double[kinEnergy.Length];
                for (int i = 0; i < kinEnergy.Length; i++)
                {
                    time[i] = relax.GetMasTimeStep[i];
                    kinEnergy[i] = relax.GetMasKinEnergy[i];
                    potEnergy[i] = relax.GetMasPotEnergy[i];
                    masTimeEnergy[i] = relax.GetMasTimeStep[i];

                    oPotEnergy[i] = potEnergy[i] - potEnergy[0];
                    sumEnergy[i] = oPotEnergy[i] + kinEnergy[i];
                }


                // DrawChart(chart_Ep, potEnergy, time);
                //Отрисовываем
                if (kinEnergy.Length >= 3) DrawGraph(kinEnergy.Length - 1, checkBox_timeRelax.Checked);


            this.Activate();

        }
    }
}
