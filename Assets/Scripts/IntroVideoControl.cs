using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class IntroVideoControl : MonoBehaviour
{
    private VideoPlayer m_VideoPlayer;
    GameObject StartBtn;
    GameObject StartTextMesh;
    private float beginning;
    private float video_length;
    void Awake()
    {
        video_length = 25;
        StartBtn = GameObject.Find("StartButtonMesh");
        StartTextMesh = GameObject.Find("StartTextMesh");
        m_VideoPlayer = GetComponent<VideoPlayer>();

        beginning = Time.time;
        m_VideoPlayer.Play();
        StartCoroutine(waitmethod());
    }

    private IEnumerator waitmethod()
    {
        while (Time.time - beginning < video_length)
        {
            //print(Time.time);
            yield return null;
        }
        OnMovieFinished();
    }


    void OnMovieFinished()
    {
        Debug.Log("Event for movie end called");
        var allrenderer = StartBtn.GetComponentsInChildren<Renderer>();
        foreach (var renderer in allrenderer)
        {
            renderer.enabled = true;
        }
        //StartBtn.GetComponent<Renderer>().enabled = true;
        //StartTextMesh.GetComponent<Renderer>().enabled = true;
        SoundManager.instance.StartPeaceBGM();
        m_VideoPlayer.Stop();
        //close the video
        GameObject.Find("Video").SetActive(false);
        
        //Destroy(gameObject);
        //gameObject.GetComponent<Renderer>().enabled = false;
    }

}