using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemyColorController : MonoBehaviour
{
    public Renderer colorRender;
    public GameObject enemy;

    //Color Shenanigans
    [SerializeField] private string currentColor;
    private string[] colorList = {"Red", "Blue", "Yellow", "Green"}; //List of possible colors
    int i;
    // Start is called before the first frame update

    void Start()
    {
        i = Random.Range(0,4);
        currentColor = colorList[i];
        colorRender = enemy.GetComponent<Renderer>();
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


    public string GetColor(){
        return currentColor;

    }

}
