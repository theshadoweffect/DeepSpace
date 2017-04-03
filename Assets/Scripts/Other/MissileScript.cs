using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {
    GameObject target;
   
    HealthAndDeduction targethealth;
    public PlayerFireWeapon.damageType incomDamage = PlayerFireWeapon.damageType.kenetic;
    public  double missileDamage;
    public float speed = 100.0F;
    public float armingDelay = 1.0F;
    private float armStamp;
    // Update is called once per frame
    void Start()
    {
        
        armStamp = Time.time + armingDelay;
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }
    public void SetTarget(GameObject newTarget) {
        target = newTarget;
       
    }
    void FixedUpdate()
    {
        if (armStamp <= Time.time)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;

        }
        if (target == null) {
            Destroy(gameObject);
        }
        Vector3 toTarget = target.transform.position - transform.position;
        GetComponent<Rigidbody>().velocity = toTarget.normalized * speed;
        transform.forward = toTarget.normalized;
    }
    void OnCollisionEnter(Collision colision) {

        target = colision.gameObject;
        targethealth = (HealthAndDeduction)target.GetComponent(typeof(HealthAndDeduction));
        if (targethealth != null)
        {
            targethealth.DamageCalc(incomDamage, missileDamage);
        }
        print("Missile detonated");
        Destroy(gameObject);
    }
}
