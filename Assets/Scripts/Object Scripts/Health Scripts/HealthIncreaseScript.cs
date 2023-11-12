using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncreaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (other.GetComponent<HealthScript>().currentHealth != other.GetComponent<HealthScript>().maxHealth) {

             other.GetComponent<HealthScript>().IncreaseHealth();
                Destroy(gameObject);

            }

        }
    }
}
