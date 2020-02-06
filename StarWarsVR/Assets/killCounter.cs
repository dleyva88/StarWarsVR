using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxKilled = 6;
    public int numKilled = 0;

    public GameObject boss;

    private void OnTriggerEnter(Collider other)
    {
        print("collision detected");
        print("Name of other collider: " + other.transform.gameObject.name);
        if (other.transform.gameObject.name.StartsWith("Robots_Prowler"))
        {
            print("Num Killed: " + numKilled);
            if(numKilled == maxKilled)
            {
                boss.SetActive(true);
            }
        }
    }
}
