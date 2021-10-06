using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCloudSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime;
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
                    GameObject newSpawn = Instantiate(toSpawn, new Vector3(Random.Range(this.transform.position.x - 0.2f, this.transform.position.x + 0.2f), this.transform.position.y, Random.Range(this.transform.position.z - 0.2f, this.transform.position.z + 0.2f)), Quaternion.identity);
                }
            }
        }
    }
}
