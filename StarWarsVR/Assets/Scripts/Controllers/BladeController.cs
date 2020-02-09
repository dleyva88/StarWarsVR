using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BladeController : MonoBehaviour
{
    public AudioClip BladeConstantSound;
    public AudioClip BladeReflectSound;
    public AudioClip BladeOnSound;
    public Light BladeLight;

    public GameObject bossKiller;

    private AudioSource mAudioSource;


    private void Start()
    {
        //mBlade = GetComponent<MeshRenderer>();
        mAudioSource = GetComponent<AudioSource>();
        mAudioSource.PlayOneShot(BladeOnSound);
        mAudioSource.clip = BladeConstantSound;
        mAudioSource.Play();
        BladeLight.intensity = 1;
    }
    

    void OnTriggerEnter(Collider other)
    {
        print("Colliding With: " + other.transform.gameObject.name);
        if (other.transform.gameObject.name.StartsWith("Bullet") || other.transform.gameObject.name.StartsWith("Robots_Prowler"))
        {
            mAudioSource.PlayOneShot(BladeReflectSound);
        }

        if (other.transform.gameObject.name.StartsWith("Blade"))
        {
            bossKiller.SetActive(true);
        }

    }
}
