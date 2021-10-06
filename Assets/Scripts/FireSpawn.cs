using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawn : MonoBehaviour
{
    public GameObject toSpawn;
    [SerializeField] private int currentFires = 0;
    [SerializeField] private GameObject levelController;
    // Start is called before the first frame update
    void Start()
    {
        LevelOne();
    }
    void Update()
    {
        if (currentFires >= levelController.GetComponent<LevelController>().currentLevel*2 + 5)
            levelController.GetComponent<LevelController>().LoseGame();
    }
    public void LevelOne()
    {
        CreateFire();
        CreateFire();
        CreateFire();
    }
    public void LevelTwo()
    {
        CreateFire();
        CreateFire();
        CreateFire();
        CreateFire();
    }
    public void CreateFire()
    {
        Instantiate(toSpawn, transform.position + new Vector3(Random.Range(-0.4f, 0.4f), 0, Random.Range(-0.4f, 0.4f)), Quaternion.identity);
        currentFires++;
        SoundManager.instance.PlayingSound("Fire");
    }
    public void PutOutFire()
    {
        currentFires--;
        if(currentFires == 0)
            levelController.GetComponent<LevelController>().NextLevel();
    }
}
