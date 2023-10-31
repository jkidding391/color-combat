using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {

        //Debug.Log("touch1");
        if (other.gameObject.CompareTag("Wall") && (other.gameObject.GetComponentInParent<WallColorController>().getColor() == GetComponent<ColorController>().getColor())) {

            //Debug.Log("Touch");
            //Debug.Log(other.gameObject.GetComponentInParent<WallColorController>().getColor());

            Physics.IgnoreCollision(transform.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);

        }//if
        else {
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), false);

        }//else

    }
}
