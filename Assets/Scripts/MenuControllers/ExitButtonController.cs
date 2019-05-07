#region

using UnityEngine;

#endregion

namespace MenuControllers
{
	public class ExitButtonController : MonoBehaviour
	{
		public void Exit() => Application.Quit();
	}
}