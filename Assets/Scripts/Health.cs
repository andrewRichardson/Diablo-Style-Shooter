using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float maxHealth = 100;
	public GameObject deathParticles;

	private float health;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			if(deathParticles != null)
				Instantiate(deathParticles, transform.position, transform.rotation);

			GameObject weapon = new GameObject();
			float type = Random.Range(0,2);
			float min = Random.Range((int)(maxHealth/20*(type*1.5)), (int)(maxHealth/5*(type*1.5)));
			float max = Random.Range((int)(maxHealth/4*(type*1.5)), (int)(maxHealth/2*(type*1.5)));
			weapon.name = "Weapon " + Random.Range (0,456201).ToString();
			weapon.tag = "Weapon";
			weapon.transform.Translate(new Vector3(min, max, type));

			Destroy(gameObject);
		}
	}

	void DamageHealth(float damage){
		health -= damage;
		Debug.Log ("DAMAGED: " + damage);
	}
}
