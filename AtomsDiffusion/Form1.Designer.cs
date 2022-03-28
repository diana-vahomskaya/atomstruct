namespace AtomsDiffusion
{
    partial class Form1
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
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label15;
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_createStructure = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdB_Sn = new System.Windows.Forms.RadioButton();
            this.rdB_Si = new System.Windows.Forms.RadioButton();
            this.rdB_Ar = new System.Windows.Forms.RadioButton();
            this.txt_numAtoms = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CubeCounter = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_atomEnergy = new System.Windows.Forms.TextBox();
            this.txt_sumEnergy = new System.Windows.Forms.TextBox();
            this.btn_calculateEnergy = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_tmprEnergy = new System.Windows.Forms.TextBox();
            this.numUD_multStepRelax = new System.Windows.Forms.NumericUpDown();
            this.numUD_stepNorm = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.numUD_step = new System.Windows.Forms.NumericUpDown();
            this.button_StartRelax = new System.Windows.Forms.Button();
            this.btn_clearStep = new System.Windows.Forms.Button();
            this.btn_deleteStep = new System.Windows.Forms.Button();
            this.btn_addStep = new System.Windows.Forms.Button();
            this.listBox_step = new System.Windows.Forms.ListBox();
            this.numUD_tmpr = new System.Windows.Forms.NumericUpDown();
            this.numUD_shiftAtoms = new System.Windows.Forms.NumericUpDown();
            this.numUD_numStepRelax = new System.Windows.Forms.NumericUpDown();
            this.button_OpenEnergy = new System.Windows.Forms.Button();
            this.checkBox_timeRelax = new System.Windows.Forms.CheckBox();
            this.pict_3 = new System.Windows.Forms.PictureBox();
            this.pict_kinEnergy = new System.Windows.Forms.PictureBox();
            this.pict_potEnergy = new System.Windows.Forms.PictureBox();
            this.timer_screen = new System.Windows.Forms.Timer(this.components);
            label13 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CubeCounter)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_multStepRelax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_stepNorm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_step)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_tmpr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_shiftAtoms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_numStepRelax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_kinEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_potEnergy)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label13.Location = new System.Drawing.Point(9, 74);
            label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(130, 17);
            label13.TabIndex = 21;
            label13.Text = "Энергия на атом ≈";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label5.Location = new System.Drawing.Point(9, 41);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(126, 17);
            label5.TabIndex = 19;
            label5.Text = "Энергия системы:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(272, 41);
            label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(24, 17);
            label10.TabIndex = 22;
            label10.Text = "эВ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(272, 74);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(24, 17);
            label6.TabIndex = 23;
            label6.Text = "эВ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btn_createStructure);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txt_numAtoms);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.CubeCounter);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 239);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры решетки:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "нм";
            // 
            // btn_createStructure
            // 
            this.btn_createStructure.Location = new System.Drawing.Point(140, 171);
            this.btn_createStructure.Name = "btn_createStructure";
            this.btn_createStructure.Size = new System.Drawing.Size(111, 39);
            this.btn_createStructure.TabIndex = 12;
            this.btn_createStructure.Text = "Создать";
            this.btn_createStructure.UseVisualStyleBackColor = true;
            this.btn_createStructure.Click += new System.EventHandler(this.btn_createStructure_Click);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(131, 126);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(98, 23);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "0,526";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Парам. решетки:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdB_Sn);
            this.groupBox1.Controls.Add(this.rdB_Si);
            this.groupBox1.Controls.Add(this.rdB_Ar);
            this.groupBox1.Location = new System.Drawing.Point(269, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 118);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип атома:";
            // 
            // rdB_Sn
            // 
            this.rdB_Sn.AutoSize = true;
            this.rdB_Sn.Location = new System.Drawing.Point(16, 83);
            this.rdB_Sn.Name = "rdB_Sn";
            this.rdB_Sn.Size = new System.Drawing.Size(99, 21);
            this.rdB_Sn.TabIndex = 8;
            this.rdB_Sn.Text = "Олово (Sn)";
            this.rdB_Sn.UseVisualStyleBackColor = true;
            this.rdB_Sn.CheckedChanged += new System.EventHandler(this.rdB_Sn_CheckedChanged);
            // 
            // rdB_Si
            // 
            this.rdB_Si.AutoSize = true;
            this.rdB_Si.Location = new System.Drawing.Point(16, 56);
            this.rdB_Si.Name = "rdB_Si";
            this.rdB_Si.Size = new System.Drawing.Size(110, 21);
            this.rdB_Si.TabIndex = 6;
            this.rdB_Si.Text = "Кремний (Si)";
            this.rdB_Si.UseVisualStyleBackColor = true;
            this.rdB_Si.CheckedChanged += new System.EventHandler(this.rdB_Si_CheckedChanged);
            // 
            // rdB_Ar
            // 
            this.rdB_Ar.AutoSize = true;
            this.rdB_Ar.Checked = true;
            this.rdB_Ar.Location = new System.Drawing.Point(16, 29);
            this.rdB_Ar.Name = "rdB_Ar";
            this.rdB_Ar.Size = new System.Drawing.Size(92, 21);
            this.rdB_Ar.TabIndex = 7;
            this.rdB_Ar.TabStop = true;
            this.rdB_Ar.Text = "Аргон (Ar)";
            this.rdB_Ar.UseVisualStyleBackColor = true;
            this.rdB_Ar.CheckedChanged += new System.EventHandler(this.rdB_Ar_CheckedChanged);
            // 
            // txt_numAtoms
            // 
            this.txt_numAtoms.Enabled = false;
            this.txt_numAtoms.Location = new System.Drawing.Point(131, 83);
            this.txt_numAtoms.Name = "txt_numAtoms";
            this.txt_numAtoms.Size = new System.Drawing.Size(98, 23);
            this.txt_numAtoms.TabIndex = 4;
            this.txt_numAtoms.Text = "32";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кол-во атомов:";
            // 
            // CubeCounter
            // 
            this.CubeCounter.Location = new System.Drawing.Point(131, 42);
            this.CubeCounter.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.CubeCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CubeCounter.Name = "CubeCounter";
            this.CubeCounter.Size = new System.Drawing.Size(98, 23);
            this.CubeCounter.TabIndex = 2;
            this.CubeCounter.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.CubeCounter.ValueChanged += new System.EventHandler(this.numUD_sizeCells_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кол-во кубов:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(label6);
            this.groupBox3.Controls.Add(label10);
            this.groupBox3.Controls.Add(this.txt_atomEnergy);
            this.groupBox3.Controls.Add(label13);
            this.groupBox3.Controls.Add(this.txt_sumEnergy);
            this.groupBox3.Controls.Add(label5);
            this.groupBox3.Controls.Add(this.btn_calculateEnergy);
            this.groupBox3.Location = new System.Drawing.Point(469, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 164);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры расчета энергий";
            // 
            // txt_atomEnergy
            // 
            this.txt_atomEnergy.BackColor = System.Drawing.SystemColors.Control;
            this.txt_atomEnergy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_atomEnergy.ForeColor = System.Drawing.Color.Black;
            this.txt_atomEnergy.Location = new System.Drawing.Point(161, 72);
            this.txt_atomEnergy.Margin = new System.Windows.Forms.Padding(2);
            this.txt_atomEnergy.Name = "txt_atomEnergy";
            this.txt_atomEnergy.ReadOnly = true;
            this.txt_atomEnergy.Size = new System.Drawing.Size(107, 23);
            this.txt_atomEnergy.TabIndex = 20;
            this.txt_atomEnergy.TabStop = false;
            this.txt_atomEnergy.Text = "0";
            // 
            // txt_sumEnergy
            // 
            this.txt_sumEnergy.BackColor = System.Drawing.SystemColors.Control;
            this.txt_sumEnergy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_sumEnergy.ForeColor = System.Drawing.Color.Black;
            this.txt_sumEnergy.Location = new System.Drawing.Point(161, 39);
            this.txt_sumEnergy.Margin = new System.Windows.Forms.Padding(2);
            this.txt_sumEnergy.Name = "txt_sumEnergy";
            this.txt_sumEnergy.ReadOnly = true;
            this.txt_sumEnergy.Size = new System.Drawing.Size(107, 23);
            this.txt_sumEnergy.TabIndex = 18;
            this.txt_sumEnergy.TabStop = false;
            this.txt_sumEnergy.Text = "0";
            // 
            // btn_calculateEnergy
            // 
            this.btn_calculateEnergy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_calculateEnergy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_calculateEnergy.Location = new System.Drawing.Point(108, 112);
            this.btn_calculateEnergy.Margin = new System.Windows.Forms.Padding(2);
            this.btn_calculateEnergy.Name = "btn_calculateEnergy";
            this.btn_calculateEnergy.Size = new System.Drawing.Size(115, 37);
            this.btn_calculateEnergy.TabIndex = 17;
            this.btn_calculateEnergy.Text = "Рассчитать";
            this.btn_calculateEnergy.UseVisualStyleBackColor = false;
            this.btn_calculateEnergy.Click += new System.EventHandler(this.btn_calculateEnergy_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox4.Controls.Add(label18);
            this.groupBox4.Controls.Add(this.txt_tmprEnergy);
            this.groupBox4.Controls.Add(label19);
            this.groupBox4.Controls.Add(this.numUD_multStepRelax);
            this.groupBox4.Controls.Add(label7);
            this.groupBox4.Controls.Add(this.numUD_stepNorm);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.numUD_step);
            this.groupBox4.Controls.Add(this.button_StartRelax);
            this.groupBox4.Controls.Add(this.btn_clearStep);
            this.groupBox4.Controls.Add(label8);
            this.groupBox4.Controls.Add(this.btn_deleteStep);
            this.groupBox4.Controls.Add(this.btn_addStep);
            this.groupBox4.Controls.Add(label17);
            this.groupBox4.Controls.Add(this.listBox_step);
            this.groupBox4.Controls.Add(this.numUD_tmpr);
            this.groupBox4.Controls.Add(label20);
            this.groupBox4.Controls.Add(label12);
            this.groupBox4.Controls.Add(label9);
            this.groupBox4.Controls.Add(this.numUD_shiftAtoms);
            this.groupBox4.Controls.Add(this.numUD_numStepRelax);
            this.groupBox4.Controls.Add(label11);
            this.groupBox4.Controls.Add(this.button_OpenEnergy);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox4.Location = new System.Drawing.Point(11, 270);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(570, 346);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Релаксация структуры";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(357, 122);
            label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(24, 17);
            label18.TabIndex = 53;
            label18.Text = "эВ";
            label18.Visible = false;
            // 
            // txt_tmprEnergy
            // 
            this.txt_tmprEnergy.BackColor = System.Drawing.SystemColors.Control;
            this.txt_tmprEnergy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tmprEnergy.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_tmprEnergy.Location = new System.Drawing.Point(396, 172);
            this.txt_tmprEnergy.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tmprEnergy.Name = "txt_tmprEnergy";
            this.txt_tmprEnergy.ReadOnly = true;
            this.txt_tmprEnergy.Size = new System.Drawing.Size(64, 23);
            this.txt_tmprEnergy.TabIndex = 51;
            this.txt_tmprEnergy.TabStop = false;
            this.txt_tmprEnergy.Text = "0";
            this.txt_tmprEnergy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_tmprEnergy.Visible = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Cursor = System.Windows.Forms.Cursors.Help;
            label19.Location = new System.Drawing.Point(304, 174);
            label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(104, 17);
            label19.TabIndex = 52;
            label19.Text = "Равн. энергия:";
            label19.Visible = false;
            // 
            // numUD_multStepRelax
            // 
            this.numUD_multStepRelax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numUD_multStepRelax.DecimalPlaces = 3;
            this.numUD_multStepRelax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numUD_multStepRelax.Location = new System.Drawing.Point(153, 78);
            this.numUD_multStepRelax.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_multStepRelax.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_multStepRelax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numUD_multStepRelax.Name = "numUD_multStepRelax";
            this.numUD_multStepRelax.Size = new System.Drawing.Size(80, 23);
            this.numUD_multStepRelax.TabIndex = 49;
            this.numUD_multStepRelax.Value = new decimal(new int[] {
            10,
            0,
            0,
            196608});
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Cursor = System.Windows.Forms.Cursors.Help;
            label7.Location = new System.Drawing.Point(11, 80);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(122, 17);
            label7.TabIndex = 50;
            label7.Text = "Множитель шага:";
            // 
            // numUD_stepNorm
            // 
            this.numUD_stepNorm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numUD_stepNorm.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD_stepNorm.Location = new System.Drawing.Point(153, 222);
            this.numUD_stepNorm.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_stepNorm.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUD_stepNorm.Name = "numUD_stepNorm";
            this.numUD_stepNorm.Size = new System.Drawing.Size(77, 23);
            this.numUD_stepNorm.TabIndex = 47;
            this.numUD_stepNorm.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Cursor = System.Windows.Forms.Cursors.Help;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label23.Location = new System.Drawing.Point(4, 224);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(141, 17);
            this.label23.TabIndex = 48;
            this.label23.Text = "Период норм. скор.:";
            // 
            // numUD_step
            // 
            this.numUD_step.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numUD_step.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numUD_step.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD_step.Location = new System.Drawing.Point(318, 93);
            this.numUD_step.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_step.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUD_step.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD_step.Name = "numUD_step";
            this.numUD_step.Size = new System.Drawing.Size(60, 23);
            this.numUD_step.TabIndex = 46;
            this.numUD_step.TabStop = false;
            this.numUD_step.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // button_StartRelax
            // 
            this.button_StartRelax.BackColor = System.Drawing.Color.LightCyan;
            this.button_StartRelax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_StartRelax.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_StartRelax.Location = new System.Drawing.Point(286, 234);
            this.button_StartRelax.Margin = new System.Windows.Forms.Padding(2);
            this.button_StartRelax.Name = "button_StartRelax";
            this.button_StartRelax.Size = new System.Drawing.Size(72, 38);
            this.button_StartRelax.TabIndex = 33;
            this.button_StartRelax.Text = "Запуск";
            this.button_StartRelax.UseVisualStyleBackColor = false;
            this.button_StartRelax.Click += new System.EventHandler(this.button_StartRelax_Click);
            // 
            // btn_clearStep
            // 
            this.btn_clearStep.BackColor = System.Drawing.Color.LightCyan;
            this.btn_clearStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clearStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_clearStep.Location = new System.Drawing.Point(410, 136);
            this.btn_clearStep.Margin = new System.Windows.Forms.Padding(2);
            this.btn_clearStep.Name = "btn_clearStep";
            this.btn_clearStep.Size = new System.Drawing.Size(64, 24);
            this.btn_clearStep.TabIndex = 45;
            this.btn_clearStep.TabStop = false;
            this.btn_clearStep.Text = "Очистить";
            this.btn_clearStep.UseVisualStyleBackColor = false;
            this.btn_clearStep.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(237, 172);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(17, 17);
            label8.TabIndex = 32;
            label8.Text = "К";
            // 
            // btn_deleteStep
            // 
            this.btn_deleteStep.BackColor = System.Drawing.Color.LightCyan;
            this.btn_deleteStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deleteStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_deleteStep.Location = new System.Drawing.Point(410, 113);
            this.btn_deleteStep.Margin = new System.Windows.Forms.Padding(2);
            this.btn_deleteStep.Name = "btn_deleteStep";
            this.btn_deleteStep.Size = new System.Drawing.Size(64, 24);
            this.btn_deleteStep.TabIndex = 44;
            this.btn_deleteStep.TabStop = false;
            this.btn_deleteStep.Text = "Удалить";
            this.btn_deleteStep.UseVisualStyleBackColor = false;
            this.btn_deleteStep.Visible = false;
            // 
            // btn_addStep
            // 
            this.btn_addStep.BackColor = System.Drawing.Color.LightCyan;
            this.btn_addStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_addStep.Location = new System.Drawing.Point(410, 87);
            this.btn_addStep.Margin = new System.Windows.Forms.Padding(2);
            this.btn_addStep.Name = "btn_addStep";
            this.btn_addStep.Size = new System.Drawing.Size(64, 24);
            this.btn_addStep.TabIndex = 43;
            this.btn_addStep.TabStop = false;
            this.btn_addStep.Text = "Добавить";
            this.btn_addStep.UseVisualStyleBackColor = false;
            this.btn_addStep.Visible = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(9, 172);
            label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(100, 17);
            label17.TabIndex = 31;
            label17.Text = "Температура:";
            // 
            // listBox_step
            // 
            this.listBox_step.FormattingEnabled = true;
            this.listBox_step.ItemHeight = 16;
            this.listBox_step.Location = new System.Drawing.Point(318, 124);
            this.listBox_step.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_step.Name = "listBox_step";
            this.listBox_step.Size = new System.Drawing.Size(61, 36);
            this.listBox_step.TabIndex = 41;
            this.listBox_step.TabStop = false;
            this.listBox_step.Visible = false;
            // 
            // numUD_tmpr
            // 
            this.numUD_tmpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numUD_tmpr.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numUD_tmpr.Location = new System.Drawing.Point(153, 170);
            this.numUD_tmpr.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_tmpr.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUD_tmpr.Name = "numUD_tmpr";
            this.numUD_tmpr.Size = new System.Drawing.Size(77, 23);
            this.numUD_tmpr.TabIndex = 30;
            this.numUD_tmpr.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Cursor = System.Windows.Forms.Cursors.Help;
            label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label20.Location = new System.Drawing.Point(322, 63);
            label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(96, 13);
            label20.TabIndex = 42;
            label20.Text = "Деление шага:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(237, 122);
            label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(25, 17);
            label12.TabIndex = 29;
            label12.Text = "нм";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(11, 122);
            label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(138, 17);
            label9.TabIndex = 28;
            label9.Text = "Случ. сдвиг атомов:";
            label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // numUD_shiftAtoms
            // 
            this.numUD_shiftAtoms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numUD_shiftAtoms.DecimalPlaces = 3;
            this.numUD_shiftAtoms.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numUD_shiftAtoms.Location = new System.Drawing.Point(153, 120);
            this.numUD_shiftAtoms.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_shiftAtoms.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_shiftAtoms.Name = "numUD_shiftAtoms";
            this.numUD_shiftAtoms.Size = new System.Drawing.Size(80, 23);
            this.numUD_shiftAtoms.TabIndex = 27;
            this.numUD_shiftAtoms.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // numUD_numStepRelax
            // 
            this.numUD_numStepRelax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numUD_numStepRelax.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numUD_numStepRelax.Location = new System.Drawing.Point(153, 26);
            this.numUD_numStepRelax.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_numStepRelax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUD_numStepRelax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numUD_numStepRelax.Name = "numUD_numStepRelax";
            this.numUD_numStepRelax.Size = new System.Drawing.Size(80, 23);
            this.numUD_numStepRelax.TabIndex = 24;
            this.numUD_numStepRelax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(9, 28);
            label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(133, 17);
            label11.TabIndex = 25;
            label11.Text = "Количество шагов:";
            // 
            // button_OpenEnergy
            // 
            this.button_OpenEnergy.BackColor = System.Drawing.Color.LightCyan;
            this.button_OpenEnergy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_OpenEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_OpenEnergy.Location = new System.Drawing.Point(424, 213);
            this.button_OpenEnergy.Margin = new System.Windows.Forms.Padding(2);
            this.button_OpenEnergy.Name = "button_OpenEnergy";
            this.button_OpenEnergy.Size = new System.Drawing.Size(73, 59);
            this.button_OpenEnergy.TabIndex = 18;
            this.button_OpenEnergy.Text = "Открыть энергию в Excel";
            this.button_OpenEnergy.UseVisualStyleBackColor = false;
            // 
            // checkBox_timeRelax
            // 
            this.checkBox_timeRelax.AutoSize = true;
            this.checkBox_timeRelax.Checked = true;
            this.checkBox_timeRelax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_timeRelax.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkBox_timeRelax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_timeRelax.Location = new System.Drawing.Point(999, 19);
            this.checkBox_timeRelax.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_timeRelax.Name = "checkBox_timeRelax";
            this.checkBox_timeRelax.Size = new System.Drawing.Size(132, 21);
            this.checkBox_timeRelax.TabIndex = 61;
            this.checkBox_timeRelax.TabStop = false;
            this.checkBox_timeRelax.Text = "Выводить время";
            this.checkBox_timeRelax.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label22.ForeColor = System.Drawing.SystemColors.ControlText;
            label22.Location = new System.Drawing.Point(811, 432);
            label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(317, 13);
            label22.TabIndex = 60;
            label22.Text = "График кинетической, потенциальной и суммарной энергии:";
            // 
            // pict_3
            // 
            this.pict_3.BackColor = System.Drawing.Color.White;
            this.pict_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pict_3.Location = new System.Drawing.Point(811, 443);
            this.pict_3.Margin = new System.Windows.Forms.Padding(2);
            this.pict_3.Name = "pict_3";
            this.pict_3.Size = new System.Drawing.Size(477, 210);
            this.pict_3.TabIndex = 58;
            this.pict_3.TabStop = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(813, 224);
            label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(214, 17);
            label16.TabIndex = 59;
            label16.Text = "График кинетической энергии:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label15.ForeColor = System.Drawing.SystemColors.ControlText;
            label15.Location = new System.Drawing.Point(813, 26);
            label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(172, 13);
            label15.TabIndex = 57;
            label15.Text = "График потенциальной энергии:";
            // 
            // pict_kinEnergy
            // 
            this.pict_kinEnergy.BackColor = System.Drawing.Color.White;
            this.pict_kinEnergy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pict_kinEnergy.Location = new System.Drawing.Point(811, 240);
            this.pict_kinEnergy.Margin = new System.Windows.Forms.Padding(2);
            this.pict_kinEnergy.Name = "pict_kinEnergy";
            this.pict_kinEnergy.Size = new System.Drawing.Size(477, 190);
            this.pict_kinEnergy.TabIndex = 56;
            this.pict_kinEnergy.TabStop = false;
            // 
            // pict_potEnergy
            // 
            this.pict_potEnergy.BackColor = System.Drawing.Color.White;
            this.pict_potEnergy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pict_potEnergy.Location = new System.Drawing.Point(811, 45);
            this.pict_potEnergy.Margin = new System.Windows.Forms.Padding(2);
            this.pict_potEnergy.Name = "pict_potEnergy";
            this.pict_potEnergy.Size = new System.Drawing.Size(477, 177);
            this.pict_potEnergy.TabIndex = 55;
            this.pict_potEnergy.TabStop = false;
            // 
            // timer_screen
            // 
            this.timer_screen.Interval = 300;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 739);
            this.Controls.Add(this.checkBox_timeRelax);
            this.Controls.Add(label22);
            this.Controls.Add(this.pict_3);
            this.Controls.Add(label16);
            this.Controls.Add(label15);
            this.Controls.Add(this.pict_kinEnergy);
            this.Controls.Add(this.pict_potEnergy);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CubeCounter)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_multStepRelax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_stepNorm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_step)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_tmpr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_shiftAtoms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_numStepRelax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_kinEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_potEnergy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_createStructure;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdB_Sn;
        private System.Windows.Forms.RadioButton rdB_Si;
        private System.Windows.Forms.RadioButton rdB_Ar;
        private System.Windows.Forms.TextBox txt_numAtoms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown CubeCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_atomEnergy;
        private System.Windows.Forms.TextBox txt_sumEnergy;
        private System.Windows.Forms.Button btn_calculateEnergy;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_tmprEnergy;
        private System.Windows.Forms.NumericUpDown numUD_multStepRelax;
        private System.Windows.Forms.NumericUpDown numUD_stepNorm;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numUD_step;
        private System.Windows.Forms.Button button_StartRelax;
        private System.Windows.Forms.Button btn_clearStep;
        private System.Windows.Forms.Button btn_deleteStep;
        private System.Windows.Forms.Button btn_addStep;
        private System.Windows.Forms.ListBox listBox_step;
        private System.Windows.Forms.NumericUpDown numUD_tmpr;
        private System.Windows.Forms.NumericUpDown numUD_shiftAtoms;
        private System.Windows.Forms.NumericUpDown numUD_numStepRelax;
        private System.Windows.Forms.Button button_OpenEnergy;
        private System.Windows.Forms.CheckBox checkBox_timeRelax;
        private System.Windows.Forms.PictureBox pict_3;
        private System.Windows.Forms.PictureBox pict_kinEnergy;
        private System.Windows.Forms.PictureBox pict_potEnergy;
        private System.Windows.Forms.Timer timer_screen;
    }
}

