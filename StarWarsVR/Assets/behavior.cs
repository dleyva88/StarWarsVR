using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(GameObject.Find("walkerTarget").transform);

        transform.position += transform.forward * 2.0f * Time.smoothDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("collision detected");
        print("Name of other collider: " + other.transform.gameObject.name);
        if (other.transform.gameObject.name.Equals("Player"))
        {
            Debug.Log("The Player got hit!");

            //Take damage
            //Destroy(this.gameObject);
        }
        else if (other.transform.gameObject.name.Equals("Hilt"))
        { 
            other.GetComponent<killCounter>().numKilled++;

            if (other.GetComponent<killCounter>().numKilled <= other.GetComponent<killCounter>().maxKilled/2)
            {
                int newX = Random.Range(10, 40);
                int newZ = Random.Range(10, 40);

                int dirX = Random.Range(0, 2) == 0 ? -1 : 1;
                int dirZ = Random.Range(0, 2) == 0 ? -1 : 1;

                Vector3 newLocation = new Vector3(500 + dirX * newX, 0, 500 + dirZ * newZ);
                
                var newDroid = Instantiate(this.gameObject, newLocation, this.transform.rotation);

                newX = Random.Range(10, 40);
                newZ = Random.Range(10, 40);

                dirX = Random.Range(0, 2) == 0 ? -1 : 1;
                dirZ = Random.Range(0, 2) == 0 ? -1 : 1;

                newLocation = new Vector3(500 + dirX * newX, 0, 500 + dirZ * newZ);

                newDroid = Instantiate(this.gameObject, newLocation, this.transform.rotation);
            }

            Destroy(this.gameObject);
        }
    }
}
