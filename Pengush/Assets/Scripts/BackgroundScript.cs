using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

	public GameObject[] clouds;
	public Transform[] cloudSpawnPoints;
	public float spawnTime = 0.10f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnClouds", spawnTime, spawnTime);
		SpawnClouds ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void SpawnClouds() {

		int cloudIndex = Random.Range (0, clouds.Length);
		int spawnIndex = Random.Range (0,cloudSpawnPoints.Length);

		Instantiate (clouds[cloudIndex], cloudSpawnPoints[spawnIndex].position, cloudSpawnPoints[spawnIndex].rotation);

	}
}
