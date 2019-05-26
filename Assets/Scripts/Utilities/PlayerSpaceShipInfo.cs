namespace SpaceShooter.Utilities
{
	using System;
	
	[Serializable]
	public class PlayerSpaceShipInfo
	{
		public string SpaceShipName;
		public bool IsDefault;
		public bool IsUnlocked;

		public int SpeedPoints;
		public int WeaponPoints;
	}
}