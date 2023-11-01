using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject target;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float enemySpeed = 5f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] public string currentColor;
    public GameObject tracker;

    private CharacterController controller;
    private Vector3 enemyVelocity;
    private bool ChaseCheck = true;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        
    }

    void Start()
    {
        //currentColor = gameObject.GetComponent<EnemyColorController>().GetColor(); //Doesn't work for some reason
        target = GameObject.FindGameObjectWithTag("Player");
        tracker = GameObject.FindGameObjectWithTag("WinLossTracker");
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleChase();
        
    }
    void OnTriggerEnter(Collider other) {   //Gets destroyed if it gets hit by the player's bullet

        if (other.gameObject.CompareTag("Bullet")){

            if (currentColor != other.gameObject.GetComponent<BulletController>().GetColor()) {
                //Debug.Log("Bullet color = " + other.gameObject.GetComponent<BulletController>().GetColor() + ", Enemy color = " + currentColor);

                if (maxHealth != 1) {
                maxHealth--;

                }//if
                else {
                    tracker.GetComponent<WinLossScript>().winNum--;
                    Destroy(gameObject);

                }//else

            }//if
            
        }//if

        //Also not working for some reason
        /*else if (other.gameObject.CompareTag("Wall") && (other.gameObject.GetComponentInParent<WallColorController>().getColor() == currentColor)) {

                //Debug.Log("Touch");

                Physics.IgnoreCollision(transform.GetComponent<Collider>(), other.GetComponent<Collider>());

        }*/

    }

    private void HandleRotation() {
        if (target != null) {
            transform.LookAt(target.transform);

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
    public void isChase(bool condition) { //Changes ChaseCheck to determine if enemy can chase player
        //ChaseCheck = !ChaseCheck;
        ChaseCheck = condition;
    }

}
