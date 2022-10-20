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
            this.velocidade2 = new System.Windows.Forms.Label();
            this.velocidade1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.increase2 = new System.Windows.Forms.Button();
            this.decrease2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.increase1 = new System.Windows.Forms.Button();
            this.decrease1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pararEnvase = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.groupBox1.Controls.Add(this.velocidade2);
            this.groupBox1.Controls.Add(this.velocidade1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.increase2);
            this.groupBox1.Controls.Add(this.decrease2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.increase1);
            this.groupBox1.Controls.Add(this.decrease1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(21, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controle de Velocidade";
            // 
            // velocidade2
            // 
            this.velocidade2.AutoSize = true;
            this.velocidade2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.velocidade2.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.velocidade2.Location = new System.Drawing.Point(49, 73);
            this.velocidade2.Name = "velocidade2";
            this.velocidade2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.velocidade2.Size = new System.Drawing.Size(22, 25);
            this.velocidade2.TabIndex = 7;
            this.velocidade2.Text = "0";
            // 
            // velocidade1
            // 
            this.velocidade1.AutoSize = true;
            this.velocidade1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.velocidade1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.velocidade1.Location = new System.Drawing.Point(49, 32);
            this.velocidade1.Name = "velocidade1";
            this.velocidade1.Size = new System.Drawing.Size(22, 25);
            this.velocidade1.TabIndex = 6;
            this.velocidade1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(367, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Esteira 2";
            // 
            // increase2
            // 
            this.increase2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.increase2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.increase2.ForeColor = System.Drawing.Color.Black;
            this.increase2.Location = new System.Drawing.Point(270, 73);
            this.increase2.Name = "increase2";
            this.increase2.Size = new System.Drawing.Size(75, 23);
            this.increase2.TabIndex = 4;
            this.increase2.Text = "Aumentar";
            this.increase2.UseVisualStyleBackColor = false;
            this.increase2.Click += new System.EventHandler(this.AumentaVelocidadeEsteira2);
            // 
            // decrease2
            // 
            this.decrease2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.decrease2.Enabled = false;
            this.decrease2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decrease2.ForeColor = System.Drawing.Color.Black;
            this.decrease2.Location = new System.Drawing.Point(172, 73);
            this.decrease2.Name = "decrease2";
            this.decrease2.Size = new System.Drawing.Size(75, 23);
            this.decrease2.TabIndex = 3;
            this.decrease2.Text = "Diminuir";
            this.decrease2.UseVisualStyleBackColor = false;
            this.decrease2.Click += new System.EventHandler(this.DiminuiVelocidadeEsteira2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(367, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Esteira 1";
            // 
            // increase1
            // 
            this.increase1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.increase1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.increase1.ForeColor = System.Drawing.Color.Black;
            this.increase1.Location = new System.Drawing.Point(270, 32);
            this.increase1.Name = "increase1";
            this.increase1.Size = new System.Drawing.Size(75, 23);
            this.increase1.TabIndex = 1;
            this.increase1.Text = "Aumentar";
            this.increase1.UseVisualStyleBackColor = false;
            this.increase1.Click += new System.EventHandler(this.AumentaVelocidadeEsteira1);
            // 
            // decrease1
            // 
            this.decrease1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.decrease1.Enabled = false;
            this.decrease1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decrease1.ForeColor = System.Drawing.Color.Black;
            this.decrease1.Location = new System.Drawing.Point(172, 32);
            this.decrease1.Name = "decrease1";
            this.decrease1.Size = new System.Drawing.Size(75, 23);
            this.decrease1.TabIndex = 0;
            this.decrease1.Text = "Diminuir";
            this.decrease1.UseVisualStyleBackColor = false;
            this.decrease1.Click += new System.EventHandler(this.DiminuiVelocidadeEsteira1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.panel1.Location = new System.Drawing.Point(34, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(51, 32);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.panel2.Location = new System.Drawing.Point(34, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(51, 32);
            this.panel2.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.pararEnvase);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(518, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 242);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Emergência";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(60, 136);
            this.button1.Name = "pararEsteiras";
            this.button1.Size = new System.Drawing.Size(108, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = "Parar Esteiras";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.PararEsteiras);
            // 
            // pararEnvase
            // 
            this.pararEnvase.BackColor = System.Drawing.Color.Firebrick;
            this.pararEnvase.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.pararEnvase.FlatAppearance.BorderSize = 2;
            this.pararEnvase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pararEnvase.ForeColor = System.Drawing.Color.Black;
            this.pararEnvase.Location = new System.Drawing.Point(60, 33);
            this.pararEnvase.Name = "pararEnvase";
            this.pararEnvase.Size = new System.Drawing.Size(108, 65);
            this.pararEnvase.TabIndex = 0;
            this.pararEnvase.Text = "Parar Envase";
            this.pararEnvase.UseVisualStyleBackColor = false;
            this.pararEnvase.Click += new System.EventHandler(this.PararEnvase);
            // 
            // frmAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(765, 291);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAtividade";
            this.Text = "  ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button increase1;
        private Button decrease1;
        private Label label2;
        private Button increase2;
        private Button decrease2;
        private Label velocidade2;
        private Label velocidade1;
        private GroupBox groupBox2;
        private Button pararEnvase;
        private Button button1;
        private Panel panel1;
        private Panel panel2;
    }
}