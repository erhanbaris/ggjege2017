using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController Instance;
	public bool IsGameStarted = false;

	void Awake()
	{
		Instance = (Instance == null) ? this : Instance;
	}

	// Use this for initialization
	void Start () {
		var startObjects = GameObject.FindGameObjectsWithTag ("PendushEnd");
		foreach (var item in startObjects)
			item.GetComponent<UnityEngine.UI.Image> ().enabled = false;
	}

	public void SetGameStatus(bool status)
	{
		IsGameStarted = status;
		if (IsGameStarted) {
			var startObjects = GameObject.FindGameObjectWithTag ("PendushStart");
			if (startObjects != null)
				startObjects.GetComponent<UnityEngine.UI.Image>().enabled = false;
		} else {
			var startObjects = GameObject.FindGameObjectWithTag ("PendushStart");
			if (startObjects != null)
				startObjects.GetComponent<UnityEngine.UI.Image>().enabled = false;

			var endObjects = GameObject.FindGameObjectsWithTag ("PendushEnd");
			foreach (var item in endObjects)
				item.GetComponent<UnityEngine.UI.Image> ().enabled = true;

			startObjects = GameObject.FindGameObjectWithTag ("PendushScore");
			if (startObjects != null)
				startObjects.GetComponent<UnityEngine.UI.Text>().text = "SCORE: " + GameManagerScript.Score;
			
		}
	}

	// Update is called once per frame
	void Update () {
		if (!IsGameStarted && Input.GetKeyDown(KeyCode.Space))
			SetGameStatus (true);
	}
}
