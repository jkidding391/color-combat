using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyWallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Physics.IgnoreLayerCollision(2,6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision other) {
        //Debug.Log("hit");

        if (other.gameObject.CompareTag("Wall") && (other.gameObject.GetComponentInParent<WallColorController>().getColor() == GetComponent<EnemyColorController>().GetColor())) {

            Debug.Log("Touch");
            Debug.Log(gameObject.GetComponent<EnemyColorController>().GetColor());

            Physics.IgnoreCollision(transform.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);

        }//if
        /*else {
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), false);

        }//else*/

    }
}
