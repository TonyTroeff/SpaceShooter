using UnityEngine;

namespace ResizeControllers {
	public class StarFieldResizeController : MonoBehaviour
	{
		private void Start()
		{
			ParticleSystem[] particleSystems = this.GetComponentsInChildren<ParticleSystem>();

			foreach (ParticleSystem system in particleSystems)
			{
				ParticleSystem.ShapeModule shape = system
					.shape;
				shape.scale = new Vector3(ScreenController.Dimensions.x * 2, 1, 1);
			}
		}
	}
}