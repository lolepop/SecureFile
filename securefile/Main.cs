using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

#pragma warning disable IDE1006

namespace securefile
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		private void InputBrowse_Click(object sender, EventArgs e)
		{
			if (EncryptRadio.Checked)
			{
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					InputBox.Text = openFileDialog1.FileName;

					if (string.IsNullOrEmpty(EncryptedBox.Text))
					{
						int a = openFileDialog1.FileName.LastIndexOf('.');
						EncryptedBox.Text = openFileDialog1.FileName.Substring(0, a) + ".enc" + InputBox.Text.Substring(a);
					}

				}
			}
			else
			{
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
					EncryptedBox.Text = saveFileDialog1.FileName;
			}
		}

		private void EncryptedBrowse_Click(object sender, EventArgs e)
		{
			if (EncryptRadio.Checked)
			{
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
					EncryptedBox.Text = saveFileDialog1.FileName;
			}
			else
			{
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
					EncryptedBox.Text = openFileDialog1.FileName;
			}

		}

		private void StartButton_Click(object sender, EventArgs e)
		{

			if (string.IsNullOrEmpty(EncryptedBox.Text) || string.IsNullOrEmpty(InputBox.Text) || !File.Exists(InputBox.Text))
				return;

				string password = Interaction.InputBox("Enter password");

			if (string.IsNullOrEmpty(password))
				return;


			if (EncryptRadio.Checked)
			{
				int delBytes = string.IsNullOrEmpty(LastBytes.Text) ? -1 : int.Parse(LastBytes.Text);
				delBytes = delBytes <= 0 ? -1 : delBytes;

				Util.FileEncrypt(password, InputBox.Text, EncryptedBox.Text, delBytes);

				if (BackupEnc.Checked)
				{
					int a = InputBox.Text.LastIndexOf('.');
					string newFile = InputBox.Text.Substring(0, a) + ".bak" + InputBox.Text.Substring(a);


					if (delBytes != -1)
						File.Copy(InputBox.Text, newFile);

				}

				if (delBytes != -1)
					Util.DeleteLastBytes(InputBox.Text, delBytes);

				MessageBox.Show("Encryption complete");

			}
			else
			{
				string newFile = InputBox.Text + ".encbak";

				if (BackupDec.Checked && File.Exists(InputBox.Text))
				{
					string lol = newFile;
					int iter = 1;

					while (File.Exists(lol))
					{
						lol = newFile + iter++.ToString();
					}
					File.Copy(InputBox.Text, lol);
				}

				if (Util.FileDecrypt(password, EncryptedBox.Text, InputBox.Text))
					MessageBox.Show("Successfully decrypted file");
				else
					MessageBox.Show("Password is incorrect");

			}
		}

		private void ModeChanged(object sender, EventArgs e)
		{
			label1.Text = (LastBytes.Enabled = EncryptRadio.Checked) ? "Input File" : "Output File";
		}
	}
}
