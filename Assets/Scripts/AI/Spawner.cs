using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] Spawnables;
    public float wavetimer = 100.0f;//seconds
    public float spawnRange = 50f;
    public int wave = 10;
    public int[] spawncount;

    private float timeStamp;
    private int curwave; 
    private int spawnLen;
    
	// Use this for initialization
	void Start () {
        timeStamp = Time.time;
        curwave = 0;
        spawnLen = Spawnables.Length;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject clone;
		if(timeStamp <= Time.time)
        {
            timeStamp = wavetimer + Time.time;
            if(curwave < wave)
            {
                curwave++;
                for(int ii = 0; ii < spawnLen; ii++)
                {
                    for (int j = 0; j < (spawncount[ii] * curwave); j++) {
                     
                        Vector3 offset = new Vector3(Random.Range(-spawnRange, spawnRange),
                                                     Random.Range(-spawnRange, spawnRange),
                                                     Random.Range(-spawnRange, spawnRange));
                       clone=Instantiate(Spawnables[ii], transform.position + offset, transform.rotation) as GameObject;



                    }
                }
            }
        }
	}
}
