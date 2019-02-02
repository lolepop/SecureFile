using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace securefile
{
	class Hashing
	{
		public const uint DEFAULT_TIMECOST = 7;
		public const uint DEFAULT_MEMCOST = 1048576U; // 1 gib in kib
		public const uint DEFAULT_THREADS = 4;

		public const int HASH_SIZE = 32;
		public const int SALT_SIZE = 16;


		[DllImport("Argon2RefDllx86.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "argon2d_hash_raw")]
		static extern int argon2d_hash_raw(uint t_cost, uint m_cost, uint parallelism, byte[] pwd, int pwdlen, byte[] salt, int saltlen, byte[] hash, int hashlen);

		[DllImport("Argon2RefDll.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "argon2d_hash_raw")]
		static extern int argon2d_hash_raw64(uint t_cost, uint m_cost, uint parallelism, byte[] pwd, int pwdlen, byte[] salt, int saltlen, byte[] hash, int hashlen);

		public static byte[] Hash(byte[] str, byte[] salt, uint timecost = DEFAULT_TIMECOST, uint memlimit = DEFAULT_MEMCOST, uint threads = DEFAULT_THREADS)
		{
			byte[] buffer = new byte[HASH_SIZE];

			if (Environment.Is64BitProcess)
				argon2d_hash_raw64(timecost, memlimit, threads, str, str.Length, salt, salt.Length, buffer, buffer.Length);
			else
				argon2d_hash_raw(timecost, memlimit, threads, str, str.Length, salt, salt.Length, buffer, buffer.Length);

			return buffer;
		}

		public static byte[] Hash(string str, byte[] salt, uint timecost = DEFAULT_TIMECOST, uint memlimit = DEFAULT_MEMCOST, uint threads = DEFAULT_THREADS)
		{
			return Hash(Encoding.UTF8.GetBytes(str), salt, timecost, memlimit, threads);
		}

		public static bool VerifyHash(byte[] hash, string password, byte[] salt, uint timecost = DEFAULT_TIMECOST, uint memlimit = DEFAULT_MEMCOST, uint threads = DEFAULT_THREADS)
		{
			return Hash(password, salt, timecost, memlimit, threads).SequenceEqual(hash);
		}

		public static bool VerifyHash(byte[] hash, byte[] password, byte[] salt, uint timecost = DEFAULT_TIMECOST, uint memlimit = DEFAULT_MEMCOST, uint threads = DEFAULT_THREADS)
		{
			return Hash(password, salt, timecost, memlimit, threads).SequenceEqual(hash);
		}

	}
}
