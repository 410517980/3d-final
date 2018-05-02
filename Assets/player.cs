using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	Rigidbody playerRigidbody;
	float moveX;
	float moveZ;
	// Use this for initialization
	public float speed;
	void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody> ();

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MovementController ();
	}
	void move(){
		moveX = Input.GetAxis ("Horizontal");
		moveZ = Input.GetAxis ("Vertical");
		playerRigidbody.AddForce (new Vector3 (speed * moveX, 0, speed * moveZ));	
	}
	void MovementController(){
		if (!talk.isTalking) {
			move ();
		}
	}
}
