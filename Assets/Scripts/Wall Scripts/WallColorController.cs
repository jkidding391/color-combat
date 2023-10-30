using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColorController : MonoBehaviour
{

    public Renderer colorRender;
    public GameObject wall;

    [SerializeField] private string currentColor = "Red";

    // Start is called before the first frame update
    void Start()
    {
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

}
