using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player; 
	public Camera camera; 

	public float dampTime = 1.15f;
	private Vector3 velocity = Vector3.zero;
	public static bool FollowEnemy = false;

	private Vector3 savedPosition;

	void Start () 
	{
		savedPosition = transform.position;
	}

	void FixedUpdate () 
	{
		if (FollowEnemy)
		{
			Vector3 point = camera.WorldToViewportPoint(player.transform.position);
			Vector3 delta = player.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, point.y, 40f)); 
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

		}
		else 
			transform.position = Vector3.SmoothDamp(transform.position, savedPosition, ref velocity, dampTime);
	}
}