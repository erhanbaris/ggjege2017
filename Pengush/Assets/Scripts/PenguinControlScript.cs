using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinControlScript : MonoBehaviour
{
	public int JumpingSpeed = 5;
	public bool IsVisible = true;
	public int id;
	public static int SelectedId = -1;

	Vector3 currentJumpVelocity;
	bool isJumping = false;

	void Start()
	{
	}

	public void SetId(int pId)
	{
		id = pId;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "ENEMY")
		{
			CharacterManager.Damaged = true;
			this.gameObject.SetActive(false);

		    CharacterManager.Instance.PenguinDied(id);
		}
	}

	void Update()
	{
		CharacterController controller = GetComponent<CharacterController>();
		Vector3 moveVelocity = Vector3.zero;

		if (Input.GetButtonDown("Jump"))
		{
			if (!isJumping && SelectedId == id)
			{
				isJumping = true;
				currentJumpVelocity = Vector3.up * 6;
			}
		}

		if (isJumping || !controller.isGrounded)
		{
			controller.Move((moveVelocity + currentJumpVelocity) * JumpingSpeed * Time.deltaTime);
			currentJumpVelocity += Physics.gravity * Time.deltaTime;
			if (controller.isGrounded)
			{
				isJumping = false;
			}
		}
		else
		{
			currentJumpVelocity = Vector3.zero;
		}
	}
}