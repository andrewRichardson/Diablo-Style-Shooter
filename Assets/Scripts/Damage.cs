using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public float damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj){
		if (obj.tag == "Enemy") {
			obj.gameObject.SendMessage("DamageHealth", damage);
		}
	}

	void SetDamage(float dam){
		damage = dam;
	}
}
