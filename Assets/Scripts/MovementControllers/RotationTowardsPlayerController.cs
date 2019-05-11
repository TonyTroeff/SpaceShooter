#region

using UnityEngine;

#endregion

namespace MovementControllers
{
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

		private void FixedUpdate()
		{
			Quaternion rotation;

			if (GameController.PlayerIsAlive)
			{
				Vector3 playerPosition = this._player.position;
				Vector3 rigidbodyPosition = this._rigidbody.position;

				float yRotation =
					Mathf.Atan((rigidbodyPosition.x - playerPosition.x) / (rigidbodyPosition.z - playerPosition.z))
					* Mathf.Rad2Deg;
				
				rotation = Quaternion.Euler(
					0,
					playerPosition.z > rigidbodyPosition.z
						? yRotation
						: 180 + yRotation,
					0);
			}
			else
			{
				Vector3 rigidbodyRotation = this._rigidbody.rotation.eulerAngles;

				rotation = rigidbodyRotation == this._finalRotation.eulerAngles
					? this._finalRotation
					: Quaternion.Euler(
						0,
						rigidbodyRotation.y - (rigidbodyRotation.y - 180) * this.FinalRotationSpeed,
						0);
			}

			this._rigidbody.MoveRotation(rotation);
		}
	}
}