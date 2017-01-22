using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

	public GameObject Wave;
	public GameObject Whale;
	//public GameObject[] enemies;
	//public int Range = 7;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("EnemySpawner", 5, 10);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			Instantiate (Wave, transform.position, transform.rotation);
        }
	}
	void EnemySpawner(){
		if (!GameManagerScript.Instance.IsGameStarted)
			return;
		
		if (Random.Range (1, 3) % 2 == 0) {
			Instantiate (Wave, transform.position, transform.rotation);
		}	
		else {
			Instantiate (Whale, transform.position, transform.rotation);
		}
	}
}
