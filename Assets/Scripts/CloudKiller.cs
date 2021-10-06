using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "GoodCloud" || other.gameObject.tag == "BadCloud")
            Destroy(other.gameObject);
    }
}
