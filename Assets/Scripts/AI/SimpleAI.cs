using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour {
	private TeamScript.TeamSet targetTeam;
	private TeamScript.TeamSet neutral = TeamScript.TeamSet.NEUTRAL;
    public float minRange = 1.0F;
    public float maxRange = 10.0F;
    public GameObject[] CannonArr;
    public GameObject[] MissileArr;
    public GameObject[] LaserArr;
    int CannonNum;
    int MissileNum;
    int LaserNum;
    TeamScript teamScript;
    GameObject target;
	public float shipSpeed = 1.0f;
    // Use this for initialization
    void Start() {
        CannonNum = CannonArr.Length;
        MissileNum = MissileArr.Length;
        LaserNum = LaserArr.Length;
    }
	void FixedUpdate(){

        if (target != null)
        {
            Move();
            Fire();
            
        }
        else {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
	void OnTriggerEnter(Collider collider) {
		TeamScript.TeamSet aiTeam;
		RaycastHit hit;
        GameObject CheckTarget;
        CheckTarget = collider.gameObject;
        Vector3 dir = CheckTarget.transform.position - transform.position;

        

        print("Target detected!");
        
        if (Physics.Raycast(transform.position, dir, out hit)){
            print("Target scanned!");
            Debug.DrawLine(gameObject.transform.position, hit.point, Color.red, 1.0F);
            if (collider.gameObject == hit.collider.gameObject) {
                print("Target visable");
              
				teamScript = (TeamScript)CheckTarget.gameObject.GetComponent(typeof(TeamScript));

               if (teamScript != null)
               {
                    print("Confirming target");
                    targetTeam = teamScript.GetTeam();
                    teamScript = (TeamScript) GetComponent(typeof(TeamScript));
                    aiTeam = teamScript.GetTeam();

                    if (targetTeam != aiTeam && targetTeam != neutral)
                    {
                        target = collider.gameObject;
                        print("Target confirmed");
                    }
                }
                else {
                    print("Non viable target");
                }
			}


		}
        Debug.DrawLine(gameObject.transform.position, hit.point, Color.red, 1.0F);
         target = collider.gameObject;
    }
   
    void OnTriggerExit(Collider colision)
    {
        if(target != null)
        {
            if(target == colision.gameObject)
            {
                target = null;
                print("target lost");
            }

        }
        else{

            print("Object has left field of vision");
        }


    }
    void Move() {
        RaycastHit hit;
        Vector3 dir = target.transform.position - transform.position;
        Physics.Raycast(transform.position, dir, out hit);
        Debug.DrawLine(gameObject.transform.position, hit.point, Color.red, 1.0F);
        if (hit.distance <= maxRange)
        {
            Vector3 toTarget = target.transform.position - transform.position;
            GetComponent<Rigidbody>().velocity = toTarget.normalized * shipSpeed;
            transform.forward = toTarget.normalized;

        }
        else if (hit.distance >= minRange)
        {
            Vector3 toTarget = target.transform.position - transform.position;
            GetComponent<Rigidbody>().velocity = -toTarget.normalized * shipSpeed;
            transform.forward = toTarget.normalized;
        }

    }
    void Fire() {
        AiWeapons FiringCommand;
        for (int ii = 0; ii < CannonNum; ii++)
        {
            FiringCommand = (AiWeapons)CannonArr[ii].GetComponent(typeof(AiWeapons));
            FiringCommand.Fire();
        }
        for (int ii = 0; ii < MissileNum; ii++)
        {
            FiringCommand = (AiWeapons)MissileArr[ii].GetComponent(typeof(AiWeapons));
            FiringCommand.Fire();
        }
        for (int ii = 0; ii < LaserNum; ii++)
        {
            FiringCommand = (AiWeapons)LaserArr[ii].GetComponent(typeof(AiWeapons));
            FiringCommand.Fire();
        }
    }
}
