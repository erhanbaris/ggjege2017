using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFishCreatorScript : MonoBehaviour {

	public GameObject[] fishes;
	public Transform fishSpawnPoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("fishSpawner", 8f, 15f);
		fishSpawner ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void fishSpawner(){
		int fishIndex = Random.Range (0,fishes.Length);
		Instantiate (fishes [fishIndex],fishSpawnPoint.position,fishSpawnPoint.rotation);
	}
}
