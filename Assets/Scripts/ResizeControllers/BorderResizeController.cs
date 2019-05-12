#region

using UnityEngine;

#endregion

namespace ResizeControllers
{
	public class BorderResizeController : MonoBehaviour
	{
		private void Start()
		{
			Transform borderTransform = this.transform;
			borderTransform.localScale = new Vector3(
				ScreenController.Dimensions.x * 2,
				1,
				ScreenController.Dimensions.z + borderTransform.position.z);
		}
	}
}