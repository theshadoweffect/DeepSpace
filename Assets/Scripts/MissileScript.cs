using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {
    GameObject target;
    HealthAndDeduction targethealth;
    public PlayerFireWeapon.damageType incomDamage = PlayerFireWeapon.damageType.kenetic;
    public  double missileDamage;
    public float speed = 100.0F;
    // Update is called once per frame
    public void SetTarget(GameObject newTarget) {
        target = newTarget;
       
    }
    void FixedUpdate()
    {
        if(target == null) {
            Destroy(gameObject);
        }
        Vector3 toTarget = target.transform.position - transform.position;
        GetComponent<Rigidbody>().velocity = toTarget.normalized * speed;
        transform.forward = toTarget.normalized;
    }
    void OnCollisionEnter(Collision colision) {

            targethealth = (HealthAndDeduction)target.GetComponent(typeof(HealthAndDeduction));
            targethealth.DamageCalc(incomDamage, missileDamage);

        print("Missile detonated");
        Destroy(gameObject);
    }
}
