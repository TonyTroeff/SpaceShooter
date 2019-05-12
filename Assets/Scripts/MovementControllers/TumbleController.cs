namespace MovementControllers
{
	using UnityEngine;

	public class TumbleController : MonoBehaviour
	{
		public float Tumble = 1f;

		private void Start()
			=> this.GetComponent<Rigidbody>()
				.angularVelocity = Random.insideUnitSphere * this.Tumble;
	}
}