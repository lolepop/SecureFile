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
		
		private void Main_Load(object sender, EventArgs e)
		{
			//Util.FileEncrypt("eatmyass23451", "testdoc.txt", "encryptedFile.txt");

			//Util.FileDecrypt("eatmyass23451", "encryptedFile.txt", "decrypted.txt");

			//Environment.Exit(1);
		}

		private void InputBrowse_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				InputBox.Text = openFileDialog1.FileName;

				if (string.IsNullOrEmpty(EncryptedBox.Text))
					EncryptedBox.Text = openFileDialog1.FileName + ".enc";
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
					EncryptedBox.Text = saveFileDialog1.FileName;
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

				Util.FileEncrypt(password, InputBox.Text, EncryptedBox.Text, delBytes);

				if (OverrideOriginalCheck.Checked)
				{
					if (delBytes != -1)
						Util.DeleteLastBytes(InputBox.Text, delBytes);	
				}
				else
				{
					int a = InputBox.Text.LastIndexOf('.');
					string newFile = InputBox.Text.Substring(0, a) + ".modified" + InputBox.Text.Substring(a);


					if (delBytes != -1)
					{
						File.Copy(InputBox.Text, newFile);
						Util.DeleteLastBytes(newFile, delBytes);
					}

				}

			}
			else
			{
				if (duplicateCheck.Checked && !File.Exists(InputBox.Text + ".bak"))
					File.Copy(InputBox.Text, InputBox.Text + ".bak");

				Util.FileDecrypt(password, EncryptedBox.Text, InputBox.Text);
			}
		}

		private void ModeChanged(object sender, EventArgs e)
		{
			label1.Text = EncryptRadio.Checked ? "Input File" : "Output File";
		}
	}
}
