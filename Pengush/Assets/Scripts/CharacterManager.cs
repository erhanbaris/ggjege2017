using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
	public GameObject[] penguins;
    public Transform[] spawnPoints;
    public Transform Arrow;

    public static CharacterManager Instance;
    public static List<int> LivePenguins = new List<int>();
    public static bool Damaged = false;
    Color damagedColor = new Color(255f, 255f, 255f, 0.5f);
    float smoothColor = 10f;

    public float dampTime = 1.15f;
    private Vector3 velocity = Vector3.zero;

    void Awake()
    {
        Instance = (Instance == null) ? this : Instance;
		Restart();
	}

    void Start()
    {
       
    }


    void FixedUpdate()
    {

    }


    public void Restart()
    {
        LivePenguins.Clear();
		GameManagerScript.Score = 0;

        for (int i = 0; i < penguins.Length; ++i)
        {
			LivePenguins.Add (i);
            var tmpTransform = spawnPoints[i].transform.position;
            tmpTransform = new Vector3(tmpTransform.x, tmpTransform.y + UnityEngine.Random.Range(35, 55), tmpTransform.z);

			var penguin = Instantiate(penguins[i], tmpTransform, spawnPoints[i].rotation) as GameObject;
			var animator = penguin.GetComponent<Animator>();
			Int32 randomIdle = UnityEngine.Random.Range (1, 5);
			penguin.transform.localScale = new Vector3 (animator.transform.localScale.x + UnityEngine.Random.Range(-3, 5), animator.transform.localScale.y  + UnityEngine.Random.Range(0, 3), animator.transform.localScale.z);

			animator.SetInteger("IdleSpeed2", randomIdle);
			animator.SetTrigger ("IdleSpeedChange");

            penguins[i].GetComponent<PenguinControlScript>().SetId(i);
            penguins[i].gameObject.SetActive(LivePenguins.Any(x => x == i));
         

        }

		PenguinControlScript.SelectedId = -1;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            lock (this)
            {
                bool isFirstElementFetched = false;
                int nextId = 0;

                foreach (var penguinId in LivePenguins)
                {
                    if (!isFirstElementFetched)
                    {
                        isFirstElementFetched = true;
                        nextId = penguinId;
                    }

                    if (PenguinControlScript.SelectedId < penguinId)
                    {
                        nextId = penguinId;
                        break;
                    }
                }

                PenguinControlScript.SelectedId = nextId;
            }
        }
    }

    public void PenguinDied(int penguinId)
    {
        LivePenguins.Remove(penguinId);

        if (LivePenguins.Count == 0)
        {
			GameManagerScript.Instance.SetGameStatus(false);
        }
    }

    public int GetLivePenguins()
    {
        return LivePenguins.Count();
    }
}