using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AtomsDiffusion
{
    public static class OutputInfo
    {
        private static string dirData = Environment.CurrentDirectory + "\\";
        private static string pathCordAtoms = dirData + "PositionsAtoms.csv";
        private static string pathCordAtomsMathematica = dirData + "PositionsAtomsMathematica.txt";
        private static string pathFirstNeighboursdAtoms = dirData + "FirstNeighbours.csv";
        private static string pathSecondNeighboursdAtoms = dirData + "SecondNeighbours.csv";
        private static string pathEnergy = dirData + "Energy.csv";

        /// <summary>
        /// Проверяет наличие каталогов
        /// </summary>
        public static void Start()
        {
            DirectoryInfo diData = new DirectoryInfo(dirData);
            if (diData.Exists) return;
            else diData.Create();
        }

        /// <summary>
        /// Записать координаты атомов в файл
        /// </summary>
        /// <param name="index">Индекс атома</param>
        /// <param name="x">Координата атома по Х</param>
        /// <param name="y">Координата атома по Y</param>
        /// <param name="z">Координата атома по Z</param>
        public static bool WriteCoordAtomFile(int index, double x, double y, double z)
        {
            string path;
            path = pathCordAtoms;

            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
            {
                sw.WriteLine("{0};{1};{2};{3};", index, x, y, z);
            }
            return true;
        }
        /// <summary>
        /// Записать координаты атомов в файл
        /// </summary>
        /// <param name="index">Индекс атома</param>
        /// <param name="x">Координата атома по Х</param>
        /// <param name="y">Координата атома по Y</param>
        /// <param name="z">Координата атома по Z</param>
        public static bool WriteCoordAtomFileMathematica(double x, double y, double z)
        {
            string path;
            path = pathCordAtomsMathematica;

            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
            {
                    sw.WriteLine("{0},{1},{2}", Convert.ToString(x, System.Globalization.CultureInfo.InvariantCulture),
                    Convert.ToString(y, System.Globalization.CultureInfo.InvariantCulture),
                    Convert.ToString(z, System.Globalization.CultureInfo.InvariantCulture));
                
            }
            return true;
        }

        /// <summary>
        /// Записать энергию в файл
        /// </summary>
        /// <param name="step">Номер шага по времени</param>
        /// <param name="timeStep">Шаг по времени</param>
        /// <param name="kinEnergy">Кинетическая энергия на данном шаге</param>
        /// <param name="potEnergy">Потенциальная энергия на данном шаге</param>
        /// <param name="startPotEnergy">Начальная потенциальная энергия</param>
        /// <param name="test">Это файл из ряда тестов? Если true, то он сохраняется по шаблону в папке с тестами</param>
        /// <returns></returns>
        public static bool WriteEnergyFile(int step, double timeStep, double kinEnergy, double potEnergy, double startPotEnergy)
        {
            string path = pathEnergy;

            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
            {
                sw.WriteLine("{0};{1};;{2};{3};{4}", step, timeStep, potEnergy, kinEnergy, kinEnergy + potEnergy - startPotEnergy);
            }
            return true;
        }


        /// <summary>
        /// Записать координаты первых соседей атомов в файл
        /// </summary>
        /// <param name="index">Индекс атома</param>
        /// <param name="x">Координата атома по Х</param>
        /// <param name="y">Координата атома по Y</param>
        /// <param name="z">Координата атома по Z</param>

        /// <returns></returns>
        public static bool WriteFirstNeighboursdAtoms(int index_atoms, int index_atom1, double x1, double y1, double z1,
                                                                       int index_atom2, double x2, double y2, double z2,
                                                                       int index_atom3, double x3, double y3, double z3,
                                                                       int index_atom4, double x4, double y4, double z4,
                                                                       int index_atom5, double x5, double y5, double z5,
                                                                       int index_atom6, double x6, double y6, double z6,
                                                                       int index_atom7, double x7, double y7, double z7,
                                                                       int index_atom8, double x8, double y8, double z8,
                                                                       int index_atom9, double x9, double y9, double z9,
                                                                       int index_atom10, double x10, double y10, double z10,
                                                                       int index_atom11, double x11, double y11, double z11,
                                                                       int index_atom12, double x12, double y12, double z12)
        {
            string path;
            path = pathFirstNeighboursdAtoms;

            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
            {
                sw.WriteLine(
                    "{0};; {1};{2};{3};{4};; {5};{6};{7};{8};; {9};{10};{11};{12};; {13};{14};{15};{16};; " +
                    "{17};{18};{19};{20};; {21};{22};{23};{24};; {25};{26};{27};{28};; {29};{30};{31};{32};; " +
                    "{33};{34};{35};{36};; {37};{38};{39};{40};; {41};{42};{43};{44};; {45};{46};{47};{48};;",
                    index_atoms,
                    index_atom1, x1, y1, z1,
                    index_atom2, x2, y2, z2,
                    index_atom3, x3, y3, z3,
                    index_atom4, x4, y4, z4,
                    index_atom5, x5, y5, z5,
                    index_atom6, x6, y6, z6,
                    index_atom7, x7, y7, z7,
                    index_atom8, x8, y8, z8,
                    index_atom9, x9, y9, z9,
                    index_atom10, x10, y10, z10,
                    index_atom11, x11, y11, z11,
                    index_atom12, x12, y12, z12);
            }
            return true;
        }

        /// <summary>
        /// Записать координаты вторых соседей атомов в файл
        /// </summary>
        /// <param name="index">Индекс атома</param>
        /// <param name="x">Координата атома по Х</param>
        /// <param name="y">Координата атома по Y</param>
        /// <param name="z">Координата атома по Z</param>

        /// <returns></returns>
        public static bool WriteSecondNeighboursdAtoms(int index_atoms, int index_atoms1, double x1, double y1, double z1,
                                                                        int index_atoms2, double x2, double y2, double z2,
                                                                        int index_atoms3, double x3, double y3, double z3,
                                                                        int index_atoms4, double x4, double y4, double z4,
                                                                        int index_atoms5, double x5, double y5, double z5,
                                                                        int index_atoms6, double x6, double y6, double z6,
                                                                        int index_atoms7, double x7, double y7, double z7,
                                                                        int index_atoms8, double x8, double y8, double z8,
                                                                        int index_atoms9, double x9, double y9, double z9,
                                                                        int index_atoms10, double x10, double y10, double z10,
                                                                        int index_atoms11, double x11, double y11, double z11,
                                                                        int index_atoms12, double x12, double y12, double z12)

        {
            string path;
            path = pathSecondNeighboursdAtoms;

            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
            {
                sw.WriteLine(
                    "{0};;{1};{2};{3};{4};;" +
                         "{5};{6};{7};{8};;" +
                         "{9};{10};{11};{12};;" +
                         "{13};{14};{15};{16};;" +
                         "{17};{18};{19};{20};;" +
                         "{21};{22};{23};{24};;" +
                         "{25};{26};{27};{28};;" +
                         "{29};{30};{31};{32};;" +
                         "{33};{34};{35};{36};;" +
                         "{37};{38};{39};{40};;" +
                         "{41};{42};{43};{44};;" +
                         "{45};{46};{47};{48}",
                    index_atoms,
                    index_atoms1, x1, y1, z1,
                    index_atoms2, x2, y2, z2,
                    index_atoms3, x3, y3, z3,
                    index_atoms4, x4, y4, z4,
                    index_atoms5, x5, y5, z5,
                    index_atoms6, x6, y6, z6,
                    index_atoms7, x7, y7, z7,
                    index_atoms8, x8, y8, z8,
                    index_atoms9, x9, y9, z9,
                    index_atoms10, x10, y10, z10,
                    index_atoms11, x11, y11, z11,
                    index_atoms12, x12, y12, z12);
            }
            return true;

        }

        /// <summary>
        /// Очищает и создает новый файл
        /// </summary>
        /// <param name="tempr">Температура. Необходимо для файла из ряда тестов</param>
        /// <returns></returns>
        public static bool ClearCoordAtomsFile(double tempr = 0)
        {
            try
            {
                string path;
                path = pathCordAtoms;

                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    sw.WriteLine("Индекс атома;Координата X;Координата Y; Координата Z");
                }
                return true;
            }
            catch (System.IO.IOException)
            {
                return false;
            }
        }
        /// <summary>
        /// Очищает и создает новый файл
        /// </summary>
        /// <param name="tempr">Температура. Необходимо для файла из ряда тестов</param>
        /// <returns></returns>
        public static bool ClearCoordAtomsFileMathematica(double tempr = 0)
        {
            try
            {
                string path;
                path = pathCordAtomsMathematica;

                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    //sw.WriteLine("Индекс атома;Координата X;Координата Y; Координата Z");
                }
                return true;
            }
            catch (System.IO.IOException)
            {
                return false;
            }
        }
        /// <summary>
        /// Очищает и создает новый файл
        /// </summary>
        /// <param name="tempr">Температура. Необходимо для файла из ряда тестов</param>
        /// <returns></returns>
        public static bool ClearFirstNeighboursdAtoms(double tempr = 0)
        {
            try
            {
                string path;
                path = pathFirstNeighboursdAtoms;

                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    sw.WriteLine("Индекс атома;; Сосед №1(индекс); Координата X; Координата Y; Координата Z;;" +
                                                "Сосед №2(индекс); Координата X; Координата Y; Координата Z;;" +
                                                "Сосед №3(индекс); Координата X; Координата Y; Координата Z;;" +
                                                "Сосед №4(индекс); Координата X; Координата Y; Координата Z");
                }
                return true;
            }
            catch (System.IO.IOException)
            {
                return false;
            }
        }

        /// <summary>
        /// Очищает и создает новый файл
        /// </summary>
        /// <param name="tempr">Температура. Необходимо для файла из ряда тестов</param>
        /// <returns></returns>
        public static bool ClearSecondNeighboursdAtoms(double tempr = 0)
        {
            try
            {
                string path;
                path = pathSecondNeighboursdAtoms;

                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    sw.WriteLine("Индекс атома;;Сосед №1(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №2(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №3(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №4(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №5(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №6(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №7(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №8(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №9(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №10(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №11(индекс); Координата X; Координата Y; Координата Z;;" +
                                               "Сосед №12(индекс); Координата X; Координата Y; Координата Z");
                }
                return true;
            }
            catch (System.IO.IOException)
            {
                return false;
            }
        }

        /// <summary>
        /// Открывает папку, где лежат сохранённые файлы
        /// </summary>
        public static void OpenStorage()
        {
            Process.Start("explorer", Environment.CurrentDirectory);
        }
        /// <summary>
        /// Открывает файл с координатами атомов
        /// </summary>
        /// <returns></returns>
        public static bool OpenCoordAtomsFile()
        {
            try
            {
                Process.Start(pathCordAtoms);
                return true;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// Очищает и создает новый файл
        /// </summary>
        /// <param name="tempr">Температура. Необходимо для файла из ряда тестов</param>
        /// <returns></returns>
        public static bool ClearEnergyFile(double tempr = 0)
        {
            try
            {
                string path;
                path = pathEnergy;

                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    sw.WriteLine("Номер шага;Шаг по времени; ; Ep, эВ;  Ek, эВ; Esum, эВ;");
                }
                return true;
            }
            catch (System.IO.IOException)
            {
                return false;
            }
        }

        /// <summary>
        /// Открывает файл с координатами первых соседей атомов в структуре
        /// </summary>
        /// <returns></returns>
        public static bool OpenFirstNeighboursdAtomsFile()
        {
            try
            {
                Process.Start(pathFirstNeighboursdAtoms);
                return true;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Открывает файл с координатами вторых соседей атомов в структуре
        /// </summary>
        /// <returns></returns>
        public static bool OpenSecondNeighboursdAtomsFile()
        {
            try
            {
                Process.Start(pathSecondNeighboursdAtoms);
                return true;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return false;
            }
        }
    }
}
