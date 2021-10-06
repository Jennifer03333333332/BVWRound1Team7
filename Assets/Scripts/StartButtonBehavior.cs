using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SceneSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButtonBehavior : MonoBehaviour
{
    // Type in the name of the Scene you would like to load in the Inspector
    public string m_Scene;
    public string mainScene;

    public float cloudInitScale;
    public float cloudMultiples_Max;

    private bool GameStarts;
    private bool GrabCloudStarts;
    private void Start()
    {
        GameStarts = false;
        GrabCloudStarts = false;
        mainScene = "Main";
        cloudInitScale = transform.localScale.magnitude;
        //cloudMaxScale = 1000;
        //print(transform.localScale.magnitude);
    }

    private void Update()
    {
        if (transform.localScale.magnitude > cloudInitScale && !GrabCloudStarts)
        {
            GrabCloudStarts = true;
            SoundManager.instance.PlayingSound("GrabTheCloud");
        }
        //print(transform.localScale.magnitude);
        if (transform.localScale.magnitude >= cloudMultiples_Max* cloudInitScale && !GameStarts)
        {
            //print(transform.localScale.magnitude);
            //StartCoroutine(LoadYourAsyncScene());
            GameStarts = true;
            TransitionToMainScene();
        }
    }
    //IEnumerator LoadYourAsyncScene()
    //{
    //    // Set the current Scene to be able to unload it later
    //    Scene currentScene = SceneManager.GetSceneByName("Intro");

    //    // The Application loads the Scene in the background at the same time as the current Scene.
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

    //    // Wait until the last operation fully loads to return anything
    //    while (!asyncLoad.isDone)
    //    {
    //        yield return null;
    //    }
    //    SceneManager.UnloadSceneAsync(currentScene);
    //}

    
    private async void TransitionToMainScene()
    {
        SoundManager.instance.StartFireBGM();
        IMixedRealitySceneSystem sceneSystem = MixedRealityToolkit.Instance.GetService<IMixedRealitySceneSystem>();
        await sceneSystem.LoadContent(mainScene, LoadSceneMode.Single);

        GameObject startMesh = GameObject.Find("StartButtonMesh");
        
        if (startMesh) Destroy(startMesh);
        
        //if (prevSceneRequested && sceneSystem.PrevContentExists)
        //{
        //    await sceneSystem.LoadPrevContent();
        //}
    }


}
