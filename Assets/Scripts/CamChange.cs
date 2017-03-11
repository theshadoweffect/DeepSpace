using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour {

	public Camera camShip;
	public Camera camMap;
	public GameObject playerShip;
	public GameObject playerMapMove;
	private bool mapStat;
	private bool shipStat;
	// Use this for initialization
	void Start () { //sets systems standard

		mapStat = false;
		shipStat = true;
		playerMapMove.SetActive (mapStat);
		playerShip.SetActive (shipStat);
		camShip.enabled = true;
		camMap.enabled = false;
	
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M)){//swaps cameras and disables none usable objects.
			shipStat = !shipStat;//changes set active statements
			mapStat = !mapStat;//changes set active statements
			camShip.enabled = !camShip.enabled;
			camMap.enabled = !camMap.enabled;
			playerMapMove.SetActive (mapStat);
			playerShip.SetActive (shipStat);

		}
	}
}
