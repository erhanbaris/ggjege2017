using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoveandDestroyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-1, 0, 0) * 15 * Time.deltaTime);
	}
}
