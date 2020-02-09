using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boss_behavior : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().destination = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * 2.0f * Time.smoothDeltaTime;
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
        else if (other.transform.gameObject.name.Equals("BossKiller"))
        {
            StartCoroutine(death());

            
        }
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
