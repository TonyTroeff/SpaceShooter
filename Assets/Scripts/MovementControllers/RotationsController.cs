#region

using UnityEngine;

#endregion

namespace MovementControllers
{
	public class RotationsController : MonoBehaviour
	{
		public float Tumble = 1f;

		private void Start()
		{
			this.GetComponent<Rigidbody>()
				.angularVelocity = Random.insideUnitSphere * this.Tumble;
		}
	}
}