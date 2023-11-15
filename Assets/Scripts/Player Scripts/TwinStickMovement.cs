using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class TwinStickMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float controllerDeadzone = 0.1f;
    //[SerializeField] private float gamepadRotateSmoothing = 1000f;

    [SerializeField] private bool isGamepad;

    private CharacterController controller;

    private Vector2 movement;
    private Vector2 aim;

    private Vector3 playerVelocity;

    private PlayerControls playerControls;
    private PlayerInput playerInput;
    [SerializeField] GameObject pauseMenu;


    private void Awake() {
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();

    }
    private void OnEnable() {
        playerControls.Enable();

    }

    private void OnDisable() {
        playerControls.Disable();

    }

    void Start()
    {
        
    }

    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
        HandlePause();
        
    }

    void HandleInput() {
        movement = playerControls.Controls.Movement.ReadValue<Vector2>();   //Reads WASD or Left Joystick to move player
        aim = playerControls.Controls.Aim.ReadValue<Vector2>();             //Reads mouse position or Right Joystick to rotate player

    }

    void HandleMovement() {
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;  //Deals with gravity incase the player's Y-value changes on accident
        controller.Move(playerVelocity * Time.deltaTime);

    }

    void HandleRotation() {
        if (isGamepad) {

            //Rotate player
            if (Mathf.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone) {   //If the controller's Right Joystick value is greater than the deadzone, it will rotate the player
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;

                if (playerDirection.sqrMagnitude > 0.0f) {
                    Quaternion newrotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = newrotation;

                }//if

            }//if

        }//if

        else {
            Ray ray = Camera.main.ScreenPointToRay(aim);    //If the mouse is used, it casts a ray from the camera to the mouse position on the screen
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance)) {
                Vector3 point = ray.GetPoint(rayDistance);
                LookAt(point);  //Looks at the location of the mouse curser

            }//if

        }//else

    }

    private void LookAt(Vector3 lookPoint) {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z); //Makes sure the player doesn't rotate up or down based on if the mouse position is on another object
        transform.LookAt(heightCorrectedPoint);

    }

    public void OnDeviceChange (PlayerInput pi) {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;

    }

    public void HandlePause() {
        if (playerControls.Controls.Pause.IsPressed() == true) {
            pauseMenu.GetComponent<PauseScript>().Pause();
            
        }
    }

   
}
