using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorController : MonoBehaviour
{

    public Renderer colorRender;
    public GameObject player;

    //Color shenanigans
    [SerializeField] private string currentColor; //Can change the default color in a scene

    //Controller shenanigans
    private PlayerControls playerControls;
    [SerializeField] private float coolDown = 0.1f;
    bool canChange = true;

    //More controller shenanigans
    private void Awake() {
        playerControls = new PlayerControls();

    }
    private void OnEnable() {
        playerControls.Enable();

    }

    private void OnDisable() {
        playerControls.Disable();

    }

    // Start is called before the first frame update
    void Start()
    {
        colorRender = player.GetComponent<Renderer>();
        ChangeMaterial(currentColor);
        
    }

    // Update is called once per frame
    void Update()
    {
        handleInput();
        
    }

    IEnumerator coolDownTimer(){
        canChange = false;
        yield return new WaitForSeconds(coolDown);
        canChange = true;

    }

    public void handleInput() {
        if (!canChange) return;

        if (playerControls.Controls.ChangeColorRed.IsPressed() == true) {
            ChangeMaterial("Red");

        }//if
        else if (playerControls.Controls.ChangeColorYellow.IsPressed() == true) {
            ChangeMaterial("Yellow");

        }//else-if
        else if (playerControls.Controls.ChangeColorBlue.IsPressed() == true) {
            ChangeMaterial("Blue");
        
        }//else-if
        else if (playerControls.Controls.ChangeColorGreen.IsPressed() == true) {
            ChangeMaterial("Green");

        }//else-if

        StartCoroutine(coolDownTimer());
        
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

    public string getColor(){
        return currentColor;

    }

}
