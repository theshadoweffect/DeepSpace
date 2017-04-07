using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamScript : MonoBehaviour {
	public enum TeamSet {USF,PERG, NEUTRAL}
	public TeamSet team = TeamSet.USF;
	public int Priority = 10;
    void Start() {
        print(team);

    }
	public TeamSet GetTeam(){
		return team;	
	}
    public int GetPriority() {
        return Priority;
    }
}
