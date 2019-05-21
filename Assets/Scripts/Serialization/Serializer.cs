namespace SpaceShooter.Serialization
{
	using System.IO;
	using UnityEngine;

	public static class Serializer
	{
		private static readonly string _encryptionKey = Resources.Load<TextAsset>("EncryptionKey")
			.text;

		public static void Save<T>(T obj) where T : class
		{
			string json = JsonUtility.ToJson(obj);
			
			File.WriteAllText(Application.persistentDataPath + "PlayerProgress.json", json);
			// TODO: Encrypt the json;
		}

		public static T Load<T>() where T : class
		{
			string json = File.ReadAllText(Application.persistentDataPath + "PlayerProgress.json");
			// TODO: Decrypt the json;
			
			T obj = JsonUtility.FromJson<T>(json);
			return obj;
		}
	}
}