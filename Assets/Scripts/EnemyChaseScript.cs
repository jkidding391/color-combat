using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            transform.parent.GetComponent<EnemyScript>().isChase();

        }//if

    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.name == "Player") {
            transform.parent.GetComponent<EnemyScript>().isChase();

        }//if

    }
}

