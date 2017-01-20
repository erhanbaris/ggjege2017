using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {


	public GameObject[] penguins;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		penguins = new GameObject[5];
		spawnPoints = new Transform[5];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
