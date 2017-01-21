using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public bool startScore = false;
    public Text txtScore;
    public static int Score = 0;

    // Use this for initialization
    void Start()
    {

        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("SCORETEXT");

        foreach (GameObject lightUser in objs)
        {
            txtScore = lightUser.GetComponent<UnityEngine.UI.Text>();
            txtScore.text = Score.ToString();
        }
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

        if (GameObject.FindGameObjectsWithTag("penguin") == null)
        {
            Debug.Log("GAME OVER");
        }
    }

}
