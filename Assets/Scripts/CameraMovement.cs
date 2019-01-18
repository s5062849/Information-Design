using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public List<GameObject> Targets;

    private int cameraPos = 0;

    private Transform obj;

    public float smoothspeed = 1f;

    public Vector3 offset;

	public GameObject player;



    private void FixedUpdate()
    {
        //switch case that smooths the camera movement and ensures it looks at the correct object
        switch (cameraPos)
        {
		case 0:

			offset.x = -5;

			CameraTarget ();
			Vector3 targetpos = obj.position + offset;
			Vector3 smoothedPos = Vector3.Lerp (transform.position, targetpos, smoothspeed);
			transform.position = smoothedPos;
			transform.LookAt (obj);
           
                break;
		case 1:

			offset.x = 0;
			offset.z = -3;
			offset.y = 3;

			CameraTarget ();
			targetpos = obj.position + offset;
			smoothedPos = Vector3.Lerp (transform.position, targetpos, smoothspeed);
			transform.position = smoothedPos;
			transform.LookAt (obj);
			EnableCharacterMovement ();




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
        Debug.Log(cameraPos);
    }

	private void EnableCharacterMovement()
	{
		
		player.GetComponent<PlayerController> ().enabled = true;

	}
}
