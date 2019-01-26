using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sodium;

namespace securefile
{
	class Hashing
	{
		public const int DEFAULT_OPSLIMIT = 5;
		public const int DEFAULT_MEMLIMIT = 1073741824;
		public const int HASHLEN = 32;

		public const int SALT_SIZE = 16;


		public static byte[] Hash(byte[] str, byte[] salt, int opslimit = DEFAULT_OPSLIMIT, int memlimit = DEFAULT_MEMLIMIT)
		{
			return PasswordHash.ArgonHashBinary(str, salt, opslimit, memlimit, HASHLEN);
		}

		public static byte[] Hash(string str, byte[] salt, int opslimit = DEFAULT_OPSLIMIT, int memlimit = DEFAULT_MEMLIMIT)
		{
			return Hash(Encoding.UTF8.GetBytes(str), salt, opslimit, memlimit);
		}

		public static bool VerifyHash(byte[] hash, string password, byte[] salt, int opslimit = DEFAULT_OPSLIMIT, int memlimit = DEFAULT_MEMLIMIT)
		{
			return Hash(password, salt, opslimit, memlimit).SequenceEqual(hash);
		}

		public static bool VerifyHash(byte[] hash, byte[] password, byte[] salt, int opslimit = DEFAULT_OPSLIMIT, int memlimit = DEFAULT_MEMLIMIT)
		{
			return Hash(password, salt, opslimit, memlimit).SequenceEqual(hash);
		}

		// lol how do i use this shit without making a wrapper in c++

		//[DllImport("Argon2RefDll.dll", CharSet = CharSet.Ansi)]
		//unsafe public static extern int argon2d_hash_raw(uint t_cost, uint m_cost, uint parallelism, [MarshalAs(UnmanagedType.LPStr)] string pwd, uint pwdlen, [MarshalAs(UnmanagedType.LPArray)] byte[] salt, uint saltlen, void* hash, uint hashlen);

		//unsafe static void Hash(string str)
		//{
		//	string pwd = "test";
		//	byte[] salt = { 0x2, 0x3 };

		//	byte* hash = stackalloc byte[32];


		//	argon2d_hash_raw(2, 1 << 64, 1, pwd, (uint)pwd.Length, salt, (uint)salt.Length, hash, 32);

		//	byte[] hashres = new byte[32];

		//	for (int i = 0; i < 32; i++)
		//	{
		//		hashres[i] = hash[i];
		//	}

		//	File.WriteAllBytes("testing.txt", hashres);
		//}

	}
}
