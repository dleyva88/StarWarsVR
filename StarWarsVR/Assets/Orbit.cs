using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public float speed = 0.1f;
    public GameObject bulletPrefab;
    int fire = 60;
    int counter = 0;
    int direction = 1;
    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, speed);
        transform.Translate(direction * speed, 0, 0);
        counter++;
        if (counter >= fire)
        {
            Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            this.gameObject.GetComponent<AudioSource>().Play();
            fire = Random.Range(10, 60);
            //print(fire);
            if (fire % 2 == 0)
                direction = 1;
            else
                direction = -1;

            counter = 0;
        }
    }
}
