using UnityEngine;

public class BackgroundController : MonoBehaviour
{
	private float _backgroundLength;
	private Vector3 _startPosition;

	public float ScrollSpeed;

	private void Start()
	{
		Transform backgroundTransform = this.transform;

		Vector3 scale = new Vector3(ScreenController.Dimensions.x * 2, ScreenController.Dimensions.x * 4, 0);
		backgroundTransform.localScale = scale;

		this._backgroundLength = backgroundTransform.localScale.y;
		this._startPosition = backgroundTransform.position;
	}

	private void Update()
	{
		float newPosition = Mathf.Repeat(Time.time * this.ScrollSpeed, this._backgroundLength);
		this.transform.position = this._startPosition + Vector3.forward * newPosition;
	}
}