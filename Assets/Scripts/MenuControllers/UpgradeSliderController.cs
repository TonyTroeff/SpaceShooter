namespace SpaceShooter.MenuControllers
{
	using UnityEngine;
	using UnityEngine.UI;

	public class UpgradeSliderController : MonoBehaviour
	{
		public Slider Slider;

		public void Upgrade()
		{
			// TODO: Coins;
			this.Slider.value += 1;
		}
	}
}