namespace SpaceShooter.MovementControllers
{
	using UnityEngine;

	public class RotationTowardsPlayerController : MonoBehaviour
	{
		private readonly Quaternion _finalRotation = Quaternion.Euler(0, 180, 0);
		private Transform _player;
		private Rigidbody _rigidbody;

		public float FinalRotationSpeed;

		private void Awake()
		{
			this._player = GameObject.FindWithTag("Player")
				?.transform;

			this._rigidbody = this.GetComponent<Rigidbody>();
		}

		private void Start() => this.transform.rotation = this.CalculateRotation();

		private void FixedUpdate() => this._rigidbody.MoveRotation(this.CalculateRotation());

		private Quaternion CalculateRotation()
		{
			Quaternion rotation;

			if (GameController.PlayerIsAlive)
			{
				Vector3 playerPosition = this._player.position;
				Vector3 rigidbodyPosition = this._rigidbody.position;
				
				rotation = Quaternion.LookRotation(playerPosition - rigidbodyPosition);

				// Maths:
				// float yRotation =
				// 	Mathf.Atan((rigidbodyPosition.x - playerPosition.x) / (rigidbodyPosition.z - playerPosition.z))
				// 	* Mathf.Rad2Deg;
				//
				// rotation = Quaternion.Euler(0, playerPosition.z > rigidbodyPosition.z ? yRotation : 180 + yRotation, 0);
			}
			else
				rotation = Quaternion.RotateTowards(
					this._rigidbody.rotation,
					this._finalRotation,
					this.FinalRotationSpeed);

			return rotation;
		}
	}
}