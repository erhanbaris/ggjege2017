using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] penguins;
    public Transform[] spawnPoints;

    void Start()
    {
        List<int> visiblePenguins = new List<int>();

        while (true)
        {
            var visibleId = UnityEngine.Random.Range(0, 10);
            var isIdAdded = visiblePenguins.Any(x => x == visibleId);

            if (!isIdAdded)
                visiblePenguins.Add(visibleId);

            if (visiblePenguins.Count >= 5)
                break;
        }

        for (int i = 0; i < penguins.Length; i++)
        {
            var tmpTransform = spawnPoints[i].transform.position;
            tmpTransform = new Vector3(tmpTransform.x, tmpTransform.y + UnityEngine.Random.Range(25, 45),
                tmpTransform.z);

            Instantiate(penguins[i], tmpTransform, spawnPoints[i].rotation);
            penguins[i].GetComponent<PenguinControlScript>().SetId(i);
            penguins[i].gameObject.SetActive(visiblePenguins.Any(x => x == i));
        }
    }

    void Update()
    {
    }
}