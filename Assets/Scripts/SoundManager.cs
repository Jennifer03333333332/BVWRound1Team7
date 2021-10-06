using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Serializable]
    public struct SoundGroup
    {
        public AudioClip audioClip;
        public string soundName;
    }
    public List<SoundGroup> sound_List = new List<SoundGroup>();

    public AudioSource PeaceBGM;
    public AudioSource FireBGM;
    public static SoundManager instance;

    private IEnumerator coroutine;

    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        //coroutine = StartPeaceBGM();
        //StartCoroutine(coroutine);
    }

    //when video ends
    public void StartPeaceBGM()
    {
        print("StartPeaceBGM");
        //yield return new WaitForSeconds(0.5f);
        PeaceBGM.Play();
    }

    //when game starts
    public void StartFireBGM()
    {
        //StopCoroutine(StartPeaceBGM());
        PeaceBGM.Stop();
        print("StartFireBGM");
        //yield return new WaitForSeconds(0.5f);
        FireBGM.Play();

        //shit
    }

    //When game lost
    public void Defeat()
    {
        FireBGM.Stop();
        PeaceBGM.Stop();
        PlayingSound("Defeat");
    }

    public void Victory()
    {
        FireBGM.Stop();
        PeaceBGM.Stop();
        PlayingSound("Victory");
    }


    public void PlayingSound(string _soundName)
    {
        AudioSource.PlayClipAtPoint(sound_List[FindSound(_soundName)].audioClip, Camera.main.transform.position);
    }
    public int FindSound(string _soundName)
    {
        int i = 0;
        while (i < sound_List.Count)
        {
            if (sound_List[i].soundName == _soundName)
            {
                return i;
            }
            i++;
        }
        return i;
    }
}
