using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {


	public GameObject[] penguins;
	public Transform[] spawnPoints;



	// Use this for initialization
	void Start () {

		for (int i = 0; i < penguins.Length; i++) {
			Instantiate (penguins [i], spawnPoints [i].position, spawnPoints [i].rotation);	
			penguins[i].GetComponent<PenguinControlScript> ().SetId (i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		var controller = penguins [2].GetComponent<PenguinControlScript> ();
		controller.enabled = true;
	}
}
