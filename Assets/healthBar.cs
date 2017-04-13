using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image=UnityEngine.UI.Image;

public class healthBar : MonoBehaviour {
    Image HealthBar;
    float tmpHealth=1;
	// Use this for initialization
	void Start () {
        HealthBar=GameObject.Find("HealthBar").transform.FindChild("Foreground").GetComponent <Image>();
	}
	
	// Update is called once per frame
	void Update () {
        HealthBar.fillAmount = tmpHealth;
	}
}
