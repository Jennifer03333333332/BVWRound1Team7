using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfManager : MonoBehaviour
{
    
    //Spawn
    [Tooltip("Elf's GameObject")]
    public GameObject Elf;
    public GameObject GM;
    public Vector3 spawnPos;
    public Quaternion spawnRot;
    public Transform spawnFolder;
    public float changeTargetInterval;

    [Tooltip("elf's population")]
    public int spawnNum;
    public int currentSpawnNum;
    public float createElfInterval;

    public List<GameObject> elfList;



    private static IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
        coroutine = WaitAndDo(createElfInterval);
        spawnFolder = this.transform;
        changeTargetInterval = 5;
        createElfInterval = 5;
        spawnNum = 7;
        //Put it in change. TODO
        startElfsThing();
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }

    void startElfsThing()
    {
        StartCoroutine(coroutine);
    }
    void SpawnFromTheHouseDoor()
    {
        GameObject elf = Instantiate(Elf, spawnPos, spawnRot, spawnFolder);
        elfList.Add(elf);
        currentSpawnNum++;
    }

    public IEnumerator WaitAndDo(float waitTime)
    {
        while (true)
        {
            if (waitTime > 0.5)
            {
                waitTime -= 1 / 30;
            }
            yield return new WaitForSeconds(waitTime);
            //print("WaitAndDo " + Time.time);
            //GM.SendMessage("TestMaterial");
            SpawnFromTheHouseDoor();
            foreach (var obj in elfList)
            {
                obj.SendMessage("MakeTargetPosRandom");
            }

            if (currentSpawnNum >= spawnNum)
            {
                StopCoroutine(coroutine);
            }

        }
    }

    public void ChangeElvesStatesToWin(int _state)
    {
        foreach(var elf in elfList)
        {
            elf.SendMessage("ChangeElfState", 1);
        }
    }
}
