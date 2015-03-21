using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour {

	[Range(5,20)]
	public float coolTime;
	public List<GameObject> currentWeapon;
	public GameObject textObject;
	public int weapon = 0;
	public GameObject flash;
	public int invSize;

	[Header("Bullet Types")]
	public List<GameObject> bullets;

	private float timer = 0;
	private Damage damageScript;
	private float bulletDamMin;
	private float bulletDamMax;
	private int bulletType;
	private Text text;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();

		if (currentWeapon.Count > 0) {
			bulletDamMin = currentWeapon [weapon].transform.position.x;
			bulletDamMax = currentWeapon [weapon].transform.position.y;
			bulletType = (int)currentWeapon [weapon].transform.position.z;
		} else {
			bulletDamMin = 5;
			bulletDamMax = 15;
			bulletType = 0;
		}

		for (int i = 0; i < bullets.Count; i++) {
			DestroyImmediate (bullets [i].GetComponent ("Damage"), true);

			damageScript = bullets [i].AddComponent<Damage> () as Damage;
			damageScript.damage = Random.Range (bulletDamMin, bulletDamMax);
		}

		text = textObject.GetComponent<Text> ();
		text.text = "Weapon " + currentWeapon [weapon].name + " : " + bulletDamMin + " - " + bulletDamMax + " type " + bulletType;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject weapons = GameObject.FindGameObjectWithTag ("Weapon");
		
		if (currentWeapon.Count < invSize && Input.GetKey ("left shift") && timer <= 0 && weapons != null) {
			currentWeapon.Add (weapons);
			weapons.tag = "Untagged";

			timer = coolTime*2;
		}

		if (Input.GetKey ("left ctrl") && timer <= 0) {
			weapon++;
			if(weapon == currentWeapon.Count)
				weapon = 0;

			timer = coolTime*2;
		}

		if (currentWeapon.Count > 0) {
			bulletDamMin = currentWeapon [weapon].transform.position.x;
			bulletDamMax = currentWeapon [weapon].transform.position.y;
			bulletType = (int)currentWeapon [weapon].transform.position.z;
		} else {
			bulletDamMin = 5;
			bulletDamMax = 15;
			bulletType = 0;
		}
		
		text.text = currentWeapon [weapon].name + " : " + bulletDamMin + " - " + bulletDamMax + " type " + bulletType; 

		if (Input.GetKey ("space") && timer <= 0) {
			damageScript.damage = Random.Range (bulletDamMin, bulletDamMax);
			
			Instantiate(bullets[bulletType], transform.position, transform.rotation);
			Instantiate(flash, transform.position, transform.rotation);

			//sound.Play();

			timer = coolTime;
		}
		
		if (timer > 0)
			timer--;
	}
}
