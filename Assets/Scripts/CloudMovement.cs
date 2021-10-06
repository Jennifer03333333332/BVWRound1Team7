using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 endPoint;
    public float smoothTime = 5f;
    private Vector3 velocity = Vector3.zero;
    public float objScale;
    public float waitCloudBoom;

    [SerializeField] private GameObject lightningController;
    [SerializeField] private GameObject fireController;


    void Start()
    {
        fireController = GameObject.Find("FireSpawner");
        smoothTime /= moveSpeed;
    }
    void Update()
    {
        if (moveSpeed > 0)
        {
            Vector3 movement = new Vector3(0, 0, 0);
            if(endPoint.x > this.transform.position.x)
                movement += new Vector3(1, 0, 0);
            else if(endPoint.x < this.transform.position.x)
                movement -= new Vector3(1, 0, 0);
            if (endPoint.z > this.transform.position.z)
                movement += new Vector3(0, 0, 1);
            else if(endPoint.z < this.transform.position.z)
                movement -= new Vector3(0, 0, 1);
            transform.position = Vector3.SmoothDamp(transform.position, transform.position + movement + new Vector3(0, Mathf.Sin(Time.time)/2, 0.0f), ref velocity, smoothTime, moveSpeed);
            transform.localScale = new Vector3(objScale+Mathf.Sin(Time.time), objScale+Mathf.Sin(Time.time), objScale+Mathf.Sin(Time.time));
            transform.Rotate(0f, moveSpeed * Time.deltaTime, 0f, Space.Self);
        }
    }
    public void SetMove1()
    {
        moveSpeed = 1;
    }
    public void SetMove0()
    {
        moveSpeed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "BadCloud" && other.gameObject.tag == "BadCloud" )
        {

            if(!lightningController.activeSelf && !other.GetComponent<CloudMovement>().lightningController.activeSelf)
            {
                lightningController.SetActive(true);
                other.GetComponent<CloudMovement>().lightningController.SetActive(true);
                SoundManager.instance.PlayingSound("Thunder");
                StartCoroutine(CloudExplosion(waitCloudBoom, other));
            }
        }
    }
    IEnumerator CloudExplosion(float waitCloudBoom, Collider other)
    {
        yield return new WaitForSeconds(waitCloudBoom);
        fireController.GetComponent<FireSpawn>().CreateFire();
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
