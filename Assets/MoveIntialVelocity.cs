using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MoveIntialVelocity : MonoBehaviour {

	public float verticalVel;
	public float forwardVel;
	public float horizVel;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		rb.velocity = transform.forward * forwardVel + transform.up * verticalVel + transform.right * horizVel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
