using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float enemySpeed = 5f;
    private bool ChaseCheck = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleChase();
        
    }
    void OnTriggerEnter(Collider other) {   //Gets destroyed if it gets hit by the player's bullet

        if (other.gameObject.tag.Equals("Bullet")){
            if (maxHealth != 1) {
            maxHealth--;

            }//if
            else {
                Destroy(gameObject);

            }//else
            
        }//if

    }

    private void HandleRotation() {
        if (target != null) {
            transform.LookAt(target);

        }
    }

    private void HandleChase() {    //Lets the enemy chase the player
        if (ChaseCheck == true){
            transform.Translate(transform.forward * enemySpeed * Time.deltaTime, Space.World); 

        }

    }
    public void isChase() { //Changes ChaseCheck to determine if enemy can chase player
        ChaseCheck = !ChaseCheck;

    }

}
