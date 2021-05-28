using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;


public class IKBind : MonoBehaviour
{
    private VRIK vrik;
    private bool isLeftArm = false;
    private bool isRightArm = false;


    private void Awake()
    {
        vrik = GetComponent<VRIK>();
    }

    private void Start()
    {
        vrik.solver.spine.headTarget = GameObject.FindGameObjectWithTag("NickHead").transform;
        vrik.solver.spine.headTarget = GameObject.FindGameObjectWithTag("RArmHand").transform;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("LArmHand") != null)
        {
            if (isLeftArm == false)
            {
                vrik.solver.leftArm.target = GameObject.FindGameObjectWithTag("LArmHand").transform;
                isLeftArm = true;
            }
        }

        if (GameObject.FindGameObjectWithTag("RArmHand") != null)
        {
            if (isRightArm == false)
            {
                vrik.solver.rightArm.target = GameObject.FindGameObjectWithTag("RArmHand").transform;
                isRightArm = true;
            }
        }
    }
}
