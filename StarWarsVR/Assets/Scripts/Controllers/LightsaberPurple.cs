﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberPurple : MonoBehaviour
{
    LineRenderer lineRend;
    public Transform startPos;
    public Transform endPos;

    private float textureOffset = 0;
    private bool isOn = false;
    private Vector3 extendedEndPos;

    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        extendedEndPos = endPos.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Turn lightsaber on and off
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isOn)
            {
                isOn = false;
            }
            else
            {
                isOn = true;
            }
        }

        // Extend or hide line
        if(isOn)
        {
            endPos.localPosition = Vector3.Lerp(endPos.localPosition, extendedEndPos, Time.deltaTime * 5);
        }
        else
        {
            endPos.localPosition = Vector3.Lerp(endPos.localPosition, startPos.localPosition, Time.deltaTime * 5);
        }
        // Update line positions
        lineRend.SetPosition(0, startPos.position);
        lineRend.SetPosition(1, endPos.position);

        // Pan texture
        textureOffset -= Time.deltaTime * 2;
        if(textureOffset < -10)
        {
            textureOffset += 10;
        }
        lineRend.sharedMaterials[1].SetTextureOffset("_MainTex", new Vector2(textureOffset, 0));
    }
}
