using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    GameObject target;
    HealthAndDeduction targethealth;
    public PlayerFireWeapon.damageType incomDamage = PlayerFireWeapon.damageType.kenetic;
    public double Damage;
    public float BulletLife = 10.0F;
    private float timeStamp;
    // Use this for initialization
    void Start () {
		timeStamp = Time.time + BulletLife;
    }
	
	// Update is called once per frame
	void Update () {
		if(timeStamp <= Time.time)
        {
            Destroy(gameObject);
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
