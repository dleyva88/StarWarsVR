using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behavior : MonoBehaviour
{
    public int maxWave = 10;
    int curWave = 0;
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
                float newX = Random.Range(-50f, 50f);
                float newZ = Random.Range(-50f, 50f);

                Vector3 newLocation = new Vector3(500 + newX, 0, 500 + newZ);
                
                var newDroid = Instantiate(this.gameObject, newLocation, this.transform.rotation);
                newDroid.GetComponent<behavior>().curWave++;

                newX = Random.Range(-50f, 50f);
                newZ = Random.Range(-50f, 50f);

                newLocation = new Vector3(500 + newX, 0, 500 + newZ);

                newDroid = Instantiate(this.gameObject, newLocation, this.transform.rotation);
                newDroid.GetComponent<behavior>().curWave++;
            }

            Destroy(this.gameObject);
        }
    }
}
