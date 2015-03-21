using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	public float lifetime;
	public GameObject particles;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider obj){
		if(particles != null)
			Instantiate (particles, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
