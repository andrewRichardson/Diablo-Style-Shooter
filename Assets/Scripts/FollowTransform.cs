using UnityEngine;
using System.Collections;

public class FollowTransform : MonoBehaviour {

	private Vector3 displacement;

	public Transform trans;

	// Use this for initialization
	void Start () {
		displacement = transform.position - trans.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = trans.position + displacement;
	}
}
