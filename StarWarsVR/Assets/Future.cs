using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Future : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger = null;

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
            print("Sqeezed grip");
            foreach (GameObject robot in GameObject.FindGameObjectsWithTag("Lightningable"))
            {
                Transform future_robot = robot.transform.Find("Future_Robots_Prowler");
                future_robot.gameObject.SetActive(true);
            }

        }
        else if (trigger.GetStateUp(mPose.inputSource))
        {
            foreach (GameObject robot in GameObject.FindGameObjectsWithTag("Lightningable"))
            {
                Transform future_robot = robot.transform.Find("Future_Robots_Prowler");
                future_robot.gameObject.SetActive(false);
            }
        }
    }
}
