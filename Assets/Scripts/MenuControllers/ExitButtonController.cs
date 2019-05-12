#region

using Helpers;
using UnityEngine;

#endregion

namespace MenuControllers
{
	public class ExitButtonController : MonoBehaviour
	{
		public void Exit() => MenuHelper.Exit();
	}
}