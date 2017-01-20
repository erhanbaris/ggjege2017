﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinControlScript : MonoBehaviour {


	Vector3 currentJumpVelocity;
	bool isJumping = false;
	public int JumpingSpeed = 5;
	public bool IsVisible = true;
	public int id;

	public static int SelectedId = 0;

	// Use this for initialization
	void Start () {
	}

	public void SetId(int pId)
	{
		id = pId;	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		Vector3 moveVelocity = Vector3.zero;

		//moveVelocity.x = Input.GetAxis ("Horizontal");


		if (Input.GetButtonDown ("Jump")) {
			if (!isJumping && SelectedId == id) {
				isJumping = true;
				currentJumpVelocity = Vector3.up * 6;

			}
		}

		if (isJumping || !controller.isGrounded) {
			controller.Move ((moveVelocity + currentJumpVelocity) * JumpingSpeed * Time.deltaTime);
			currentJumpVelocity += Physics.gravity * Time.deltaTime;
			if (controller.isGrounded) {
				isJumping = false;
			}

		} else {

			//controller.SimpleMove (moveVelocity);
			currentJumpVelocity = Vector3.zero;
		}
	}
}