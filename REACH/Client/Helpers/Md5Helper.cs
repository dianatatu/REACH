using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

namespace REACH.Client.Helpers
{
	class Md5Helper
	{
		// http://msdn.microsoft.com/en-us/library/system.security.cryptography.md5cryptoserviceprovider.aspx
		public static string GetMd5(string input)
		{
			MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
			byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
			StringBuilder sBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
				sBuilder.Append(data[i].ToString("x2"));
			return sBuilder.ToString();
		}
	}
}
