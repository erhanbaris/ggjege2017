using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraFollow : MonoBehaviour
{

    public bool StartFollow;
    GameManagerScript gameScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "ENEMY")
            CameraFollow.FollowEnemy = StartFollow;
        gameScript =  other.gameObject.GetComponent<GameManagerScript>();

        if (other.transform.tag == "ENEMY" && gameScript.startScore == false)
        { 
            gameScript.startScore = true;
        }
        else if (other.transform.tag == "ENEMY" && gameScript.startScore == true)
        { 
            gameScript.startScore = false;
            gameScript.AddScore( CharacterManager.LivePenguins.Count * 10);


        }
    }
}
