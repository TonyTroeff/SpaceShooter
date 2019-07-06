namespace SpaceShooter.MenuControllers
{
	using System.Reflection;
	using GlobalControllers;
	using UnityEngine;
	using UnityEngine.UI;
	using Utilities;

	public class UpgradePlayerInfoController : MonoBehaviour
	{
		public string PropertyName;

		private int _points;
		private FieldInfo _fieldInfo;

		private void Awake() => this._fieldInfo = typeof(UpgradesInfo).GetField(this.PropertyName);

		private void Start()
		{
			this._points = (int) this._fieldInfo.GetValue(PlayerInfoProvider.PlayerInfo.Upgrades);
			this.GetComponent<Slider>()
				.value = this._points;
		}

		public void Upgrade()
		{
			this._points++;
			this._fieldInfo.SetValue(PlayerInfoProvider.PlayerInfo.Upgrades, this._points);
		}
	}
}