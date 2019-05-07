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

				rotation = Quaternion.Euler(
					0,
					180
					+ Mathf.Atan((playerPosition.x - rigidbodyPosition.x) / (playerPosition.z - rigidbodyPosition.z))
					* Mathf.Rad2Deg,
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