namespace AtomsDiffusion
{
    partial class FormConsole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtBox_output = new System.Windows.Forms.TextBox();
            this.pgsBar_time = new System.Windows.Forms.ProgressBar();
            this.label_progress = new System.Windows.Forms.Label();
            this.check_outputPause = new System.Windows.Forms.CheckBox();
            this.btn_break = new System.Windows.Forms.Button();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtBox_output
            // 
            this.txtBox_output.BackColor = System.Drawing.Color.White;
            this.txtBox_output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox_output.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBox_output.Location = new System.Drawing.Point(12, 12);
            this.txtBox_output.MaxLength = 0;
            this.txtBox_output.Multiline = true;
            this.txtBox_output.Name = "txtBox_output";
            this.txtBox_output.ReadOnly = true;
            this.txtBox_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox_output.Size = new System.Drawing.Size(446, 426);
            this.txtBox_output.TabIndex = 14;
            // 
            // pgsBar_time
            // 
            this.pgsBar_time.Location = new System.Drawing.Point(464, 39);
            this.pgsBar_time.Name = "pgsBar_time";
            this.pgsBar_time.Size = new System.Drawing.Size(242, 37);
            this.pgsBar_time.TabIndex = 15;
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_progress.Location = new System.Drawing.Point(726, 49);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(32, 17);
            this.label_progress.TabIndex = 16;
            this.label_progress.Text = "0 %";
            this.label_progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // check_outputPause
            // 
            this.check_outputPause.AutoSize = true;
            this.check_outputPause.Cursor = System.Windows.Forms.Cursors.Help;
            this.check_outputPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_outputPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.check_outputPause.Location = new System.Drawing.Point(464, 98);
            this.check_outputPause.Name = "check_outputPause";
            this.check_outputPause.Size = new System.Drawing.Size(169, 21);
            this.check_outputPause.TabIndex = 19;
            this.check_outputPause.Text = "Приостановить вывод";
            this.check_outputPause.UseVisualStyleBackColor = true;
            // 
            // btn_break
            // 
            this.btn_break.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_break.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_break.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_break.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_break.Location = new System.Drawing.Point(509, 156);
            this.btn_break.Name = "btn_break";
            this.btn_break.Size = new System.Drawing.Size(197, 46);
            this.btn_break.TabIndex = 18;
            this.btn_break.Text = "Прервать";
            this.btn_break.UseVisualStyleBackColor = false;
            this.btn_break.Visible = false;
            // 
            // timer_update
            // 
            this.timer_update.Interval = 300;
            this.timer_update.Tick += new System.EventHandler(this.timer_update_Tick);
            // 
            // FormConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.check_outputPause);
            this.Controls.Add(this.btn_break);
            this.Controls.Add(this.pgsBar_time);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.txtBox_output);
            this.Name = "FormConsole";
            this.Text = "FormConsole";
            this.Load += new System.EventHandler(this.FormConsole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_output;
        private System.Windows.Forms.ProgressBar pgsBar_time;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.CheckBox check_outputPause;
        private System.Windows.Forms.Button btn_break;
        private System.Windows.Forms.Timer timer_update;
    }
}