namespace securefile
{
	partial class Main
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.InputBox = new System.Windows.Forms.TextBox();
			this.EncryptedBox = new System.Windows.Forms.TextBox();
			this.InputBrowse = new System.Windows.Forms.Button();
			this.EncryptedBrowse = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.EncryptRadio = new System.Windows.Forms.RadioButton();
			this.DecryptRadio = new System.Windows.Forms.RadioButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.BackupDec = new System.Windows.Forms.CheckBox();
			this.BackupEnc = new System.Windows.Forms.CheckBox();
			this.LastBytes = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(68, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Input FIle";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(44, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Encrypted FIle";
			// 
			// InputBox
			// 
			this.InputBox.Location = new System.Drawing.Point(125, 48);
			this.InputBox.Name = "InputBox";
			this.InputBox.Size = new System.Drawing.Size(336, 20);
			this.InputBox.TabIndex = 2;
			// 
			// EncryptedBox
			// 
			this.EncryptedBox.Location = new System.Drawing.Point(125, 98);
			this.EncryptedBox.Name = "EncryptedBox";
			this.EncryptedBox.Size = new System.Drawing.Size(336, 20);
			this.EncryptedBox.TabIndex = 3;
			// 
			// InputBrowse
			// 
			this.InputBrowse.Location = new System.Drawing.Point(467, 46);
			this.InputBrowse.Name = "InputBrowse";
			this.InputBrowse.Size = new System.Drawing.Size(75, 23);
			this.InputBrowse.TabIndex = 4;
			this.InputBrowse.Text = "Browse";
			this.InputBrowse.UseVisualStyleBackColor = true;
			this.InputBrowse.Click += new System.EventHandler(this.InputBrowse_Click);
			// 
			// EncryptedBrowse
			// 
			this.EncryptedBrowse.Location = new System.Drawing.Point(467, 96);
			this.EncryptedBrowse.Name = "EncryptedBrowse";
			this.EncryptedBrowse.Size = new System.Drawing.Size(75, 23);
			this.EncryptedBrowse.TabIndex = 5;
			this.EncryptedBrowse.Text = "Browse";
			this.EncryptedBrowse.UseVisualStyleBackColor = true;
			this.EncryptedBrowse.Click += new System.EventHandler(this.EncryptedBrowse_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(47, 169);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(133, 48);
			this.StartButton.TabIndex = 6;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// EncryptRadio
			// 
			this.EncryptRadio.AutoSize = true;
			this.EncryptRadio.Checked = true;
			this.EncryptRadio.Location = new System.Drawing.Point(186, 169);
			this.EncryptRadio.Name = "EncryptRadio";
			this.EncryptRadio.Size = new System.Drawing.Size(61, 17);
			this.EncryptRadio.TabIndex = 7;
			this.EncryptRadio.TabStop = true;
			this.EncryptRadio.Text = "Encrypt";
			this.EncryptRadio.UseVisualStyleBackColor = true;
			this.EncryptRadio.CheckedChanged += new System.EventHandler(this.ModeChanged);
			// 
			// DecryptRadio
			// 
			this.DecryptRadio.AutoSize = true;
			this.DecryptRadio.Location = new System.Drawing.Point(186, 200);
			this.DecryptRadio.Name = "DecryptRadio";
			this.DecryptRadio.Size = new System.Drawing.Size(62, 17);
			this.DecryptRadio.TabIndex = 8;
			this.DecryptRadio.TabStop = true;
			this.DecryptRadio.Text = "Decrypt";
			this.DecryptRadio.UseVisualStyleBackColor = true;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.OverwritePrompt = false;
			// 
			// BackupDec
			// 
			this.BackupDec.AutoSize = true;
			this.BackupDec.Checked = true;
			this.BackupDec.CheckState = System.Windows.Forms.CheckState.Checked;
			this.BackupDec.Location = new System.Drawing.Point(286, 169);
			this.BackupDec.Name = "BackupDec";
			this.BackupDec.Size = new System.Drawing.Size(148, 17);
			this.BackupDec.TabIndex = 9;
			this.BackupDec.Text = "Backup before decrypting";
			this.BackupDec.UseVisualStyleBackColor = true;
			// 
			// BackupEnc
			// 
			this.BackupEnc.AutoSize = true;
			this.BackupEnc.Checked = true;
			this.BackupEnc.CheckState = System.Windows.Forms.CheckState.Checked;
			this.BackupEnc.Location = new System.Drawing.Point(286, 201);
			this.BackupEnc.Name = "BackupEnc";
			this.BackupEnc.Size = new System.Drawing.Size(148, 17);
			this.BackupEnc.TabIndex = 10;
			this.BackupEnc.Text = "Backup before encrypting";
			this.BackupEnc.UseVisualStyleBackColor = true;
			// 
			// LastBytes
			// 
			this.LastBytes.Location = new System.Drawing.Point(361, 133);
			this.LastBytes.Name = "LastBytes";
			this.LastBytes.Size = new System.Drawing.Size(100, 20);
			this.LastBytes.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(250, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Last bytes to encrypt";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(571, 267);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LastBytes);
			this.Controls.Add(this.BackupEnc);
			this.Controls.Add(this.BackupDec);
			this.Controls.Add(this.DecryptRadio);
			this.Controls.Add(this.EncryptRadio);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.EncryptedBrowse);
			this.Controls.Add(this.InputBrowse);
			this.Controls.Add(this.EncryptedBox);
			this.Controls.Add(this.InputBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Main";
			this.Text = "SecureFile";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox InputBox;
		private System.Windows.Forms.TextBox EncryptedBox;
		private System.Windows.Forms.Button InputBrowse;
		private System.Windows.Forms.Button EncryptedBrowse;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.RadioButton EncryptRadio;
		private System.Windows.Forms.RadioButton DecryptRadio;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.CheckBox BackupDec;
		private System.Windows.Forms.CheckBox BackupEnc;
		private System.Windows.Forms.TextBox LastBytes;
		private System.Windows.Forms.Label label3;
	}
}

