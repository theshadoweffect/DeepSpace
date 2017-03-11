using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

	//Acceleration Speeds
	public float foreacl = 10;
	public float strafacl = 10;
	public float jumpacl = 10;

	// Use this for initialization

	// Update is called once per frame
	void Update () {                    //(x, y, z)
		//Accelerates object based on w,a,s,d
		Vector3 movDirection = new Vector3 (strafacl * Input.GetAxis ("Horizontal"), jumpacl * Input.GetAxis ("Jump"), foreacl * Input.GetAxis ("Vertical"));// foreward back
		this.GetComponent<Rigidbody> ().AddForce (movDirection);
		//===============================
		if (Input.GetKeyDown (KeyCode.Z)) {//stops all movement 
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (0,0,0);
		}
	}
}
