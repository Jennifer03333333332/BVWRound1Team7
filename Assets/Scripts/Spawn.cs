using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject killbox;
    [SerializeField] private GameObject[] spawnObjects;
    [SerializeField] private GameObject levelController;
    public bool active = false;

    private float currentTime = 0;

    void Update()
    {
        if (levelController.GetComponent<LevelController>().currentLevel <= levelController.GetComponent<LevelController>().maxLevel || levelController.GetComponent<LevelController>().currentLevel == -1)
        {
            if (active)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= spawnTime)
                {
                    currentTime = 0;
                    GameObject toSpawn = spawnObjects[Random.Range(0, Mathf.Clamp(spawnObjects.Length, 0, levelController.GetComponent<LevelController>().currentLevel))];
                    GameObject newSpawn = Instantiate(toSpawn, transform.position, Quaternion.identity);
                    if (killbox != null)
                        newSpawn.GetComponent<CloudMovement>().endPoint = killbox.transform.position;
                }
            }
        } 
    }
}

