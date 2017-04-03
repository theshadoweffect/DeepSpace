using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
    
    public GameObject[] CannonArr;
    public GameObject[] MissileArr;
    public GameObject[] LaserArr;
    int numCannons;
    int numMissiles;
    public int numLasers;
    
 
    void Start() {//CANNONS ARE AUTOMATICALLY SELECTED FIRST
        numCannons = CannonArr.Length;
        numMissiles = MissileArr.Length;
        numLasers = LaserArr.Length;
        for (int ii = 0; ii < numCannons; ii++)
        {
            CannonArr[ii].SetActive(true);
        }
        for (int ii = 0; ii < numMissiles; ii++)
        {
            MissileArr[ii].SetActive(false);
        }
        for (int ii = 0; ii < numLasers; ii++)
        {
            LaserArr[ii].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {//switches active weapons
        //CANNON SELECT
        if (Input.GetKeyDown(KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.Keypad1)) {
            for (int ii = 0; ii < numCannons; ii++)
            {
                CannonArr[ii].SetActive(true);
            }
            for (int ii = 0; ii < numMissiles; ii++)
            {
                MissileArr[ii].SetActive(false);
            }
            for (int ii = 0; ii < numLasers; ii++)
            {
                LaserArr[ii].SetActive(false);
            }
        }//MISSILE SELECT
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            for (int ii = 0; ii < numCannons; ii++)
            {
                CannonArr[ii].SetActive(false);
            }
            for (int ii = 0; ii < numMissiles; ii++)
            {
                MissileArr[ii].SetActive(true);
            }
            for (int ii = 0; ii < numLasers; ii++)
            {
                LaserArr[ii].SetActive(false);
            }
        }//LASER SELECT
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            for (int ii = 0; ii < numCannons; ii++)
            {
                CannonArr[ii].SetActive(false);
            }
            for (int ii = 0; ii < numMissiles; ii++)
            {
                MissileArr[ii].SetActive(false);
            }
            for (int ii = 0; ii < numLasers; ii++)
            {
                LaserArr[ii].SetActive(true);
            }
        }
    }
}
