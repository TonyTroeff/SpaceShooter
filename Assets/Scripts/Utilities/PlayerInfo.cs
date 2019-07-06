namespace SpaceShooter.Utilities
{
	using System;

	[Serializable]
	public class PlayerInfo
	{
		public PlayerInfo() => this.Upgrades = new UpgradesInfo();

		public long HighestScore;
		public long Coins;
		public UpgradesInfo Upgrades;
	}
}