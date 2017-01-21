using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraFollow : MonoBehaviour {

	public bool StartFollow;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "ENEMY") 
			CameraFollow.FollowEnemy = StartFollow;
	}
}
