﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = .01f;
    int direction = 1;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * transform.forward * 25.0f * Time.smoothDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name.Equals("player"))
        {
            Debug.Log("The player got hit!");

            Destroy(this.gameObject);
        }
        else if (other.transform.gameObject.name.Equals("Lightsaber"))
        {
            Debug.Log("Hit lightsaber");

            direction = -1;
        }
    }
}
