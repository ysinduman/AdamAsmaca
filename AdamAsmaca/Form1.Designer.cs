namespace AdamAsmaca
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.FlowLayoutPanel flpHarfler;
        private System.Windows.Forms.Button btnNewGame;

        /// <summary>
        /// Temizleme işlemleri
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Tasarımcı tarafından gereken metod.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWord = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.flpHarfler = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWord.Location = new System.Drawing.Point(133, 62);
            this.lblWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(89, 31);
            this.lblWord.TabIndex = 0;
            this.lblWord.Text = "_____";
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemaining.Location = new System.Drawing.Point(133, 123);
            this.lblRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(125, 25);
            this.lblRemaining.TabIndex = 1;
            this.lblRemaining.Text = "Kalan Hak: 9";
            // 
            // flpHarfler
            // 
            this.flpHarfler.Location = new System.Drawing.Point(53, 165);
            this.flpHarfler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpHarfler.Name = "flpHarfler";
            this.flpHarfler.Size = new System.Drawing.Size(510, 302);
            this.flpHarfler.TabIndex = 2;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(73, 485);
            this.btnNewGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(200, 49);
            this.btnNewGame.TabIndex = 3;
            this.btnNewGame.Text = "Yeni Oyun Başlat";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 588);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.flpHarfler);
            this.Controls.Add(this.lblRemaining);
            this.Controls.Add(this.lblWord);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Adam Asmaca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
