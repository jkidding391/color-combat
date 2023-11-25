using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldScript : MonoBehaviour
{
    public Renderer colorRender;
    public GameObject wall;

    [SerializeField] private string currentColor;
    private string[] colorList = {"Red", "Blue", "Yellow", "Green"}; //List of possible colors
    int i;

    // Start is called before the first frame update
    void Start()
    {   
        currentColor = transform.GetComponentInParent<EnemyColorController>().GetColor();

        while (currentColor == transform.GetComponentInParent<EnemyColorController>().GetColor()) { //Makes sure shield is different color than enemy
            i = Random.Range(0,colorList.Length);
            currentColor = colorList[i];

        }

        colorRender = wall.GetComponent<Renderer>();
        ChangeMaterial(currentColor);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void ChangeMaterial(string colorInput) {
        if (colorInput == "Red") {
            currentColor = "Red";
            colorRender.material.color = Color.red;

        }//if
        else if (colorInput == "Yellow") {
            currentColor = "Yellow";
            colorRender.material.color = Color.yellow;

        }//else-if
        else if (colorInput == "Blue") {
            currentColor = "Blue";
            colorRender.material.color = Color.blue;

        }//else-if
        else if (colorInput == "Green") {
            currentColor = "Green";
            colorRender.material.color = Color.green;

        }//else-if
        
    }

    public string getColor() {
        return currentColor;

    }

    void OnCollisionEnter(Collision other) {
        //Debug.Log("hit");

        if (other.gameObject.CompareTag("Wall")) {

            //Debug.Log("Touch");
            //Debug.Log(gameObject.GetComponent<EnemyColorController>().GetColor());

            Physics.IgnoreCollision(transform.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);
            //Physics.IgnoreCollision(transform.GetComponent<CharacterController>(), other.gameObject.GetComponent<Collider>(), true);    //Apparently charactercontroller is a collider and was causing problems :/

            //Debug.Log("Should ignore");

        }//if
        /*else {
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), false);

        }//else*/

    }
    
}
