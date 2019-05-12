#region

using Helpers;
using UnityEngine;

#endregion

namespace MenuControllers
{
	public class RestartButtonController : MonoBehaviour
	{
		public void Restart() => MenuHelper.Restart();
	}
}