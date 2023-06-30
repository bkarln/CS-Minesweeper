using System.Windows.Forms;

namespace Minesweeper
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
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.groupBoxLevel = new System.Windows.Forms.GroupBox();
            this.rbMediumLevel = new System.Windows.Forms.RadioButton();
            this.rbHardLevel = new System.Windows.Forms.RadioButton();
            this.rbEasyLevel = new System.Windows.Forms.RadioButton();
            this.labelHelp = new System.Windows.Forms.Label();
            this.textBoxHelper = new System.Windows.Forms.TextBox();
            this.groupBoxLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(12, 157);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(115, 36);
            this.buttonNewGame.TabIndex = 1;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // groupBoxLevel
            // 
            this.groupBoxLevel.Controls.Add(this.rbMediumLevel);
            this.groupBoxLevel.Controls.Add(this.rbHardLevel);
            this.groupBoxLevel.Controls.Add(this.rbEasyLevel);
            this.groupBoxLevel.Location = new System.Drawing.Point(12, 29);
            this.groupBoxLevel.Name = "groupBoxLevel";
            this.groupBoxLevel.Size = new System.Drawing.Size(115, 102);
            this.groupBoxLevel.TabIndex = 1;
            this.groupBoxLevel.TabStop = false;
            this.groupBoxLevel.Text = "Choose level";
            // 
            // rbMediumLevel
            // 
            this.rbMediumLevel.AutoSize = true;
            this.rbMediumLevel.Location = new System.Drawing.Point(6, 43);
            this.rbMediumLevel.Name = "rbMediumLevel";
            this.rbMediumLevel.Size = new System.Drawing.Size(62, 17);
            this.rbMediumLevel.TabIndex = 5;
            this.rbMediumLevel.TabStop = true;
            this.rbMediumLevel.Text = "Medium";
            this.rbMediumLevel.UseVisualStyleBackColor = true;
            // 
            // rbHardLevel
            // 
            this.rbHardLevel.AutoSize = true;
            this.rbHardLevel.Location = new System.Drawing.Point(6, 66);
            this.rbHardLevel.Name = "rbHardLevel";
            this.rbHardLevel.Size = new System.Drawing.Size(48, 17);
            this.rbHardLevel.TabIndex = 4;
            this.rbHardLevel.TabStop = true;
            this.rbHardLevel.Text = "Hard";
            this.rbHardLevel.UseVisualStyleBackColor = true;
            // 
            // rbEasyLevel
            // 
            this.rbEasyLevel.AutoSize = true;
            this.rbEasyLevel.Location = new System.Drawing.Point(6, 19);
            this.rbEasyLevel.Name = "rbEasyLevel";
            this.rbEasyLevel.Size = new System.Drawing.Size(48, 17);
            this.rbEasyLevel.TabIndex = 3;
            this.rbEasyLevel.TabStop = true;
            this.rbEasyLevel.Text = "Easy";
            this.rbEasyLevel.UseVisualStyleBackColor = true;
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(15, 514);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(32, 13);
            this.labelHelp.TabIndex = 2;
            this.labelHelp.Text = "INFO";
            // 
            // textBoxHelper
            // 
            this.textBoxHelper.Location = new System.Drawing.Point(12, 223);
            this.textBoxHelper.Multiline = true;
            this.textBoxHelper.Name = "textBoxHelper";
            this.textBoxHelper.Size = new System.Drawing.Size(177, 288);
            this.textBoxHelper.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 578);
            this.Controls.Add(this.textBoxHelper);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.groupBoxLevel);
            this.Controls.Add(this.buttonNewGame);
            this.Name = "Form1";
            this.Text = "Minesweeper 2020";
            this.groupBoxLevel.ResumeLayout(false);
            this.groupBoxLevel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.GroupBox groupBoxLevel;
        private System.Windows.Forms.RadioButton rbEasyLevel;
        private System.Windows.Forms.RadioButton rbMediumLevel;
        private System.Windows.Forms.RadioButton rbHardLevel;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.TextBox textBoxHelper;
    }
}

