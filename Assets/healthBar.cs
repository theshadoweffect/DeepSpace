using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image=UnityEngine.UI.Image;

public class healthBar : MonoBehaviour {
    Image HealthBar;
    float tmpHealth;
	public GameObject playerShip;
	// Use this for initialization
	void Start () {
        HealthBar=GameObject.Find("HealthBar").transform.FindChild("Foreground").GetComponent <Image>();
	}
	
	// Update is called once per frame
	void Update () {
		HealthAndDeduction healthGet = (HealthAndDeduction)playerShip.GetComponent<HealthAndDeduction> ();
		tmpHealth = (float)healthGet.GetHealthPercent ();
		HealthBar.fillAmount = tmpHealth;
	}
}
