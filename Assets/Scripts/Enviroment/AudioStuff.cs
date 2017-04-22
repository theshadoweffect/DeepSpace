using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStuff : MonoBehaviour {


    public AudioClip[] audioClip;
    private int soundy = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            PlaySound(soundy);
        }

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            soundy = 0;
        }
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            soundy = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            soundy = 2;
        }

     }

    void PlaySound(int clip)
    {
        GetComponent<AudioSource>().clip = audioClip[clip];
        GetComponent<AudioSource>().Play();
    }


}
