using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireWeapon : MonoBehaviour {
    //DAMAGE AND RANGE AND SPEED
    public double damage = 10.0;
    public float maxRange = 1000.0F;
    public float speed = 1000.0F;
    //SCRIPTS AND TARGETS
    GameObject target;
    HealthAndDeduction targethealth;
    MissileScript missile;
    //ENUM OPERATORS
    //                          0        1          2
    public enum damageType {kenetic, thermal, concusive}
    public enum weaponType {missile, laser,  turret}
   
    //PROJECTILES
    public GameObject projectile;// holds projectile for missile and turret based firing mechanisms
    private GameObject clone;
    //TYPE VARIABLES
   public weaponType typeWeapon = weaponType.laser; //for firing system
   public damageType typeDamage = damageType.thermal; //for multiplier
    
	// START

	//UPDATE
	void Update () {
        
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
	}
    //FIRING MECHANISM
    private void Fire() {
        RaycastHit hit;
        //LASER HITSCAN
        if (typeWeapon == weaponType.laser)
        {
            Vector3 dir = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, dir, out hit, maxRange))
            {
                
                
                Debug.Log(hit.transform.name + " found!");// declares if object was found
                print("Found a target game object distance of " + hit.distance);//Declares target distance

                Debug.DrawLine(gameObject.transform.position, hit.point, Color.red, 1.0F);// draws firingline to target

                target = hit.collider.gameObject;//assigns target
                targethealth = (HealthAndDeduction) target.GetComponent(typeof(HealthAndDeduction));
                targethealth.DamageCalc(typeDamage, damage);

                print("damaging target");//Declares when Target us damaged
                //   gameObject.SendMessage("DamageCalc", typeDamage, damage);
            }
        }
        //MISSILE SPAWN
        if (typeWeapon == weaponType.missile)
        { //spawns a clone projectile with a target location
            Vector3 dir = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, dir, out hit, maxRange))
            {
                
                clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                target = hit.collider.gameObject;//assigns target
                missile = (MissileScript) clone.GetComponent(typeof(MissileScript));
                missile.SetTarget(target);
                Debug.Log(hit.transform.name + " found!");// declares if object was found
                print("Found a target game object distance of " + hit.distance);//Declares target distance
                print("firing missile");//Declares when Target us damaged
            }
        }//BULLET SPAWN
        if (typeWeapon == weaponType.turret)
        {//fires a cloned projectile
            clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody>().AddRelativeForce(transform.TransformDirection(new Vector3(0, 0, speed)));
        }
    }

}

