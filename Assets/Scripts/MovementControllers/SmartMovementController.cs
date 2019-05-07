using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace MovementControllers
{
	public class SmartMovementController : MonoBehaviour
	{
		public float Speed = 1;

		private Transform _player;
		private Rigidbody _rigidbody;

		private void Awake()
		{
			this._player = GameObject.FindWithTag("Player")
				?.transform;
			this._rigidbody = this.GetComponent<Rigidbody>();
		}

		private void Start()
		{
			Vector3 velocity = this._player == null
				? Vector3.forward
				: new Vector3(
					Mathf.MoveTowards(this._rigidbody.position.x, this._player.position.x, 1),
					0,
					Mathf.MoveTowards(this._rigidbody.position.z, this._player.position.z, 1));

			this.GetComponent<Rigidbody>()
				.velocity = velocity * this.Speed;
		}
	}
}