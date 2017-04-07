using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour {
    //Script Variables
	private TeamScript.TeamSet targetTeam;
	private TeamScript.TeamSet neutral = TeamScript.TeamSet.NEUTRAL;
    //Ranges
    public float minRange = 1.0F;
    public float maxRange = 10.0F;
    //Weapon GameObjects
    public GameObject[] CannonArr;
    public GameObject[] MissileArr;
    public GameObject[] LaserArr;
    //Weapon Counters
    int CannonNum;
    int MissileNum;
    int LaserNum;
    //Other
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
	
		RaycastHit hit;
        GameObject CheckTarget;
        CheckTarget = collider.gameObject;
        Vector3 dir = transform.position - CheckTarget.transform.position;


        if (Scan(CheckTarget)) {
            if (Physics.Raycast(CheckTarget.transform.position, dir, out hit))
            {
                print("Target detected!");
                Debug.DrawLine(CheckTarget.transform.position, hit.point, Color.red, 1.0F);
                if (gameObject == hit.collider.gameObject)
                {
                    target = CheckTarget;
                }
            }
        }
       //  target = collider.gameObject;
    }
    void OnTriggerStay(Collider collider) {
        RaycastHit hit;
        GameObject CheckTarget;
        CheckTarget = collider.gameObject;
        Vector3 dir = transform.position - CheckTarget.transform.position;
        if (target == null)
        {

            if (Scan(CheckTarget))
            {
                if (Physics.Raycast(CheckTarget.transform.position, dir, out hit))
                {
                    print("Target detected!");
                    Debug.DrawLine(CheckTarget.transform.position, hit.point, Color.red, 1.0F);
                    if (gameObject == hit.collider.gameObject)
                    {
                        target = CheckTarget;
                    }
                }
            }
        }
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
        Vector3 dir =  transform.position - target.transform.position;
        Physics.Raycast(target.transform.position, dir, out hit);
        Debug.DrawLine(target.transform.position, hit.point, Color.red, 1.0F);
        Vector3 toTarget = target.transform.position - transform.position;
        if (hit.distance >= maxRange)
        {
           
            GetComponent<Rigidbody>().velocity = toTarget.normalized * shipSpeed;
        
            
        }
        else if (hit.distance <= minRange)
        {
            
            GetComponent<Rigidbody>().velocity = -toTarget.normalized * shipSpeed;
           
        }
        transform.forward = toTarget.normalized;
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
    bool Scan(GameObject CheckTarget) {
        int newTargPrior;
        int CurTargPrior;
        TeamScript.TeamSet aiTeam;

        teamScript = (TeamScript)CheckTarget.gameObject.GetComponent(typeof(TeamScript));

            if (teamScript != null)
            {
                print("Confirming target");
                targetTeam = teamScript.GetTeam();
                newTargPrior = teamScript.GetPriority();//Loads priority into newTargPrior
                teamScript = (TeamScript)GetComponent(typeof(TeamScript));
                aiTeam = teamScript.GetTeam();

                if (targetTeam != aiTeam && targetTeam != neutral)
                {

                    if (target == null)
                    {
                        target = CheckTarget;
                        print("Target confirmed");
                        return true;
                    }
                    else
                    {
                        //Checks priority
                        teamScript = (TeamScript)target.gameObject.GetComponent(typeof(TeamScript));//Gets current targ teamScript
                        CurTargPrior = teamScript.GetPriority();//Gets current targ priority
                        if (newTargPrior > CurTargPrior)
                        {
                            return true;
                        }
                    }
                }
            }
            else {
                print("Non viable target");
            return false;
            }
        return false;
        }
        
    }

