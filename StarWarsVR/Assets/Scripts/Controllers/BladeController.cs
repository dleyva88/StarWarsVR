using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BladeController : MonoBehaviour
{
    public float ActivateSpeed = 5;
    public AudioClip BladeConstantSound;
    public AudioClip BladeReflectSound;
    public Light BladeLight;

    private AudioSource mAudioSource;

    private bool mIsOn;
    private float mTargetScale;

    private void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
        mAudioSource.clip = BladeConstantSound;
        mAudioSource.Play();
        BladeLight.intensity = 1;
    }
    
    void FixedUpdate()
    {
        // Move towards the target scale with constant step.
        transform.localScale = new Vector3(transform.localScale.x,
            Mathf.MoveTowards(transform.localScale.y, mTargetScale, ActivateSpeed * Time.deltaTime),
            transform.localScale.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (mIsOn)
        {         
            Destroyable destroyable = other.gameObject.GetComponent<Destroyable>();
            if (destroyable)
            {
                destroyable.Destroyed();
            }
        }
    }
}
