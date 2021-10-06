using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviors : MonoBehaviour
{
    public float waitCloudDestroyTime;
    public float scaleChangedLevel;
    private bool IsChanging;
    private Vector3 BeforeScale;

    // Start is called before the first frame update
    void Start()
    {
        IsChanging = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WhenUnderControl()
    {
        if ((transform.localScale - BeforeScale).magnitude > 0.1 && !IsChanging)
        {
            IsChanging = true;
            Jennifer._instance.BuildRain();
            StartCoroutine(Destroy(waitCloudDestroyTime));
        }
    }

    IEnumerator Destroy(float waitCloudDestroyTime)
    {
        yield return new WaitForSeconds(waitCloudDestroyTime);
        Destroy(gameObject);
    }
}
