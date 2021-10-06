using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jennifer : MonoBehaviour
{
    public static Jennifer _instance;
    void Awake()
    {
        _instance = this;
    }

    public void BuildRain()
    {
        print("BuildRain");
        //create particles and then destroy
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
