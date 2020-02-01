using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberPurple : MonoBehaviour
{
    LineRenderer lineRend;
    public Transform startPos;
    public Transform endPos;
    public AudioClip BladeOnSound;
    public AudioClip BladeOffSound;
    public AudioClip BladeConstantSound;
    public AudioClip BladeReflectSound;

    private float textureOffset = 0;
    private bool isOn = true;
    private Vector3 extendedEndPos;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        extendedEndPos = endPos.localPosition;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BladeConstantSound;
    }

    // Update is called once per frame
    void Update()
    {
        // Turn lightsaber on and off
        if(Input.GetKeyDown(KeyCode.Menu))
        {
            if(isOn)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(BladeOffSound);
                isOn = false;
            }
            else
            {
                audioSource.PlayOneShot(BladeOnSound);
                audioSource.Play();
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
