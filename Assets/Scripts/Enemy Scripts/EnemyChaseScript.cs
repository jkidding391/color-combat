using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseScript : MonoBehaviour
{
    void Start()
    {
        //Physics.IgnoreLayerCollision(2,6);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        /*if(other.gameObject.CompareTag("Wall")) {
            Debug.Log("Wall Hit");
        }*/
        if (other.gameObject.name == "Player") {
            transform.parent.GetComponent<EnemyScript>().isChase(false);

        }//if

    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.name == "Player") {
            transform.parent.GetComponent<EnemyScript>().isChase(true);

        }//if

    }
}

