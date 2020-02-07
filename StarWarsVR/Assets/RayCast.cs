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

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + Vector3.down), out hit, Mathf.Infinity))
        {
            // If it does hit an object, use the trigger to grab that object

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + Vector3.down) * hit.distance, Color.yellow);
            Debug.Log("It Hit " + hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "Selectable")
            {
                if(grab.GetStateDown(mPose.inputSource))
                {
                    print(mPose.inputSource + "Trigger Down on " + hit.collider.gameObject.name);
                    Pickup(hit.collider.gameObject);
                }

                if (grab.GetStateUp(mPose.inputSource))
                {
                    print(mPose.inputSource + "Trigger Up");
                    Drop();
                }
            }

            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
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

        Vector3 current = obj.transform.localPosition;
        Vector3 handPos = hand.transform.localPosition;
        
    }

    private void Drop()
    {

    }

    private Interactable GetNearestInteractable()
    {
        return null;
    }
}
