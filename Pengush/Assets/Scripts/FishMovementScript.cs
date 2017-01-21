using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovementScript : MonoBehaviour {

	public Transform[] wayPointArray;
	public int currentWayPoint = 0;

	Transform targetWayPoint;
	public float speed = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentWayPoint < this.wayPointArray.Length) {
			if (targetWayPoint == null) {
				targetWayPoint = wayPointArray [currentWayPoint];
			}
			Move ();
		}
	}
	void Move(){
		transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);

		if (transform.position == targetWayPoint.position) {

			currentWayPoint++;
			targetWayPoint = wayPointArray [currentWayPoint];
		}
	}
}
