namespace QLearning.FrontEnd
{
    partial class UI
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
            this.DrawingTimer = new System.Windows.Forms.Timer(this.components);
            this.StartButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RandomPercentage = new System.Windows.Forms.NumericUpDown();
            this.ListBoxConsole = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.StopButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RandomPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawingTimer
            // 
            this.DrawingTimer.Interval = 10;
            this.DrawingTimer.Tick += new System.EventHandler(this.DrawingTimer_Tick);
            // 
            // StartButton
            // 
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartButton.Location = new System.Drawing.Point(0, 638);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(649, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Começar Algoritmo";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StopButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RandomPercentage);
            this.groupBox1.Controls.Add(this.ListBoxConsole);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.PauseButton);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.SpeedTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(12, 355);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 278);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Velocidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Aleatoriedade (%)";
            // 
            // RandomPercentage
            // 
            this.RandomPercentage.Location = new System.Drawing.Point(111, 100);
            this.RandomPercentage.Name = "RandomPercentage";
            this.RandomPercentage.Size = new System.Drawing.Size(122, 20);
            this.RandomPercentage.TabIndex = 6;
            this.RandomPercentage.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.RandomPercentage.ValueChanged += new System.EventHandler(this.RandomPercentage_ValueChanged);
            // 
            // ListBoxConsole
            // 
            this.ListBoxConsole.BackColor = System.Drawing.SystemColors.MenuText;
            this.ListBoxConsole.ForeColor = System.Drawing.Color.LimeGreen;
            this.ListBoxConsole.FormattingEnabled = true;
            this.ListBoxConsole.Location = new System.Drawing.Point(254, 19);
            this.ListBoxConsole.Name = "ListBoxConsole";
            this.ListBoxConsole.Size = new System.Drawing.Size(355, 251);
            this.ListBoxConsole.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Continuar Execução";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(19, 180);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(214, 23);
            this.PauseButton.TabIndex = 3;
            this.PauseButton.Text = "Pausar Execução";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(19, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Mostrar TabelaQ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SpeedTrackBar
            // 
            this.SpeedTrackBar.Location = new System.Drawing.Point(111, 36);
            this.SpeedTrackBar.Maximum = 1000;
            this.SpeedTrackBar.Minimum = 1;
            this.SpeedTrackBar.Name = "SpeedTrackBar";
            this.SpeedTrackBar.Size = new System.Drawing.Size(122, 45);
            this.SpeedTrackBar.TabIndex = 0;
            this.SpeedTrackBar.Value = 500;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(19, 240);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(214, 23);
            this.StopButton.TabIndex = 9;
            this.StopButton.Text = "Parar Execução";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartButton);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(665, 700);
            this.MinimumSize = new System.Drawing.Size(665, 700);
            this.Name = "UI";
            this.Text = "Algoritmo QLearning";
            this.Load += new System.EventHandler(this.UI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UI_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RandomPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer DrawingTimer;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar SpeedTrackBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox ListBoxConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown RandomPercentage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StopButton;
    }
}