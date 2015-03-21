using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

	public GameObject obj;
	public float delay;
	public bool keepSpawning = true;
	public int maxObjects;

	public int numObjects;

	// Use this for initialization
	void Start () {
		StartCoroutine ("SpawnEnemy");
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator SpawnEnemy(){
		while (keepSpawning && obj != null) {
			numObjects = GameObject.FindGameObjectsWithTag("Enemy").Length;

			if(numObjects < maxObjects){
				yield return new WaitForSeconds(delay);
				
				Instantiate(obj, transform.position, transform.rotation);
			}
			else{
				yield return new WaitForSeconds(delay);
				continue;
			}
		}
	}
}
