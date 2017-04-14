using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionScript : MonoBehaviour {
    public GameObject[] Buildables;
    private float[] timestamp;
    public float[] buildtime;
    private int arrayLength;
    private GameObject clone;
    private int selector;
	// Use this for initialization
	void Start () {
        arrayLength = Buildables.Length;
        clone = Buildables[0];
        selector = 0;
        print(arrayLength);
        timestamp = new float[arrayLength];
        for (int ii = 0; ii < arrayLength; ii++) {
            timestamp[ii] = Time.time + buildtime[ii];
            print(timestamp);
        }
	}

    // Update is called once per frame
    void Update()
    {

        //modify Selector
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            selector = 9;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selector = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selector = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selector = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selector = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selector = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selector = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selector = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            selector = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            selector = 8;
        }

        //Selection check
        if (selector >= arrayLength)
        {
            selector = arrayLength - 1;
        }//Constructor access
        if (timestamp[selector] <= Time.time) { 
            if (Input.GetButton("Fire1"))
             {
                Construct();
                timestamp[selector] = Time.time + buildtime[selector];
             }
         }
    }
    void Construct() {
                                    //x y z
        Vector3 offset = new Vector3(0, -20, 0);
        clone = Instantiate(Buildables[selector], transform.position + offset, transform.rotation) as GameObject;

    }


}
