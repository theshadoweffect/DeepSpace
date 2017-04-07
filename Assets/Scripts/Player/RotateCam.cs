using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour {
    //Rotation Speeds
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public float barrelSpeed = 2.0F;
    public bool rotlimit = true;// This is a meta statement if true then an object will only rotate when alt is pressed down if false then an object will rotate if alt is up
    // Use this for initialization

    // the function is that this code is attached to two objects a parent child with opposite truth statements
    //Thus when the player presses alt the camera will rotate around the parent and when alt is released the parent and camera rotate together
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            rotlimit = !rotlimit;
        }
            
            if (rotlimit == true)
            {

                float h = horizontalSpeed * Input.GetAxis("Mouse X");
                float v = verticalSpeed * Input.GetAxis("Mouse Y");
                float b = 0;
                if (Input.GetKey(KeyCode.E))
                {
                    b = barrelSpeed;

                }
                if (Input.GetKey(KeyCode.Q))
                {
                    b = -barrelSpeed;
            }
                transform.Rotate(v, h, b);
              
            }

        if (Input.GetKey(KeyCode.Z))
        {//stops all movement 
           
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }//End Update
}
