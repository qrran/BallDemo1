using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
	[SerializeField]
	private float movingSpeedPerSecond = 5f;

	[SerializeField] GameObject ball;

	//float screenLeft, screenRight, screenTop, screenBottom;
	float colliderHalfWidth, colliderHalfHeight;

	// Start is called before the first frame update
	void Start()
	{
		ScreenUtils.Initialize();

		CircleCollider2D collider = GetComponent<CircleCollider2D>();
		Vector3 circleColliderDim = collider.bounds.max - collider.bounds.min;
		colliderHalfWidth = circleColliderDim.x / 2;
		colliderHalfHeight = circleColliderDim.y / 2;

		//Debug.Log(screenLeft + " " + screenRight + " " + screenTop + " " + screenBottom
		//	+ " " + colliderHalfWidth + " " + colliderHalfHeight);
	}

	// Update is called once per frame
	void Update()
	{
		MoveBall();
		KeepInScreen();

	}

	void MoveBall()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		//transform.position.x, transform.position.y, 
		//position.x += horizontalInput
		float x = transform.position.x + horizontalInput * movingSpeedPerSecond * Time.deltaTime;
		//transform.position = new Vector3(x, transform.position.y, transform.position.z);

		//vertical
		float verticalInput = Input.GetAxis("Vertical");

		float y = transform.position.y + verticalInput * movingSpeedPerSecond * Time.deltaTime;
		transform.position = new Vector3(x, y, transform.position.z);
	}

	void KeepInScreen()
	{
		//if x less than left, +
		Vector3 position = transform.position;
		if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft)
		{
			position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
			transform.position = position;
			Debug.Log("Left" + transform.position);

		}
		// if y higher than top, -
		if (position.y + colliderHalfHeight > ScreenUtils.ScreenTop)
		{
			position.y = ScreenUtils.ScreenTop - colliderHalfHeight;
			transform.position = position;
			Debug.Log("Top" + transform.position);

		}
		//if x bigger than right, -
		if (position.x + colliderHalfHeight > ScreenUtils.ScreenRight)
		{
			position.x = ScreenUtils.ScreenRight - colliderHalfHeight;
			transform.position = position;
			Debug.Log("Right" + transform.position);

		}
		//if y less than bottom, + for original position
		if (position.y - colliderHalfHeight < ScreenUtils.ScreenBottom)
		{
			position.y = ScreenUtils.ScreenBottom + colliderHalfHeight;
			transform.position = position;
			Debug.Log("Bottom" + transform.position);

		}

	}
	//void OnCollisionEnter2D(Collision2D collision)
	//{
	//	// 2.
	//	Debug.Log("Bang");
	//	// 3.
	//	Debug.Log(++count);
	//	// 4.
	//	if(count == 20)
	//	{
	//		Destroy(gameObject);
	//		Debug.Log("Ball is destroyed.");
	//		Debug.Log("Game Over!");
	//		UnityEditor.EditorApplication.isPlaying = false;
	//	}
	//}
}
