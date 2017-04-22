using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireWeapon : MonoBehaviour
{
    //DAMAGE AND RANGE AND SPEED
    public double damage = 10.0;
    public float maxRange = 1000.0F;
    public float speed = 1000.0F;
	public AudioClip fireClip;
	public AudioClip failClip;
    //RELOAD SPEED
    public float ReloadSpeed = 1.0F;
    private float timeStamp;
    //SCRIPTS AND TARGETS
    GameObject target;
    GameObject prevTarget;
    HealthAndDeduction targethealth;
    MissileScript missile;
    // BulletScript bullet;
    //ENUM OPERATORS
    //                          0        1          2
    public enum damageType { kenetic, thermal, concusive }
    public enum weaponType { missile, laser, turret }

    //PROJECTILES
    public GameObject projectile;// holds projectile for missile and turret based firing mechanisms
    private GameObject clone;
    //TYPE VARIABLES
    public weaponType typeWeapon = weaponType.laser; //for firing system
    public damageType typeDamage = damageType.thermal; //for multiplier

    // START
    void start()
    {
        timeStamp = Time.time + ReloadSpeed;

    }
    //UPDATE
    void Update()
    {
		if (timeStamp <= Time.time) {//checks reload speed
			if (Input.GetButton ("Fire1")) {
				Fire ();
				timeStamp = Time.time + ReloadSpeed;//Reloads weapon
			}
		} else {
			if(Input.GetButtonDown("Fire1")){
				//PlaySound (failClip);
			}
		
		}
    }
    //FIRING MECHANISM
    private void Fire()
    {
        RaycastHit hit;
        //LASER HITSCAN
        if (typeWeapon == weaponType.laser)
        {
			projectile.SetActive(false);
			PlaySound (fireClip);
			projectile.SetActive(true);
            Vector3 dir = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, dir, out hit, maxRange))
            {
				

               // Debug.Log(hit.transform.name + " found!");// declares if object was found
              //  print("Found a target game object distance of " + hit.distance);//Declares target distance

                Debug.DrawLine(gameObject.transform.position, hit.point, Color.red, 1.0F);// draws firingline to target

                target = hit.collider.gameObject;//assigns target
                targethealth = (HealthAndDeduction)target.GetComponent(typeof(HealthAndDeduction));
                targethealth.DamageCalc(typeDamage, damage);

               // print("damaging target");//Declares when Target us damaged
                //   gameObject.SendMessage("DamageCalc", typeDamage, damage);
            }
        }
//==============================================================================
        //MISSILE SPAWN
        if (typeWeapon == weaponType.missile)
        { //spawns a clone projectile with a target location
            Vector3 dir = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, dir, out hit, maxRange))//If target detected then fire
            {
				PlaySound (fireClip);
                Vector3 offset = new Vector3(0, 0, 0);
                clone = Instantiate(projectile, transform.position + offset, transform.rotation) as GameObject;
                target = hit.collider.gameObject;//assigns target
                missile = (MissileScript)clone.GetComponent(typeof(MissileScript));
                missile.SetTarget(target);
                prevTarget = target;
                Debug.DrawLine(gameObject.transform.position, hit.point, Color.red, 1.0F);// draws firingline to target
            //    Debug.Log(hit.transform.name + " found!");// declares if object was found
               // print("Found a target game object distance of " + hit.distance);//Declares target distance
             //   print("firing missile");//Declares when Target us damaged
            }
            else if (target != null) {
				// if target not detected but target not null fire
				PlaySound (fireClip);
                Vector3 offset = new Vector3(0, 0, 0);
                clone = Instantiate(projectile, transform.position + offset, transform.rotation) as GameObject;
                missile = (MissileScript)clone.GetComponent(typeof(MissileScript));
                missile.SetTarget(prevTarget);
            }
//==============================================================
        }//BULLET SPAWN
        if (typeWeapon == weaponType.turret)
        {//fires a cloned projectile
       //     print("Cannon Fire!");
			PlaySound(fireClip);
            Vector3 offset = new Vector3(0, 0, 0);
            Vector3 bulletTrajectory = new Vector3(0, 0, speed);
            clone = Instantiate(projectile, transform.position + offset, transform.rotation) as GameObject;
            //     bullet = (BulletScript)clone.GetComponent(typeof(BulletScript));

            clone.GetComponent<Rigidbody>().AddRelativeForce(bulletTrajectory);
        }

    }
	void PlaySound(AudioClip audioClip)
	{
		GetComponent<AudioSource>().clip = audioClip;
		GetComponent<AudioSource>().Play();
	}
}

