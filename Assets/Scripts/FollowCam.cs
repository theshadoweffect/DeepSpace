using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public GameObject target;
    private Vector3 offset;
    // Use this for initialization
    void Start() {
        offset = transform.position - target.transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.transform.position+offset;
    }
}
