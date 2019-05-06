#region

using UnityEngine;

#endregion

public class BackgroundScroller : MonoBehaviour
{
	private Vector3 _startPosition;
	public float BackgroundLength;
	public float ScrollSpeed;

	private void Start() => this._startPosition = this.transform.position;

	private void Update()
	{
		float newPosition = Mathf.Repeat(Time.time * this.ScrollSpeed, this.BackgroundLength);
		this.transform.position = this._startPosition + Vector3.forward * newPosition;
	}
}