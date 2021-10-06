using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SceneSystem;

public class EndingAppearance : MonoBehaviour
{
    public GameObject[] RootObjectsArray;
    public GameObject SoundManager;
    public string ElvesName;
    public string houseName;
    public GameObject Elves;
    public GameObject house;
    // Start is called before the first frame update
    void Start()
    {
        IMixedRealitySceneSystem sceneSystem = MixedRealityToolkit.Instance.GetService<IMixedRealitySceneSystem>();
        RootObjectsArray = sceneSystem.GetScene("ManagerScene").GetRootGameObjects();
        foreach (var i in RootObjectsArray)
        {
            if (i.name == "SoundManager")
            {
                SoundManager = i;
            }
            else
            {
                print("Not Found SoundManager");
            }
        }

        ElvesName = "Elves";
        houseName = "House_V.2";
        Elves = GameObject.Find(ElvesName);
        house = GameObject.Find(houseName);
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinGamePerformance()
    {
        SoundManager.SendMessage("Victory");
        //SoundManager.instance.Victory();
        //delete the fire

        //Stop moving
        Elves.SendMessage("ChangeElvesStatesToWin");
    }
    public void LoseGamePerformance()
    {
        SoundManager.SendMessage("Defeat");
        //SoundManager.instance.Defeat();

        //house and elves disappeared
        if (Elves.activeInHierarchy)
        {
            Elves.SetActive(false);
        }
        if (house.activeInHierarchy)
        {
            house.SetActive(false);
        }
    }

    public void TestMaterial()
    {
        GameObject environmentarray = GameObject.Find("environment");
        environmentarray.GetComponentInChildren<Material>().color = new Color
        (
                0, 0, 0, 0
        );
        //environmentarray.GetComponentInChildren<Material>().color.a = 0f;
    }
}
