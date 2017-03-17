using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDeduction : MonoBehaviour {
    
    public double hull = 100;
    public double armour = 10;
    public double shield = 100;
    private double maxhealth;
    private double maxshield;
    private double maxarmour;
    public double regen = 20;
    public double regenArmour = 5;
    public float cooldownregen = 10.0F;
    private float timeStamp;
    PlayerFireWeapon.damageType incomDamage;

    //Armour strong to concusive vunerable to lasers average against kenetics
    //Shields weak to kenetic average vs lasers strong against concusive
    //Hull weak to concusive average everything else


    // concusive weapons are great against targets with no shields and little armour
    //Concusive have high damage but most objects have high resists
    //lasers have decent damage but are best used to remove enemy armour
    //kenetics are best used to crack open shields kenetics typically have the greatest reliable damage

    // Update is called once per frame
    void Start() {
        timeStamp = Time.time + cooldownregen;// sets timer
        maxhealth = hull;
        maxshield = shield;
        maxarmour = armour;
    }
	void Update () {
        //Object Destroy Check
        if (hull < 0) {
            Destroy(gameObject);
        }
        //Object Regen check
        if (timeStamp <= Time.time) {
            if (Input.GetKeyDown(KeyCode.R)) {
                timeStamp = Time.time + cooldownregen;// resets timer
                if (hull < maxhealth && shield >= maxshield)
                 {
                     hull = hull + regen;
                    armour = armour + regenArmour;
                 }
                 else if (shield < maxshield)
                 {
                     shield = shield + 2 * regen;

                 }
             }//END REGEN
        //MAX STATS CHECKS
        }if (hull > maxhealth) {
            hull = maxhealth;
        }if (shield > maxshield) {
            shield = maxshield;
        }if (armour > maxarmour) {
            armour = maxarmour;
        }
       
	}
//DAMAGE CALCULATORS
  public void DamageCalc(PlayerFireWeapon.damageType type, double DamageAmount) {
        //ARMOUR COUNTS
        if (armour < -4) {
            armour = -4;
        }
        if (type == PlayerFireWeapon.damageType.kenetic)
        {
            if (shield > 0)
            {
                shield = shield - 2*DamageAmount;
            }
            else
            {
                hull = hull - DamageAmount / (armour + 5);
            }

        }
        //THERMAL DAMAGE CALCs
        else if (type == PlayerFireWeapon.damageType.thermal)
        {
            if (shield > 0) {
                shield = shield - 2 * DamageAmount;
            }else
            {
                hull = hull - DamageAmount/(armour+5);
                if (armour > 0)
                {
                    armour = armour - DamageAmount / (4 * armour);// lasers weaken armour over time
                }
            }

        }//CONCUSIVE DAMAGE CALCs
        else if (type == PlayerFireWeapon.damageType.concusive)
        {
            if (shield > 0)
            {
                shield = shield - DamageAmount/4;
            }
            else
            {
                hull = hull - DamageAmount/(2*(armour + 1));
            }

        }
        //END DAMAGE CALCS
        double curhull = hull;
        double curshield = shield;

      //  Debug.Log("Current Hull: ", hull);
       // print("Current Shield: ", shield);
       // print("Current Armour", curarmour);
    }
}
