using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

// https://circuitstream.com/blog/htc-vive-tutorial-raycasting/ 

public class VRRaycast : MonoBehaviour
{
    protected RaycastHit rayHit;
    protected GameObject hitObject;

    void Awake()
    {
        //If attached to head, will return null (expected behavior)
        Input input = GetComponent()

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        //Check if raycast hits anything
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit))
        {
            //If the object is the same as the one we hit last frame
            if (hitObject != null && hitObject == rayHit.transform.gameObject)
            {
                //Trigger "Stay" method on Interactable every frame we hit
                RayStay(rayHit);
            }

            //We're still hitting something, but it's a new object
            else
            {
                //Keep track of new object that we're hitting
                hitObject = rayHit.transform.gameObject;
            }
        }
        // We're still hitting something, but it's a new object
        else
        {
            //Keep track of new object that we're hitting, and trigger the ray "Enter" method on Interactable
            hitObject = rayHit.transform.gameObject;
            RayEnter(rayHit);

        }
    }

    protected void RayEnter(RaycastHit hit)
    {

    }


    protected void RayStay(RaycastHit hit)
    {


    }


    protected void RayExit()

    {


    }
}
