using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinControlScript : MonoBehaviour {


	Vector3 currentJumpVelocity;
	static bool isJumping;
	public int jumpingSpeed;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		Vector3 moveVelocity = Vector3.zero;

		//moveVelocity.x = Input.GetAxis ("Horizontal");


		if (Input.GetButtonDown ("Jump")) {
			if (!isJumping) {
				isJumping = true;
				currentJumpVelocity = Vector3.up * 6;

			}


		}
		if (isJumping || !controller.isGrounded) {


			controller.Move ((moveVelocity + currentJumpVelocity) * jumpingSpeed * Time.deltaTime);
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

