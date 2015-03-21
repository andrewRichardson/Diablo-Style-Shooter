using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
	
	[Header("Player Variables")]
	public float playerSpeed;
	public float rotationSpeed;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 rotation = Vector3.up * rotationSpeed * Input.GetAxisRaw ("Horizontal");

		rb.AddTorque (rotation, ForceMode.VelocityChange);

		Vector3 movement = transform.forward * playerSpeed * Input.GetAxisRaw ("Vertical");

		rb.AddForce(movement, ForceMode.Acceleration);
	}
}
