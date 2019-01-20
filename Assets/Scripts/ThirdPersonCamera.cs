using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour 
{

	private const float minAngleY = 0.0f;
	private const float maxAngleY = 50.0f;

	public Transform lookAt;
	public Transform camTransform;

	private Camera cam;

	private float distance = 5.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;

	private bool gameStarted = false;

	public Vector3 offset = new Vector3 (0, 0, 0);

	private void Start()
	{
		cam = Camera.main;
		camTransform = transform;
	}

	private void Update()
	{
		if (Input.GetMouseButton (1) && gameStarted)
		{
			moveCamera ();	
		}


	}
		
	//this then applies the rotation to the camera
	private void LateUpdate()
	{
		if (gameStarted) 
		{
			Vector3 dir = new Vector3 (0, 0, -distance) + offset;
			Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
			camTransform.position = lookAt.position + rotation * dir;
			camTransform.LookAt (lookAt.position);
		}

	}


	private void startPos()
	{
		
	}



	//this gets the players mouse and clamps the camera with a max and min angle
	private void moveCamera()
	{
		currentX -= Input.GetAxis ("Mouse X");
		currentY -= Input.GetAxis ("Mouse Y");
		currentY = Mathf.Clamp (currentY, minAngleY, maxAngleY);

		currentY = Mathf.Clamp (currentY, minAngleY, maxAngleY);
	}

	public void setGameStarted(bool gameStarted)
	{
		this.gameStarted = gameStarted;
	}
}
