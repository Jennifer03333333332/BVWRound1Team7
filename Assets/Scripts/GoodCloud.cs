using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCloud : MonoBehaviour
{
    public float disappearingSpeed;
    public float objScale;
    private bool raining = false;
    public float waitCloudDestroyTime;

    [SerializeField] private GameObject rainController;

    void Start()
    {
        StartCoroutine(Destroy(disappearingSpeed));
    }
    void Update()
    {
        if (this.transform.localScale.x >= 13 && !raining && gameObject.tag == "GoodCloud")
        {
            raining = true;
            Rain();
        }
        if(!raining)
        {
            transform.localScale = new Vector3(objScale + Mathf.Sin(Time.time), objScale + Mathf.Sin(Time.time), objScale + Mathf.Sin(Time.time));
            transform.Rotate(0f, Time.deltaTime, 0f, Space.Self);
        }
    }
    public void Rain()
    {
        rainController.SetActive(true);
        StartCoroutine(Destroy(waitCloudDestroyTime));
        SoundManager.instance.PlayingSound("Rain");
    }

    IEnumerator Destroy(float waitCloudDestroyTime)
    {
        yield return new WaitForSeconds(waitCloudDestroyTime);
        Destroy(gameObject);
    }
}
