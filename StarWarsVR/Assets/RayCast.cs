﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

//https://connect.unity.com/p/steamvr-2-0-starter-migration-action-sets

public class RayCast : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
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
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

    }
}
