﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	//variables for the static camera
    public List<GameObject> Targets;

    private int cameraPos = 0;

    private Transform obj;

    public float smoothspeed = 1f;

    public Vector3 offset;

	public GameObject player;

	public MenuController mc;

	public PlayerSettings ps;

	public HighscoreController hs;

	//variables for the moveable camera
	private const float minAngleY = 0.0f;
	private const float maxAngleY = 50.0f;



	public bool onCharacter = false;

	//private Camera cam;

	private float distance = 5.0f;
	private float currentX = 0.0f;
	private float currentY = 5.0f;

	public bool gameStarted = false;

	public bool highscore  = false;



	private void Start()
	{
		

	}

	private void Update()
	{
		if (Input.GetMouseButton (1) && gameStarted) {
			MoveCamera ();	
		}
		if (mc.healthBar.fillAmount == 0 && highscore == false) 
		{
			gameStarted = false;
			ChangeCam ();
			player.GetComponent<PlayerController> ().enabled = false;
			highscore = true;
			hs.LoadPlayerData ();
			hs.SubmitNewScore ();
			mc.HighScore ();

		}
	}


	//this then applies the rotation to the camera
	private void LateUpdate()
	{
		if (onCharacter && gameStarted)
		{
			Vector3 dir = new Vector3 (0, 0, -distance);
			Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
			transform.position = player.transform.position + rotation * dir;
			transform.LookAt (player.transform);
		}		

	}


    private void FixedUpdate()
    {
        //switch case that smooths the camera movement and ensures it looks at the correct object
        switch (cameraPos)
        {
		case 0:

			offset = new Vector3 (-5 ,0, 0);

			CameraTarget ();
			Vector3 targetpos = obj.position + offset;
			Vector3 smoothedPos = Vector3.Lerp (transform.position, targetpos, smoothspeed);
			transform.position = smoothedPos;
			transform.LookAt (obj);
           
                break;
		case 1:

			offset = new Vector3 (0,5,-5);

			CameraTarget ();
			targetpos = obj.position + offset;
			smoothedPos = Vector3.Lerp (transform.position, targetpos, smoothspeed);
			transform.position = smoothedPos;
			transform.LookAt (obj);




			break;
		case 2:
			
			obj = player.transform;
			onCharacter = true;
			EnableCharacterMovement ();
			break;

		case 3:

			offset = new Vector3 (0, 0, 5);

			CameraTarget ();
			targetpos = obj.position + offset;
			smoothedPos = Vector3.Lerp (transform.position, targetpos, smoothspeed);
			transform.position = smoothedPos;
			transform.LookAt (obj);

			break;


            default:
                Debug.Log("Camera Movments Error");
                break;
 

        }



    }

    //means that the camera knows which target to look at
    private void CameraTarget()
    {
        obj = Targets[cameraPos].transform;
    }

    //this increases camerapos by one meaning that the camera switches
    public void ChangeCam()
    {
        cameraPos += 1;
		Debug.Log (cameraPos);
        
    }

	private void EnableCharacterMovement()
	{
		
		player.GetComponent<PlayerController> ().enabled = true;

	}


	//this gets the players mouse and clamps the camera with a max and min angle
	private void MoveCamera()
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

	public void CharacterScreen()
	{
		cameraPos = 1;
	}


	public void OptionsScreen ()
	{
		cameraPos = 3;
	}

	public void Back()
	{
		cameraPos = 0;
	}

}
