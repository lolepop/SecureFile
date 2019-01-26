namespace securefile
{
	// 64 + 16 + 32 + 16 = 128
	public class CryptData
	{
		public const int CIPHERLEN = Encryption.KEY_SIZE + Encryption.IV_SIZE + 16; // aes cipher size calculation

		public const int TOTAL_SIZE = CIPHERLEN + Encryption.IV_SIZE + Hashing.HASHLEN + Hashing.SALT_SIZE; // Total size of data
		public readonly int[] SECTIONLEN = { CIPHERLEN, Encryption.IV_SIZE, Hashing.HASHLEN }; // length of each section

		public byte[] Cipher { get; set; }
		public byte[] CipherIV { get; set; }
		public byte[] HashedPwdHash { get; set; }
		public byte[] Salt { get; set; }

		public CryptData(byte[] cipher, byte[] cipherIV, byte[] hashedPwdHash, byte[] salt)
		{
			Cipher = cipher;
			CipherIV = cipherIV;
			HashedPwdHash = hashedPwdHash;
			Salt = salt;
		}

		public CryptData() { }

		public byte[] ToArray()
		{
			//MessageBox.Show(string.Format("{0} {1} {2} {3}", Cipher.Length, CipherIV.Length, HashedPwdHash.Length, Salt.Length));

			return Util.ConcatArr(Cipher, CipherIV, HashedPwdHash, Salt);
		}

		public void ParseRaw(byte[] rawData) // ending = encrypted with password hash (aes key + aes iv) + iv + hashed password hash + salt
		{
			// size calculation at the top of the class

			Cipher = rawData.SplitArr(SECTIONLEN[0], out rawData);
			CipherIV = rawData.SplitArr(SECTIONLEN[1], out rawData);
			HashedPwdHash = rawData.SplitArr(SECTIONLEN[2], out rawData);
			Salt = rawData;
		}

		public byte[] SliceFile(byte[] fileArr) // fileArr = encrypted data + CryptData.ToArray()
		{
			byte[] rawData = new byte[1];
			var encryptedContent = fileArr.SplitArr(fileArr.Length - TOTAL_SIZE, out rawData);
			ParseRaw(rawData);
			return encryptedContent;
		}

	}
}
