using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace securefile
{
	public class Encryption // regular .net implementation, no external packages needed
	{
		public const int KEY_SIZE = 32;
		public const int IV_SIZE = 16;

		// byte array encryption and decryption
		public static byte[] AESEncrypt(byte[] str, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Key = key;
			aes.IV = iv;

			ICryptoTransform crypt = aes.CreateEncryptor(aes.Key, aes.IV);

			MemoryStream ms = new MemoryStream();
			using (var cs = new CryptoStream(ms, crypt, CryptoStreamMode.Write))
				cs.Write(str, 0, str.Length);

			return ms.ToArray();
		}

		public static byte[] AESDecryptB(byte[] cipher, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Key = key;
			aes.IV = iv;

			ICryptoTransform decrypt = aes.CreateDecryptor(aes.Key, aes.IV);
			MemoryStream msd = new MemoryStream(cipher);
			using (var cs = new CryptoStream(msd, decrypt, CryptoStreamMode.Read))
			{
				MemoryStream decryptedStream = new MemoryStream();

				int dbyte;
				while ((dbyte = cs.ReadByte()) != -1)
					decryptedStream.WriteByte((byte)dbyte);


				decryptedStream.Position = 0;
				return decryptedStream.ToArray();
			}
		}


		// string encryption and decryption
		public static byte[] AESEncrypt(string str, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Key = key;
			aes.IV = iv;

			ICryptoTransform crypt = aes.CreateEncryptor(aes.Key, aes.IV);

			MemoryStream ms = new MemoryStream();
			using (StreamWriter sw = new StreamWriter(new CryptoStream(ms, crypt, CryptoStreamMode.Write)))
				sw.Write(str);

			return ms.ToArray();
		}

		public static string AESDecrypt(byte[] cipher, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Key = key;
			aes.IV = iv;

			ICryptoTransform decrypt = aes.CreateDecryptor(aes.Key, aes.IV);
			MemoryStream msd = new MemoryStream(cipher);
			using (StreamReader sr = new StreamReader(new CryptoStream(msd, decrypt, CryptoStreamMode.Read)))
				return sr.ReadToEnd();
		}
	}
}
