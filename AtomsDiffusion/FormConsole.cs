using System;
using System.Drawing;
using System.Windows.Forms;

namespace AtomsDiffusion
{
    public partial class FormConsole : Form
    {
        Motion relax;
        public FormConsole(Motion relax)
        {
            InitializeComponent();
            this.relax = relax;
            btn_break.Visible = true;

        }


        private void btn_break_Click(object sender, EventArgs e)
        {
            if (relax.End)
            {
                Close();
                return;
            }

            if (MessageBox.Show("Прервать процесс?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                btn_break.Enabled = false;
                btn_break.BackColor = Color.Green;
                relax.BREAK = true;
            }
        }

        

        private void timer_update_Tick(object sender, EventArgs e)
        {
            //вывод текста
            if (txtBox_output.Text.Length != relax.GetListText.Length && !check_outputPause.Checked)
                txtBox_output.AppendText(relax.GetListText.Substring(txtBox_output.Text.Length));

            //прогресс бар
            if (pgsBar_time.Value != relax.GetStep)
            {
                pgsBar_time.Value = relax.GetStep;
                label_progress.Text = String.Format("{0}%", pgsBar_time.Value * 100 / pgsBar_time.Maximum);
            }

            //завершение вычислений
            if (relax.End)
            {
                timer_update.Stop();

                // если завершено, то выводим всё в текстбокс
                if (check_outputPause.Checked && txtBox_output.Text.Length != relax.GetListText.Length)
                {
                    txtBox_output.AppendText(relax.GetListText.Substring(txtBox_output.Text.Length));
                }
                check_outputPause.Enabled = false;

                pgsBar_time.Value = pgsBar_time.Maximum;
                label_progress.Text = "100%";

                btn_break.Enabled = true;
                btn_break.Text = "Закрыть";
                btn_break.BackColor = Color.White;
                btn_break.Select();
            }
        }

        private void FormConsole_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.DoubleBuffered = true;

            pgsBar_time.Maximum = relax.GetNumStep + 1;
            timer_update.Start();
        }
    }
}
