using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class heal : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger = null;
    public GameObject playerHealth;

    private SteamVR_Behaviour_Pose mPose = null;

    // Start is called before the first frame update
    void Start()
    {
        mPose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetStateDown(mPose.inputSource))
        {
            print("clicked trigger");
            string curHP = playerHealth.GetComponent<Text>().text;
            int curHPInt = Int32.Parse(curHP);
            curHPInt+=10;
            playerHealth.GetComponent<Text>().text = curHPInt.ToString();

        }
    }
}
