using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDeduction : MonoBehaviour {
    private enum damageType { kenetic, thermal, concusive }
    private enum ResistanceType {armour, shield, PDS }

    damageType incomDamage;
    ResistanceType resist;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
