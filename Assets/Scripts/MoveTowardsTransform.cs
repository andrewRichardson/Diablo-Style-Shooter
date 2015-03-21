using UnityEngine;
using System.Collections;

public class MoveTowardsTransform : MonoBehaviour {

	public Transform target;
	public float speed;

	private Vector3 lastPos;
	private Vector3 direction;
	private bool canMove = true;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		lastPos = transform.position;

		direction = target.position - transform.position;
		direction.Normalize ();

		if(canMove)
			transform.position += direction * speed;

		canMove = true;
	}

	void OnTriggerEnter (Collider obj){
		transform.position = lastPos;
		transform.position -= direction * speed;
		
		canMove = false;
	}

	void OnTriggerStay (Collider obj){
		transform.position = lastPos;
		transform.position -= direction * speed;

		canMove = false;
	}
}
