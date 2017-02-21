using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 15f;

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3 (speed * Time.deltaTime, 0, 0);
        rb.AddForce(movement);
	}
}
