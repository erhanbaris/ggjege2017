using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

	public GameObject Wave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			Instantiate (Wave, transform.position, transform.rotation);

            var charMangaer = GetComponent<CharacterManager>();
         
            if(charMangaer!=null)
            {
                var livePenguins = charMangaer.GetLivePenguins();
            }
        }
	}
}
