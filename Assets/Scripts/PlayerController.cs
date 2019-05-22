namespace SpaceShooter
{
	using Serialization;
	using UnityEngine;
	using Utilities;

	public class PlayerController : MonoBehaviour
	{
		private PlayerProgressInfo _playerProgress;
		private Rigidbody _rigidbody;

		public float Speed = 1;
		public float Tilt = 1;

		private void Awake()
		{
			this._rigidbody = this.GetComponent<Rigidbody>();
			this._playerProgress = Serializer.Load<PlayerProgressInfo>() ?? new PlayerProgressInfo();
		}

		private void FixedUpdate()
		{
			float horizontalMovement = Input.GetAxis("Horizontal");
			float verticalMovement = Input.GetAxis("Vertical");

			this._rigidbody.velocity = new Vector3(horizontalMovement, 0f, verticalMovement) * this.Speed;

			this._rigidbody.position = new Vector3(
				Mathf.Clamp(
					this._rigidbody.position.x,
					-(ScreenController.Dimensions.x - 1),
					ScreenController.Dimensions.x - 1),
				0f,
				Mathf.Clamp(this._rigidbody.position.z, -3.5f, ScreenController.Dimensions.z - 1));

			this._rigidbody.rotation = Quaternion.Euler(0f, 0f, this._rigidbody.velocity.x * this.Tilt * -1);
		}

		// // TODO: Android
		// private void FixedUpdate()
		// {
		// 	this._rigidbody.velocity = Input.acceleration * this.Speed;
		//
		// 	this._rigidbody.position = new Vector3(
		// 		Mathf.Clamp(
		// 			this._rigidbody.position.x,
		// 			-(ScreenController.Dimensions.x - 1),
		// 			ScreenController.Dimensions.x - 1),
		// 		0f,
		// 		Mathf.Clamp(this._rigidbody.position.z, -3.5f, ScreenController.Dimensions.z - 1));
		//
		// 	this._rigidbody.rotation = Quaternion.Euler(0f, 0f, this._rigidbody.velocity.x * this.Tilt * -1);
		// }
	}
}