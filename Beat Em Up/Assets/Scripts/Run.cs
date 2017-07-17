using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

    Rigidbody2D rig;
    public float speed;
	// Use this for initialization
	void Start () {
        rig = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate  () {
        //rig.AddRelativeForce(new Vector2(speed, 0), ConstantForce2D);
	}
}
