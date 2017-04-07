using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    HealthAndDeduction targethealth;
    public PlayerFireWeapon.damageType incomDamage = PlayerFireWeapon.damageType.kenetic;
    public double Damage;
    public float BulletLife = 10.0F;
    public float armingDelay = 1.0F;
    private float timeStamp;
    private float armStamp;
    // Use this for initialization
    void Start()
    {
        timeStamp = Time.time + BulletLife;
        armStamp = Time.time + armingDelay;
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStamp <= Time.time)
        {
            Destroy(gameObject);
        }
        if (armStamp <= Time.time)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;

        }
    }
    void OnCollisionEnter(Collision colision)
    {
        target = colision.gameObject;
        targethealth = (HealthAndDeduction)target.GetComponent(typeof(HealthAndDeduction));
        if (targethealth != null)
        {
            targethealth.DamageCalc(incomDamage, Damage);
        }
        print("Bullet Detonated");
        Destroy(gameObject);
    }
}
