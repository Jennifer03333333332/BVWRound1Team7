using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElfMovement : MonoBehaviour
{
    [Tooltip("State")]
    public string[] stateArray;
    public string currentState;

    public Vector3 moveDir;
    public float speed;
    //[Tooltip("Elf will moving towards game objects in this list.")]
    

    //About Path finding
    public GameObject targetFolder;
    private Transform[] targetTransforms;
    public int nowTargetIndex;
    public int TargetNum;
    


    // Used to keep track of the last forward direction for idle animations
    private Vector2 lastMoveDir = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        //stateArray[0] = "Moving";
        //stateArray[1] = "Dead";
        currentState = stateArray[0];
        speed = 1f;
        //Path finding
        targetFolder = GameObject.Find("ElvesPathPoints");
        targetTransforms = targetFolder.GetComponentsInChildren<Transform>();
        nowTargetIndex = 0;
        TargetNum = targetTransforms.Length;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    //Make the target random
    public void MakeTargetPosRandom()
    {
        int index = UnityEngine.Random.Range(0, TargetNum);
        while (nowTargetIndex == index)
        {
            index = UnityEngine.Random.Range(0, TargetNum);
        }
        nowTargetIndex = index;
        //return targetTransforms[index];//targetTransforms[nowTargetIndex]
    }
    public void ChangeElfState(int _state)
    {
        currentState = stateArray[_state];
    }

    // Used for physics updates
    private void FixedUpdate()
    {
        if (currentState == stateArray[0])
        {
            Transform nowTarget = targetTransforms[nowTargetIndex];//MakeTargetPosRandom();
            // Get desired motion
            moveDir = (nowTarget.position - transform.position).normalized*speed;
            moveDir.y = 0;


            // Apply motion
            //GetComponent<Rigidbody>().velocity = new Vector3(moveDir.x, GetComponent<Rigidbody>().velocity.y, moveDir.z);
            GetComponent<Rigidbody>().velocity = new Vector3(moveDir.x, 0, moveDir.z);
            if (moveDir.magnitude <= 0.1)
            {
                if (lastMoveDir.magnitude != 0)
                {
                    transform.forward = lastMoveDir.normalized;
                }
                MakeTargetPosRandom();
            }
            else
            {
                lastMoveDir = moveDir;
                transform.forward = moveDir.normalized;
            }

            // Update animator
            //animator.SetFloat("MoveSpeed", moveDir.magnitude);
            //if (moveDir.magnitude > 0)
            //    animator.speed = moveDir.magnitude;
            //else
            //    animator.speed = 1;
        }
        else if(currentState == stateArray[1])
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
            
        }

    }
}
