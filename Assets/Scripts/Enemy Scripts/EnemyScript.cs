using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float enemySpeed = 5f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] public string currentColor;
    private CharacterController controller;
    private Vector3 enemyVelocity;
    private bool ChaseCheck = true;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        
    }

    void Start()
    {
        currentColor = transform.GetComponent<EnemyColorController>().GetColor();
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleChase();
        
    }
    void OnTriggerEnter(Collider other) {   //Gets destroyed if it gets hit by the player's bullet

        if (other.gameObject.CompareTag("Bullet")){
            if (other.gameObject.GetComponent<BulletController>().currentColor != currentColor) {

                if (maxHealth != 1) {
                maxHealth--;

                }//if
                else {
                    Destroy(gameObject);

                }//else

            }//if
            
        }//if

    }

    private void HandleRotation() {
        if (target != null) {
            transform.LookAt(target);

        }
    }

    private void HandleChase() {    //Lets the enemy chase the player
        if (ChaseCheck == true){
            //transform.Translate(transform.forward * enemySpeed * Time.deltaTime, Space.World); 
            //Vector3 move = new Vector3(transform.forward.x, 0, transform.forward.y);
            controller.Move(transform.forward * Time.deltaTime * enemySpeed);

            enemyVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(enemyVelocity * Time.deltaTime);

        }

    }
    public void isChase() { //Changes ChaseCheck to determine if enemy can chase player
        ChaseCheck = !ChaseCheck;

    }

}
