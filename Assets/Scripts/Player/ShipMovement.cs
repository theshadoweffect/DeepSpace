using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    //Acceleration Speeds
    public float Xacl = 1.0F;
    public float Yacl = 1.0F;
    public float Zacl = 1.0F;
    private float xspeed;
    private float yspeed;
    private float zspeed;

    // Use this for initialization
    void Start()
    {
        xspeed = 0;
        yspeed = 0;
        zspeed = 0;
    }

    // Update is called once per frame
    void Update()
    {                   
        xspeed = 0;
        yspeed = 0;
        zspeed = 0;
        //SPEED MODIFIER
        if (Input.GetKey(KeyCode.W))
        {
            xspeed =Xacl;
        }
        if (Input.GetKey(KeyCode.S))
        {
            xspeed = -Xacl;
        }
        if (Input.GetKey(KeyCode.A))
        {
            yspeed =-Yacl;
        }
        if (Input.GetKey(KeyCode.D))
        {
            yspeed = Yacl;
        }
        if (Input.GetKey(KeyCode.C))
        {
            zspeed = -Zacl;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            zspeed = Zacl;
        }
        //MOVE OBJECT
        Vector3 movDir = new Vector3(yspeed, zspeed, xspeed);
        GetComponent<Rigidbody>().AddRelativeForce(movDir);
        
        if (Input.GetKey(KeyCode.Z))
        {//stops all movement 
            

            GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }
}
