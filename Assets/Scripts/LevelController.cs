using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int currentLevel = 1;
    public int maxLevel = 2;
    [SerializeField] private GameObject dirLight;
    [SerializeField] private GameObject fireController;
    private GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel > maxLevel)
            WinGame();
        else
        {
            if (currentLevel == 2)
                fireController.GetComponent<FireSpawn>().LevelTwo();
        }
    }
    public void WinGame()
    {
        if(currentLevel != -1)
        {
            currentLevel = -1;
            GM.SendMessage("WinGamePerformance");
        }
        
    }
    public void LoseGame()
    {
        if (currentLevel != -1)
        {
            currentLevel = -1;
            dirLight.transform.Rotate(-45f, 0f, 0f, Space.Self);
            GM.SendMessage("LoseGamePerformance");
        }
    }
}
