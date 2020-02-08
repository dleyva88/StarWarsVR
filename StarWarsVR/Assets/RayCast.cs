using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
using DigitalRuby.LightningBolt;
using Random = UnityEngine.Random;

public class RayCast : MonoBehaviour
{
    public SteamVR_Action_Boolean grab = null;
    public SteamVR_Action_Boolean unlimitedPower = null;
    public SteamVR_Action_Boolean forcePush = null;
    public GameObject hand = null;
    public GameObject lightning;
    public GameObject forceBlast;

    private SteamVR_Behaviour_Pose mPose = null;
    private FixedJoint mJoint = null;

    private Interactable mCurrentInteractable = null;
    private List<Interactable> mContactIneractables = new List<Interactable>();

    private Tuple<GameObject, GameObject> forcePoint;
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
        RaycastHit hit;
        if (grab.GetStateDown(mPose.inputSource))
        {
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                // If it does hit an object, use the trigger to grab that object

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
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

        if (forcePoint != null)
        {
            forcePoint.Item2.GetComponent<Rigidbody>().AddForceAtPosition(
                (forcePoint.Item1.transform.position - forcePoint.Item2.transform.position).normalized
                * Vector3.Distance(forcePoint.Item1.transform.position, forcePoint.Item2.transform.position)
                * Vector3.Distance(forcePoint.Item1.transform.position, forcePoint.Item2.transform.position)
                * force, forcePoint.Item2.transform.position);
        }

        if (unlimitedPower.GetState(mPose.inputSource))
        {
            lightning.GetComponent<LightningBoltScript>().ManualMode = false;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                // If it does hit an object, use the trigger to grab that object

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("It Hit " + hit.collider.gameObject.tag);

                if (hit.collider.gameObject.tag == "Lightningable")
                {
                    int newX = Random.Range(10, 40);
                    int newZ = Random.Range(10, 40);

                    int dirX = Random.Range(0, 2) == 0 ? -1 : 1;
                    int dirZ = Random.Range(0, 2) == 0 ? -1 : 1;

                    Vector3 newLocation = new Vector3(500 + dirX * newX, 0, 500 + dirZ * newZ);

                    var newDroid = Instantiate(hit.collider.gameObject, newLocation, hit.collider.gameObject.transform.rotation);

                    newX = Random.Range(10, 40);
                    newZ = Random.Range(10, 40);

                    dirX = Random.Range(0, 2) == 0 ? -1 : 1;
                    dirZ = Random.Range(0, 2) == 0 ? -1 : 1;

                    newLocation = new Vector3(500 + dirX * newX, 0, 500 + dirZ * newZ);

                    newDroid = Instantiate(hit.collider.gameObject, newLocation, hit.collider.gameObject.transform.rotation);


                    Debug.Log(mPose.inputSource + "Trigger Down on " + hit.collider.gameObject.name);
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        if (unlimitedPower.GetStateUp(mPose.inputSource))
        {
            lightning.GetComponent<LightningBoltScript>().ManualMode = true;
        }

        if (forcePush.GetStateDown(mPose.inputSource))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                // If it does hit an object, use the trigger to grab that object

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("It Hit " + hit.collider.gameObject.tag);

                if (hit.collider.gameObject.tag == "Lightningable")
                {
                    GameObject explosion = Instantiate(forceBlast, hit.transform);
                    explosion.SetActive(true);
                }
            }
        }

        if (forcePush.GetStateUp(mPose.inputSource))
        {
        }
    }
}

