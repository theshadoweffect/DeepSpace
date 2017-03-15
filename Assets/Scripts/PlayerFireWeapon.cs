using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireWeapon : MonoBehaviour {
    //DAMAGE AND RANGE AND SPEED
    public float damage = 10.0F;
    public float maxRange = 1000.0F;
    public float speed = 1000.0F;
    //ENUM OPERATORS
    //                          0        1          2
    private enum damageType {kenetic, thermal, concusive}
    private enum weaponType {missile, laser,  turret}
    //SELECTORS
    public int damageSelector = 0;// selects damage
    public int weaponSelector = 0;// selects firing mechanism
    //PROJECTILES
    public GameObject projectile;// holds projectile for missile and turret based firing mechanisms
    private GameObject clone;
    //TYPE VARIABLES
    weaponType typeWeapon; //for firing system
    damageType typeDamage; //for multiplier
	// START
	void Start () {//initializes damage type and weapon type for hitscan, tracking, projectile
        switch (damageSelector)
        {
            case 0:
                typeDamage = damageType.kenetic;
                break;
            case 1:
                typeDamage = damageType.thermal;
                break;
            case 2:
                typeDamage = damageType.concusive;
                break;
        }
        switch (weaponSelector)
        {
            case 0:
                typeWeapon = weaponType.missile;
                break;
            case 1:
                typeWeapon = weaponType.laser;
                break;
            case 2:
                typeWeapon = weaponType.turret;
                break;
        }
    }
	
	//UPDATE
	void Update () {
        if (Input.GetMouseButton(0)) {
            if (typeWeapon == weaponType.laser) {
                    
            }
            if (typeWeapon == weaponType.missile) { //spawns a clone projectile with a target location
                clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                
            }
            if (typeWeapon == weaponType.turret) {//fires a cloned projectile
                clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * speed);
            }
        }
	}
}
