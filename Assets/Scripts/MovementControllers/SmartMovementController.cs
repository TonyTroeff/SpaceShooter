#region

using UnityEngine;

#endregion

namespace MovementControllers
{
	public class SmartMovementController : MonoBehaviour
	{
		private Transform _player;
		private Rigidbody _rigidbody;
		
		public float Speed = 1;

		private void Awake()
		{
			this._player = GameObject.FindWithTag("Player")
				.transform;
			this._rigidbody = this.GetComponent<Rigidbody>();
		}

		private void Start()
		{
			Vector3 rigidbodyPosition = this._rigidbody.position;
			this._rigidbody.velocity = (rigidbodyPosition
					- Vector3.MoveTowards(rigidbodyPosition, this._player.position, 1))
				* this.Speed;
		}
	}
}