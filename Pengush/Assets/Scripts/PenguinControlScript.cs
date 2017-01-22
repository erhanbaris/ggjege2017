using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinControlScript : MonoBehaviour
{
    public AudioClip DeadClip;
    public AudioClip JumpClip;
    public AudioClip EatClip;

    public int JumpingSpeed = 5;
    public bool IsVisible = true;
    public int id;
    public static int SelectedId = -1;

    private AudioSource audioSource;
    Vector3 currentJumpVelocity;
    bool isJumping = false;
	Animator penguinAnimator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
		penguinAnimator = GetComponent<Animator>();
    }

    public void SetId(int pId)
    {
        id = pId;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ENEMY")
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            CharacterManager.Damaged = true;
            
			penguinAnimator.SetBool ("Die", true);
			Invoke ("diePenguin", 0.2f);

			CharacterManager.Instance.PenguinDied(id);
        }
    }

	void diePenguin()
	{
		Debug.Log ("die penguin");
		penguinAnimator.SetBool ("Die", false);
		this.gameObject.SetActive(false);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ENEMY")
        {
            other.GetComponent<AudioSource>().Play();
            CharacterManager.Damaged = true;

			penguinAnimator.SetBool ("Die", true);
			Invoke ("diePenguin", 0.2f);

            CharacterManager.Instance.PenguinDied(id);
        }
        else if (other.tag == "GREEN_FISH")
        {
			this.GetComponent<AudioSource>().PlayOneShot(EatClip);
            other.gameObject.SetActive(false);
            var gameScript = this.gameObject.GetComponent<GameManagerScript>();
            gameScript.AddScore(10);
        }
    }

    void Update()
    {		
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 moveVelocity = Vector3.zero;

		if (GameManagerScript.IsGameStarted && Input.GetButtonDown("Jump"))
        {
            if (!isJumping && SelectedId == id)
            {
                audioSource.clip = JumpClip;
                audioSource.Play();
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