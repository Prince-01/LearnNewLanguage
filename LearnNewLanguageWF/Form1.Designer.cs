namespace LearnNewLanguageWF
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
            this.showSymbolLbl = new System.Windows.Forms.Label();
            this.drawSymbolPanel = new System.Windows.Forms.Panel();
            this.redrawBtn = new System.Windows.Forms.Button();
            this.nextLetterBtn = new System.Windows.Forms.Button();
            this.latinNotation = new System.Windows.Forms.Label();
            this.showSymbolBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showSymbolLbl
            // 
            this.showSymbolLbl.AutoSize = true;
            this.showSymbolLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showSymbolLbl.Location = new System.Drawing.Point(344, 57);
            this.showSymbolLbl.Name = "showSymbolLbl";
            this.showSymbolLbl.Size = new System.Drawing.Size(184, 181);
            this.showSymbolLbl.TabIndex = 0;
            this.showSymbolLbl.Text = "K";
            // 
            // drawSymbolPanel
            // 
            this.drawSymbolPanel.BackColor = System.Drawing.SystemColors.Info;
            this.drawSymbolPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawSymbolPanel.Location = new System.Drawing.Point(12, 35);
            this.drawSymbolPanel.Margin = new System.Windows.Forms.Padding(10);
            this.drawSymbolPanel.Name = "drawSymbolPanel";
            this.drawSymbolPanel.Size = new System.Drawing.Size(336, 271);
            this.drawSymbolPanel.TabIndex = 1;
            this.drawSymbolPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawSymbolPanel_MouseDown);
            this.drawSymbolPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawSymbolPanel_MouseMove);
            this.drawSymbolPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawSymbolPanel_MouseUp);
            // 
            // redrawBtn
            // 
            this.redrawBtn.Location = new System.Drawing.Point(375, 283);
            this.redrawBtn.Name = "redrawBtn";
            this.redrawBtn.Size = new System.Drawing.Size(75, 23);
            this.redrawBtn.TabIndex = 2;
            this.redrawBtn.Text = "Redraw";
            this.redrawBtn.UseVisualStyleBackColor = true;
            this.redrawBtn.Click += new System.EventHandler(this.redrawBtn_Click);
            // 
            // nextLetterBtn
            // 
            this.nextLetterBtn.Location = new System.Drawing.Point(456, 283);
            this.nextLetterBtn.Name = "nextLetterBtn";
            this.nextLetterBtn.Size = new System.Drawing.Size(75, 23);
            this.nextLetterBtn.TabIndex = 3;
            this.nextLetterBtn.Text = "Next letter";
            this.nextLetterBtn.UseVisualStyleBackColor = true;
            this.nextLetterBtn.Click += new System.EventHandler(this.nextLetterBtn_Click);
            // 
            // latinNotation
            // 
            this.latinNotation.AutoSize = true;
            this.latinNotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.latinNotation.Location = new System.Drawing.Point(147, 9);
            this.latinNotation.Name = "latinNotation";
            this.latinNotation.Size = new System.Drawing.Size(70, 25);
            this.latinNotation.TabIndex = 4;
            this.latinNotation.Text = "label1";
            // 
            // showSymbolBtn
            // 
            this.showSymbolBtn.Location = new System.Drawing.Point(537, 283);
            this.showSymbolBtn.Name = "showSymbolBtn";
            this.showSymbolBtn.Size = new System.Drawing.Size(132, 23);
            this.showSymbolBtn.TabIndex = 5;
            this.showSymbolBtn.Text = "Show symbol";
            this.showSymbolBtn.UseVisualStyleBackColor = true;
            this.showSymbolBtn.Click += new System.EventHandler(this.showSymbolBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 318);
            this.Controls.Add(this.showSymbolBtn);
            this.Controls.Add(this.latinNotation);
            this.Controls.Add(this.nextLetterBtn);
            this.Controls.Add(this.redrawBtn);
            this.Controls.Add(this.drawSymbolPanel);
            this.Controls.Add(this.showSymbolLbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label showSymbolLbl;
        private System.Windows.Forms.Panel drawSymbolPanel;
        private System.Windows.Forms.Button redrawBtn;
        private System.Windows.Forms.Button nextLetterBtn;
        private System.Windows.Forms.Label latinNotation;
        private System.Windows.Forms.Button showSymbolBtn;

    }
}

