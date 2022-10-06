namespace Unip.Tcc
{
    partial class frmAtividade
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.led3 = new System.Windows.Forms.CheckBox();
            this.led2 = new System.Windows.Forms.CheckBox();
            this.led1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.connect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.led3);
            this.groupBox1.Controls.Add(this.led2);
            this.groupBox1.Controls.Add(this.led1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(294, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controle de LED";
            // 
            // led3
            // 
            this.led3.AutoSize = true;
            this.led3.Location = new System.Drawing.Point(267, 50);
            this.led3.Name = "led3";
            this.led3.Size = new System.Drawing.Size(52, 19);
            this.led3.TabIndex = 2;
            this.led3.Text = "LED3";
            this.led3.UseVisualStyleBackColor = true;
            this.led3.CheckedChanged += new System.EventHandler(this.Led3CheckboxClicked);
            // 
            // led2
            // 
            this.led2.AutoSize = true;
            this.led2.Location = new System.Drawing.Point(141, 50);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(52, 19);
            this.led2.TabIndex = 1;
            this.led2.Text = "LED2";
            this.led2.UseVisualStyleBackColor = true;
            this.led2.CheckedChanged += new System.EventHandler(this.Led2CheckboxClicked);
            // 
            // led1
            // 
            this.led1.AutoSize = true;
            this.led1.Location = new System.Drawing.Point(16, 50);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(52, 19);
            this.led1.TabIndex = 0;
            this.led1.Text = "LED1";
            this.led1.UseVisualStyleBackColor = true;
            this.led1.CheckedChanged += new System.EventHandler(this.Led1CheckboxClicked);

            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.connect);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(294, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 119);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conexão Serial";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(167, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // connect
            // 
            this.connect.ForeColor = System.Drawing.Color.Black;
            this.connect.Location = new System.Drawing.Point(26, 55);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(100, 23);
            this.connect.TabIndex = 0;
            this.connect.Text = "Conectar";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // frmAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(733, 477);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAtividade";
            this.Text = "frmAtividade";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox led3;
        private CheckBox led2;
        private CheckBox led1;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private Button connect;
    }
}