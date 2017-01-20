using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {


	public GameObject[] penguins;
	public Transform[] spawnPoints;



	// Use this for initialization
	void Start () {

		for (int i = 0; i < penguins.Length; i++) {

		    var tmpTransform = spawnPoints[i].transform.position;
		    tmpTransform = new Vector3(tmpTransform.x, tmpTransform.y + UnityEngine.Random.Range(10, 20), tmpTransform.z);

		    Instantiate (penguins [i], tmpTransform, spawnPoints [i].rotation);
			penguins[i].GetComponent<PenguinControlScript> ().SetId (i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		var controller = penguins [2].GetComponent<PenguinControlScript> ();
		controller.enabled = true;
	}
}
