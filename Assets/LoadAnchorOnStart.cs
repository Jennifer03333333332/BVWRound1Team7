using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAnchorOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AnchorModuleScript>().StartAzureSession();
        this.GetComponent<AnchorModuleScript>().GetAzureAnchorIdFromNetwork();
        this.GetComponent<AnchorModuleScript>().FindAzureAnchor();
    }
}
