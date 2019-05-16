namespace SpaceShooter
{
	using UnityEngine;

	public class BackgroundController : MonoBehaviour
	{
		private float _backgroundLength;
		private Rigidbody _rigidbody;

		public float ScrollSpeed;

		private void Awake()
		{
			this._rigidbody = this.GetComponent<Rigidbody>();
			GameController.OnWaveSpawn += this.UpdateSpeed;
		}

		private void Start()
		{
			Transform backgroundTransform = this.transform;

			Vector3 scale = new Vector3(ScreenController.Dimensions.x * 2, ScreenController.Dimensions.x * 4, 0);
			backgroundTransform.localScale = scale;
			this._backgroundLength = scale.y;

			this._rigidbody.velocity = new Vector3(0, -5, this.ScrollSpeed);
		}

		private void Update()
		{
			if (this.transform.position.z <= 0) this.transform.position = new Vector3(0, -5, this._backgroundLength);
		}

		private void UpdateSpeed(int waveCount)
			=> this._rigidbody.velocity = new Vector3(0, -5, this.ScrollSpeed - waveCount / 10f);
	}
}