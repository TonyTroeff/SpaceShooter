namespace SpaceShooter.MenuControllers
{
	using Helpers;
	using UnityEngine;

	public class RestartButtonController : MonoBehaviour
	{
		public void Restart() => MenuHelper.Restart();
	}
}