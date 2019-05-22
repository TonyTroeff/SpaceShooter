namespace SpaceShooter.Serialization
{
	using System;
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;
	using UnityEngine;

	public static class Serializer
	{
		private static readonly string _encryptionKey = Resources.Load<TextAsset>("EncryptionKey")
			.text;

		public static void Save<T>(T obj) where T : class
		{
			string json = JsonUtility.ToJson(obj);

			byte[] jsonToBytes = Encoding.UTF8.GetBytes(json);

			using (RijndaelManaged rijndael = new RijndaelManaged())
			{
				rijndael.BlockSize = 128;
				rijndael.KeySize = 256;

				byte[] salt = new byte[128];
				using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider()) rng.GetBytes(salt);

				byte[] key;
				using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(_encryptionKey, salt))
					key = rfc.GetBytes(rijndael.KeySize / 8);

				rijndael.Key = key;
				rijndael.GenerateIV();

				using (ICryptoTransform encryptor = rijndael.CreateEncryptor())
				{
					byte[] encryptedJsonBytes = encryptor.TransformFinalBlock(jsonToBytes, 0, jsonToBytes.Length);

					// 44 symbols long
					string encryptedJson = Convert.ToBase64String(encryptedJsonBytes);

					// 172 symbols long
					string saltString = Convert.ToBase64String(salt);

					// 25 symbols long.
					string ivString = Convert.ToBase64String(rijndael.IV);

					File.WriteAllText(GetPath<T>(), encryptedJson + saltString + ivString);
				}
			}
		}

		public static T Load<T>() where T : class
		{
			string path = GetPath<T>();

			if (File.Exists(path) == false) return null;

			string json = File.ReadAllText(path);

			using (RijndaelManaged rijndael = new RijndaelManaged())
			{
				rijndael.BlockSize = 128;
				rijndael.KeySize = 256;

				string encryptedJson = json.Substring(0, 44);
				byte[] encryptedJsonBytes = Convert.FromBase64String(encryptedJson);

				string saltString = json.Substring(44, 172);
				byte[] salt = Convert.FromBase64String(saltString);

				string ivString = json.Substring(216);
				byte[] iv = Convert.FromBase64String(ivString);

				byte[] key;
				using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(_encryptionKey, salt))
					key = rfc.GetBytes(rijndael.KeySize / 8);

				using (ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv))
				{
					byte[] decryptedJsonBytes = decryptor.TransformFinalBlock(
						encryptedJsonBytes,
						0,
						encryptedJsonBytes.Length);
					string decryptedJson = Encoding.UTF8.GetString(decryptedJsonBytes);

					T obj = JsonUtility.FromJson<T>(decryptedJson);
					return obj;
				}
			}
		}

		private static string GetPath<T>() => $"{Application.persistentDataPath}/{typeof(T).Name}.plyi";
	}
}