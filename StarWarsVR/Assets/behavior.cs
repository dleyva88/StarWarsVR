using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behavior : MonoBehaviour
{
    public int maxWave = 3;
    int curWave = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(GameObject.Find("player").transform);

        transform.position += transform.forward * 2.0f * Time.smoothDeltaTime;
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

            if (curWave < maxWave)
            {
                int newX = Random.Range(100, 400);
                int newZ = Random.Range(100, 400);

                int dirX = Random.Range(0, 2) == 0 ? -1 : 1;
                int dirZ = Random.Range(0, 2) == 0 ? -1 : 1;

                Vector3 newLocation = new Vector3(500 + dirX * newX, 0, 500 + dirZ * newZ);
                
                var newDroid = Instantiate(this.gameObject, newLocation, this.transform.rotation);
                newDroid.GetComponent<behavior>().curWave++;

                newX = Random.Range(100, 400);
                newZ = Random.Range(100, 400);

                dirX = Random.Range(0, 2) == 0 ? -1 : 1;
                dirZ = Random.Range(0, 2) == 0 ? -1 : 1;

                newLocation = new Vector3(500 + dirX * newX, 0, 500 + dirZ * newZ);

                newDroid = Instantiate(this.gameObject, newLocation, this.transform.rotation);
                newDroid.GetComponent<behavior>().curWave++;
            }

            Destroy(this.gameObject);
        }
    }
}
