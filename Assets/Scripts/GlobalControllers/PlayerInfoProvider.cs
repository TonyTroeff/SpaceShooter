namespace SpaceShooter.GlobalControllers
{
	using Serialization;
	using UnityEngine;
	using Utilities;

	public class PlayerInfoProvider : MonoBehaviour
	{
		public static PlayerInfo PlayerInfo { get; private set; }

		private static PlayerInfoProvider Instance { get; set; }

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
				PlayerInfo = Serializer.Load<PlayerInfo>() ?? new PlayerInfo();
			}
			else if (Instance != this) Destroy(this.gameObject);

			DontDestroyOnLoad(Instance);
		}
	}
}