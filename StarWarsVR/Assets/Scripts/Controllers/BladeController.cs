using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BladeController : MonoBehaviour
{
    public AudioClip BladeConstantSound;
    public AudioClip BladeReflectSound;
    public Light BladeLight;

    public GameObject Explosion;

    private AudioSource mAudioSource;


    private void Start()
    {
        //mBlade = GetComponent<MeshRenderer>();
        mAudioSource = GetComponent<AudioSource>();
        mAudioSource.clip = BladeConstantSound;
        mAudioSource.Play();
        BladeLight.intensity = 1;
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name.StartsWith("Bullet") || other.transform.gameObject.name.StartsWith("Robots_Prowler"))
        {
            mAudioSource.PlayOneShot(BladeReflectSound);

            if (!other.transform.gameObject.name.StartsWith("Bullet"))
            {
                GameObject explosion = Instantiate(Explosion, other.gameObject.transform);
                explosion.SetActive(true);
            }
        }
    }
}
