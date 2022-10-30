namespace Unip.Tcc
{
    partial class frmEstatisticas
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
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.qntProd200 = new System.Windows.Forms.Label();
            this.qntRej200 = new System.Windows.Forms.Label();
            this.energ200 = new System.Windows.Forms.Label();
            this.litros200 = new System.Windows.Forms.Label();
            this.qntProd300 = new System.Windows.Forms.Label();
            this.qntRej300 = new System.Windows.Forms.Label();
            this.energ300 = new System.Windows.Forms.Label();
            this.litros300 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(606, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Exportar Relatório";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.GenerateExcel);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(326, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "200mL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantidade Produzida:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(43, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Litros Envazados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(43, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Energia Gasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quantidade Rejeitada:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(461, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "300mL";
            // 
            // qntProd200
            // 
            this.qntProd200.AutoSize = true;
            this.qntProd200.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.qntProd200.ForeColor = System.Drawing.Color.White;
            this.qntProd200.Location = new System.Drawing.Point(326, 76);
            this.qntProd200.Name = "qntProd200";
            this.qntProd200.Size = new System.Drawing.Size(14, 16);
            this.qntProd200.TabIndex = 8;
            this.qntProd200.Text = "0";
            // 
            // qntRej200
            // 
            this.qntRej200.AutoSize = true;
            this.qntRej200.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.qntRej200.ForeColor = System.Drawing.Color.White;
            this.qntRej200.Location = new System.Drawing.Point(326, 124);
            this.qntRej200.Name = "qntRej200";
            this.qntRej200.Size = new System.Drawing.Size(14, 16);
            this.qntRej200.TabIndex = 9;
            this.qntRej200.Text = "0";
            // 
            // energ200
            // 
            this.energ200.AutoSize = true;
            this.energ200.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.energ200.ForeColor = System.Drawing.Color.White;
            this.energ200.Location = new System.Drawing.Point(326, 171);
            this.energ200.Name = "energ200";
            this.energ200.Size = new System.Drawing.Size(14, 16);
            this.energ200.TabIndex = 10;
            this.energ200.Text = "0";
            // 
            // litros200
            // 
            this.litros200.AutoSize = true;
            this.litros200.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.litros200.ForeColor = System.Drawing.Color.White;
            this.litros200.Location = new System.Drawing.Point(326, 220);
            this.litros200.Name = "litros200";
            this.litros200.Size = new System.Drawing.Size(14, 16);
            this.litros200.TabIndex = 11;
            this.litros200.Text = "0";
            // 
            // qntProd300
            // 
            this.qntProd300.AutoSize = true;
            this.qntProd300.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.qntProd300.ForeColor = System.Drawing.Color.White;
            this.qntProd300.Location = new System.Drawing.Point(461, 76);
            this.qntProd300.Name = "qntProd300";
            this.qntProd300.Size = new System.Drawing.Size(14, 16);
            this.qntProd300.TabIndex = 12;
            this.qntProd300.Text = "0";
            // 
            // qntRej300
            // 
            this.qntRej300.AutoSize = true;
            this.qntRej300.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.qntRej300.ForeColor = System.Drawing.Color.White;
            this.qntRej300.Location = new System.Drawing.Point(461, 124);
            this.qntRej300.Name = "qntRej300";
            this.qntRej300.Size = new System.Drawing.Size(14, 16);
            this.qntRej300.TabIndex = 13;
            this.qntRej300.Text = "0";
            // 
            // energ300
            // 
            this.energ300.AutoSize = true;
            this.energ300.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.energ300.ForeColor = System.Drawing.Color.White;
            this.energ300.Location = new System.Drawing.Point(461, 171);
            this.energ300.Name = "energ300";
            this.energ300.Size = new System.Drawing.Size(14, 16);
            this.energ300.TabIndex = 14;
            this.energ300.Text = "0";
            // 
            // litros300
            // 
            this.litros300.AutoSize = true;
            this.litros300.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.litros300.ForeColor = System.Drawing.Color.White;
            this.litros300.Location = new System.Drawing.Point(461, 219);
            this.litros300.Name = "litros300";
            this.litros300.Size = new System.Drawing.Size(14, 16);
            this.litros300.TabIndex = 15;
            this.litros300.Text = "0";
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.Color.CornflowerBlue;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.ForeColor = System.Drawing.Color.Black;
            this.update.Location = new System.Drawing.Point(651, 22);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 16;
            this.update.Text = "Atualizar";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.UpdateValues);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(651, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ResetaValores);
            // 
            // frmEstatisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(765, 291);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.update);
            this.Controls.Add(this.litros300);
            this.Controls.Add(this.energ300);
            this.Controls.Add(this.qntRej300);
            this.Controls.Add(this.qntProd300);
            this.Controls.Add(this.litros200);
            this.Controls.Add(this.energ200);
            this.Controls.Add(this.qntRej200);
            this.Controls.Add(this.qntProd200);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEstatisticas";
            this.Text = "frmEstatisticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button1;
        private Label label5;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label6;
        private Label qntProd200;
        private Label qntRej200;
        private Label energ200;
        private Label litros200;
        private Label qntProd300;
        private Label qntRej300;
        private Label energ300;
        private Label litros300;
        private Button update;
        private Button button2;
    }
}