using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public bool startScore = false;
    public Text txtScore;
    public static int Score = 0;

	public static GameManagerScript Instance;
	public static bool IsGameStarted = false;

	void Awake()
	{
		Instance = (Instance == null) ? this : Instance;
	}

    // Use this for initialization
    void Start()
    {
		var startObjects = GameObject.FindGameObjectsWithTag ("PendushEnd");
		foreach (var item in startObjects)
			item.GetComponent<UnityEngine.UI.Image> ().enabled = false;

		startObjects = GameObject.FindGameObjectsWithTag ("PendushScore");
		foreach (var item in startObjects)
			item.GetComponent<UnityEngine.UI.Text> ().text = "";

        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("SCORETEXT");

        foreach (GameObject lightUser in objs)
        {
            txtScore = lightUser.GetComponent<UnityEngine.UI.Text>();
            txtScore.text = Score.ToString();
        }

		//CharacterManager.Instance.Restart ();
    }

    public void AddScore(int value)
    {
        Score += value;
        txtScore.text = Score.ToString();
    }

    public void SetScore(int value)
    {
        txtScore.text = value.ToString();
    }


    // Update is called once per frame
    void Update()
    {
		if (!IsGameStarted && Input.GetKeyDown(KeyCode.Space))
			SetGameStatus (true);
    }

	public void StartGame()
	{
		Start ();
		SetGameStatus(true);
	}

	public void RestartGame()
	{
		StartGame();
		CharacterManager.Instance.Restart ();
	}

	public void SetGameStatus(bool status)
	{
		IsGameStarted = status;
		if (IsGameStarted) {
			var startObjects = GameObject.FindGameObjectsWithTag ("PendushStart");
			foreach (var item in startObjects)
				item.SetActive(false);
		} else {
			var endObjects = GameObject.FindGameObjectsWithTag ("PendushEnd");
			foreach (var item in endObjects)
				item.GetComponent<UnityEngine.UI.Image> ().enabled = true;

			var startObjects = GameObject.FindGameObjectWithTag ("PendushScore");
			if (startObjects != null)
				startObjects.GetComponent<UnityEngine.UI.Text>().text = "SCORE: " + GameManagerScript.Score;

		}
	}
}
