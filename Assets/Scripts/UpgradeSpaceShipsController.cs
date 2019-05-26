namespace SpaceShooter
{
	using System;
	using Serialization;
	using UnityEngine;
	using Utilities;

	public class UpgradeSpaceShipsController : MonoBehaviour
	{
		private PlayerProgressInfo _playerProgressInfo;

		private void Awake() => this._playerProgressInfo = Serializer.Load<PlayerProgressInfo>();

		public void UpgradeShip()
		{
			// TODO
		}
	}
}