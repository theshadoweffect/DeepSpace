using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image=UnityEngine.UI.Image;

public class shieldBarScript : MonoBehaviour {
	Image HealthBar;
	float tmpHealth;
	public GameObject playerShip;
	// Use this for initialization
	void Start () {
		HealthBar=GameObject.Find("HealthBar").transform.FindChild("shieldfore").GetComponent <Image>();
	}

	// Update is called once per frame
	void Update () {
		HealthAndDeduction healthGet = (HealthAndDeduction)playerShip.GetComponent<HealthAndDeduction> ();
		tmpHealth = (float)healthGet.GetShieldPercent ();
		HealthBar.fillAmount = tmpHealth;
	}
}
