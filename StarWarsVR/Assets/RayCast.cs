using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class RayCast : MonoBehaviour
{
    public SteamVR_Action_Boolean grab = null;
    public GameObject hand = null;

    private SteamVR_Behaviour_Pose mPose = null;
    private FixedJoint mJoint = null;

    private Interactable mCurrentInteractable = null;
    private List<Interactable> mContactIneractables = new List<Interactable>();

    private Tuple<GameObject,GameObject> forcePoint;
    public float force;
    public float drag;

    private void Awake()
    {
        mPose = GetComponent<SteamVR_Behaviour_Pose>();
        mJoint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        //int layerMask = 1 << 8;

        //// This would cast rays only against colliders in layer 8.
        //// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;
        if (grab.GetStateDown(mPose.inputSource))
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + Vector3.down), out hit, Mathf.Infinity))
            {
                // If it does hit an object, use the trigger to grab that object

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + Vector3.down) * hit.distance, Color.yellow);
                Debug.Log("It Hit " + hit.collider.gameObject.tag);

                if (hit.collider.gameObject.tag == "Selectable")
                {
                    Debug.Log(mPose.inputSource + "Trigger Down on " + hit.collider.gameObject.name);
                    GameObject temp = new GameObject("ForcePoint");
                    temp.transform.position = hit.transform.position;
                    temp.transform.parent = transform;
                    forcePoint = new Tuple<GameObject, GameObject>(temp, hit.collider.gameObject);
                    forcePoint.Item2.GetComponent<Rigidbody>().drag = drag;
                }
            }

        }

        if (grab.GetStateUp(mPose.inputSource))
        {
            Debug.Log(mPose.inputSource + "Trigger Up");
            forcePoint.Item2.GetComponent<Rigidbody>().drag = 0;
            forcePoint = null;
        }

        if(forcePoint != null)
        {
            forcePoint.Item2.GetComponent<Rigidbody>().AddForceAtPosition(
                (forcePoint.Item1.transform.position - forcePoint.Item2.transform.position).normalized
                * Vector3.Distance(forcePoint.Item1.transform.position, forcePoint.Item2.transform.position)
                * Vector3.Distance(forcePoint.Item1.transform.position, forcePoint.Item2.transform.position)
                * force, forcePoint.Item2.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {

    }

    private void Pickup(GameObject obj)
    {
        Rigidbody gravity = obj.GetComponent<Rigidbody>();
        gravity.useGravity = false;

        Vector3 current = obj.transform.position;
        Vector3 handPos = hand.transform.position;
        
    }

    private void Drop()
    {

    }

    private Interactable GetNearestInteractable()
    {
        return null;
    }
}
