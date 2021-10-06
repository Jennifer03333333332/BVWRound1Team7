using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject levelController;
    [SerializeField] private GameObject fireController;

    // Update is called once per frame
    void Start()
    {
        levelController = GameObject.Find("LevelController");
        fireController = GameObject.Find("FireSpawner");
    }
    void Update()
    {
        if (levelController.GetComponent<LevelController>().currentLevel <= levelController.GetComponent<LevelController>().maxLevel || levelController.GetComponent<LevelController>().currentLevel == -1)
        {
            this.transform.localScale += new Vector3(Time.deltaTime / 60, Time.deltaTime / 60, Time.deltaTime / 60);
            if (this.transform.localScale.x >= 2)
                levelController.GetComponent<LevelController>().LoseGame();
            else if (this.transform.localScale.x <= 0)
            {
                fireController.GetComponent<FireSpawn>().PutOutFire();
                Destroy(gameObject);
            }
        }  
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Rain")
        {
            this.transform.localScale -= new Vector3(Time.deltaTime / 10, Time.deltaTime / 10, Time.deltaTime / 10);
        }
    }
}
