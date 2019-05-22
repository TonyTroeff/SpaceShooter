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
			?.text;

		public static void Save<T>(T obj) where T : class
		{
			string json = JsonUtility.ToJson(obj);

			if (_encryptionKey != null)
			{
				byte[] jsonToBytes = Encoding.UTF8.GetBytes(json);

				using (RijndaelManaged rijndael = GetRijndaelManaged())
				{
					(byte[] key, byte[] salt) = GetDerivedKey(rijndael.KeySize / 8);
					rijndael.Key = key;

					rijndael.GenerateIV();

					using (ICryptoTransform encryptor = rijndael.CreateEncryptor())
					{
						byte[] encryptedJsonBytes = encryptor.TransformFinalBlock(jsonToBytes, 0, jsonToBytes.Length);

						// 44 symbols long
						string encryptedJson = Convert.ToBase64String(encryptedJsonBytes);

						// 172 symbols long
						string saltString = Convert.ToBase64String(salt);

						// 24 symbols long.
						string ivString = Convert.ToBase64String(rijndael.IV);

						json = encryptedJson + saltString + ivString;
					}
				}
			}

			File.WriteAllText(GetPath<T>(), json);
		}

		public static T Load<T>() where T : class
		{
			string path = GetPath<T>();

			if (File.Exists(path) == false) return null;

			string json = File.ReadAllText(path);

			if (_encryptionKey != null)
				using (RijndaelManaged rijndael = GetRijndaelManaged())
				{
					byte[] encryptedJsonBytes = GetByteSequence(json, 0, 44);
					byte[] salt = GetByteSequence(json, 44, 172);
					byte[] iv = GetByteSequence(json, 216, 24);

					byte[] key = GetDerivedKey(rijndael.KeySize / 8, salt);

					using (ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv))
					{
						byte[] decryptedJsonBytes = decryptor.TransformFinalBlock(
							encryptedJsonBytes,
							0,
							encryptedJsonBytes.Length);

						json = Encoding.UTF8.GetString(decryptedJsonBytes);
					}
				}

			T obj = JsonUtility.FromJson<T>(json);
			return obj;
		}

		private static string GetPath<T>() => $"{Application.persistentDataPath}/{typeof(T).Name}.plyi";

		private static RijndaelManaged GetRijndaelManaged() => new RijndaelManaged { BlockSize = 128, KeySize = 256 };

		private static (byte[], byte[]) GetDerivedKey(int length)
		{
			byte[] salt = new byte[128];
			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider()) rng.GetBytes(salt);

			byte[] array;
			using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(_encryptionKey, salt)) array = rfc.GetBytes(length);

			return (array, salt);
		}

		private static byte[] GetDerivedKey(int length, byte[] salt)
		{
			byte[] array;
			using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(_encryptionKey, salt)) array = rfc.GetBytes(length);

			return array;
		}

		private static byte[] GetByteSequence(string text, int start, int length)
			=> Convert.FromBase64String(text.Substring(start, length));
	}
}