namespace Encryption
{
    partial class Encrypt
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
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnChoose = new System.Windows.Forms.Button();
            this.rbPhoto = new System.Windows.Forms.RadioButton();
            this.rbTXT = new System.Windows.Forms.RadioButton();
            this.rbRAR = new System.Windows.Forms.RadioButton();
            this.gbED = new System.Windows.Forms.GroupBox();
            this.rbDecrypt = new System.Windows.Forms.RadioButton();
            this.rbEncrypt = new System.Windows.Forms.RadioButton();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbED.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(63, 55);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 0;
            this.btnChoose.Text = "Choose file";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbPhoto
            // 
            this.rbPhoto.AutoSize = true;
            this.rbPhoto.Location = new System.Drawing.Point(68, 37);
            this.rbPhoto.Name = "rbPhoto";
            this.rbPhoto.Size = new System.Drawing.Size(53, 17);
            this.rbPhoto.TabIndex = 1;
            this.rbPhoto.TabStop = true;
            this.rbPhoto.Text = "Photo";
            this.rbPhoto.UseVisualStyleBackColor = true;
            this.rbPhoto.CheckedChanged += new System.EventHandler(this.rbPhoto_CheckedChanged);
            // 
            // rbTXT
            // 
            this.rbTXT.AutoSize = true;
            this.rbTXT.Location = new System.Drawing.Point(159, 37);
            this.rbTXT.Name = "rbTXT";
            this.rbTXT.Size = new System.Drawing.Size(65, 17);
            this.rbTXT.TabIndex = 2;
            this.rbTXT.TabStop = true;
            this.rbTXT.Text = "Text File";
            this.rbTXT.UseVisualStyleBackColor = true;
            this.rbTXT.CheckedChanged += new System.EventHandler(this.rbTXT_CheckedChanged);
            // 
            // rbRAR
            // 
            this.rbRAR.AutoSize = true;
            this.rbRAR.Location = new System.Drawing.Point(250, 37);
            this.rbRAR.Name = "rbRAR";
            this.rbRAR.Size = new System.Drawing.Size(62, 17);
            this.rbRAR.TabIndex = 3;
            this.rbRAR.TabStop = true;
            this.rbRAR.Text = "Rar FIle";
            this.rbRAR.UseVisualStyleBackColor = true;
            // 
            // gbED
            // 
            this.gbED.Controls.Add(this.rbDecrypt);
            this.gbED.Controls.Add(this.rbEncrypt);
            this.gbED.Controls.Add(this.btnChoose);
            this.gbED.Location = new System.Drawing.Point(95, 124);
            this.gbED.Name = "gbED";
            this.gbED.Size = new System.Drawing.Size(217, 93);
            this.gbED.TabIndex = 4;
            this.gbED.TabStop = false;
            // 
            // rbDecrypt
            // 
            this.rbDecrypt.AutoSize = true;
            this.rbDecrypt.Location = new System.Drawing.Point(116, 19);
            this.rbDecrypt.Name = "rbDecrypt";
            this.rbDecrypt.Size = new System.Drawing.Size(62, 17);
            this.rbDecrypt.TabIndex = 2;
            this.rbDecrypt.TabStop = true;
            this.rbDecrypt.Text = "Decrypt";
            this.rbDecrypt.UseVisualStyleBackColor = true;
            // 
            // rbEncrypt
            // 
            this.rbEncrypt.AutoSize = true;
            this.rbEncrypt.Location = new System.Drawing.Point(16, 19);
            this.rbEncrypt.Name = "rbEncrypt";
            this.rbEncrypt.Size = new System.Drawing.Size(61, 17);
            this.rbEncrypt.TabIndex = 1;
            this.rbEncrypt.TabStop = true;
            this.rbEncrypt.Text = "Encrypt";
            this.rbEncrypt.UseVisualStyleBackColor = true;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(140, 85);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(133, 20);
            this.txtKey.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Key: ";
            // 
            // Encrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.gbED);
            this.Controls.Add(this.rbRAR);
            this.Controls.Add(this.rbTXT);
            this.Controls.Add(this.rbPhoto);
            this.Name = "Encrypt";
            this.Text = "Encrypt";
            this.gbED.ResumeLayout(false);
            this.gbED.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.RadioButton rbPhoto;
        private System.Windows.Forms.RadioButton rbTXT;
        private System.Windows.Forms.RadioButton rbRAR;
        private System.Windows.Forms.GroupBox gbED;
        private System.Windows.Forms.RadioButton rbDecrypt;
        private System.Windows.Forms.RadioButton rbEncrypt;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
    }
}