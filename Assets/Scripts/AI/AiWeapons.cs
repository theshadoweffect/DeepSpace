using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWeapons : MonoBehaviour {

    //DAMAGE AND RANGE AND SPEED
    public double damage = 10.0;
    public float maxRange = 1000.0F;
    public float speed = 1000.0F;
    //RELOAD SPEED
    public float ReloadSpeed = 1.0F;
    private float timeStamp;
    //SCRIPTS AND TARGETS
    GameObject target;
    GameObject prevTarget;
    HealthAndDeduction targethealth;
    MissileScript missile;
    // BulletScript bullet;
   

    //PROJECTILES
    public GameObject projectile;// holds projectile for missile and turret based firing mechanisms
    private GameObject clone;
    //TYPE VARIABLES
    public PlayerFireWeapon.weaponType typeWeapon = PlayerFireWeapon.weaponType.laser; //for firing system
    public PlayerFireWeapon.damageType typeDamage = PlayerFireWeapon.damageType.thermal; //for multiplier

    // START
    void start()
    {
        timeStamp = Time.time + ReloadSpeed;

    }

    // Update is called once per frame
 public void Fire() {

        if (timeStamp <= Time.time) {
            timeStamp = Time.time + ReloadSpeed;//Reloads weapon
            
            //LASER HITSCAN
            if (typeWeapon == PlayerFireWeapon.weaponType.laser)
            {
                Laser();
            }
            //==============================================================================
            //MISSILE SPAWN
            if (typeWeapon == PlayerFireWeapon.weaponType.missile)
            {
                Missile();
                
            }
            if (typeWeapon == PlayerFireWeapon.weaponType.turret)
            {
                Turret();
            }


        }
    }
    //===================================================================================================
    //TURRET FIRE
    //===================================================================================================
    void Turret() {
        //fires a cloned projectile
        //     print("Cannon Fire!");

        Vector3 offset = new Vector3(0, 0, 0);
        Vector3 bulletTrajectory = new Vector3(0, 0, speed);
        clone = Instantiate(projectile, transform.position + offset, transform.rotation) as GameObject;
        //     bullet = (BulletScript)clone.GetComponent(typeof(BulletScript));

        clone.GetComponent<Rigidbody>().AddRelativeForce(bulletTrajectory);
    }
    //================================================================================================
    //MISSILE FIRE
    //================================================================================================
    void Missile() {
        //spawns a clone projectile with a target location
        Vector3 dir = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        //NEW TARGET
        if (Physics.Raycast(transform.position, dir, out hit, maxRange))
        {
            Vector3 offset = new Vector3(0, 0, 0);
            clone = Instantiate(projectile, transform.position + offset, transform.rotation) as GameObject;
            target = hit.collider.gameObject;//assigns target
            missile = (MissileScript)clone.GetComponent(typeof(MissileScript));
            missile.SetTarget(target);
            prevTarget = target;
            Debug.DrawLine(gameObject.transform.position, hit.point, Color.red, 1.0F); 
        }
        //CURRENT TARGET
        else if (target != null)
        {// if target not detected but target not null fire
            Vector3 offset = new Vector3(0, 0, 0);
            clone = Instantiate(projectile, transform.position + offset, transform.rotation) as GameObject;
            missile = (MissileScript)clone.GetComponent(typeof(MissileScript));
            missile.SetTarget(prevTarget);
        }
    }
    //================================================================================================
    //LASER FIRE
    //================================================================================================
    void Laser() {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRange))
        {


            // Debug.Log(hit.transform.name + " found!");// declares if object was found
            //  print("Found a target game object distance of " + hit.distance);//Declares target distance

            

            target = hit.collider.gameObject;//assigns target
            targethealth = (HealthAndDeduction)target.GetComponent(typeof(HealthAndDeduction));
            targethealth.DamageCalc(typeDamage, damage);

            // print("damaging target");//Declares when Target us damaged
            //   gameObject.SendMessage("DamageCalc", typeDamage, damage);
        }
        Debug.DrawLine(gameObject.transform.position, hit.point, Color.red, 1.0F);// draws firingline to target
    }
    //================================================================================================
    //================================================================================================
}
