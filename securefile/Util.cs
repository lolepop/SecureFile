using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace securefile
{
	public static class Util
	{
		public static byte[] ReadLastBytes(string filename, int bytesFromEnd)
		{
			using (var reader = new StreamReader(filename))
			{
				reader.BaseStream.Seek(-bytesFromEnd, SeekOrigin.End);

				var memoryStream = new MemoryStream();
				reader.BaseStream.CopyTo(memoryStream);
				return memoryStream.ToArray();
			}
		}

		public static void DeleteLastBytes(string filename, int bytesFromEnd)
		{
			using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Write))
			{
				fs.SetLength(fs.Length - bytesFromEnd);
			}
		}

		public static void AppendAllBytes(string file, byte[] bytes)
		{
			using (FileStream stream = new FileStream(file, FileMode.Append))
				stream.Write(bytes, 0, bytes.Length);
		}

		public static T[] SplitArr<T>(this T[] original, int length, out T[] arr)
		{
			var temp = original.Take(length).ToArray();
			arr = original.Skip(length).ToArray();
			return temp;
		}

		public static T[] ConcatArr<T>(params T[][] arrs)
		{
			List<T> ls = new List<T>();

			foreach (var arr in arrs)
				ls.AddRange(arr);

			return ls.ToArray();
		}


		public static void FileEncrypt(string password, string unencryptedFile, string outFile, int lastBytes = -1) // read whole file if nothing specified
		{
			Aes aes = Aes.Create();

			byte[] salt = new byte[Hashing.SALT_SIZE];
			RandomNumberGenerator.Create().GetBytes(salt); // shared salt

			if (lastBytes <= -1)
				File.WriteAllBytes(outFile, Encryption.AESEncrypt(File.ReadAllBytes(unencryptedFile), aes.Key, aes.IV));
			else
				File.WriteAllBytes(outFile, Encryption.AESEncrypt(ReadLastBytes(unencryptedFile, lastBytes), aes.Key, aes.IV));

			byte[] pwhash = Hashing.Hash(password, salt); // hash of password (used as key)
			byte[] endhash = Hashing.Hash(pwhash, salt); // hash of password hash (used for verification)


			byte[] plainKeyIV = ConcatArr(aes.Key, aes.IV);

			aes.GenerateIV(); // now aes.iv uses a new iv
			byte[] endcrypt = Encryption.AESEncrypt(plainKeyIV, pwhash, aes.IV); // encrypts key and iv used to unlock the actual content with the password hash


			//MessageBox.Show(string.Format("{0} {1} {2} {3}", endcrypt.Length, aes.IV.Length, endhash.Length, salt.Length));

			CryptData cryptData = new CryptData(endcrypt, aes.IV, endhash, salt);
			AppendAllBytes(outFile, cryptData.ToArray());
		}

		public static bool FileDecrypt(string password, string rawDataFile, string outFile)
		{
			byte[] encryptedFile = File.ReadAllBytes(rawDataFile);

			CryptData cryptData = new CryptData();
			encryptedFile = cryptData.SliceFile(encryptedFile);

			byte[] pwHash = Hashing.Hash(password, cryptData.Salt); // back into hashed password

			if (Hashing.VerifyHash(cryptData.HashedPwdHash, pwHash, cryptData.Salt)) // check if hash of hashed password is the same as stored value
			{
				byte[] decryptedKeyIV = Encryption.AESDecryptB(cryptData.Cipher, pwHash, cryptData.CipherIV); // decrypt into actual key and iv of content unlocker

				byte[] decIV = new byte[1];
				byte[] decKey = decryptedKeyIV.SplitArr(Encryption.KEY_SIZE, out decIV);

				byte[] decryptedContent = Encryption.AESDecryptB(encryptedFile, decKey, decIV); // decrypt the actual content with the decrypted key and iv

				//File.WriteAllBytes(outFile, decryptedContent);
				Util.AppendAllBytes(outFile, decryptedContent);
				MessageBox.Show("Successfully decrypted file");

				return true;
			}
			

			MessageBox.Show("Password is incorrect");
			return false;
			
		}
	}
}
