using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour

{
    [SerializeField] private int maxHealth = 3;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {   //Player takes damage if hit by an enemy bullet
        if (other.gameObject.CompareTag("EnemyBullet")){
            
            if (currentHealth != 1) {
                currentHealth--;

            }//if
            else {
                Destroy(gameObject);

            }//else

        }//if

    }
    public void IncreaseHealth() {  //To be used when player picks up a health item
        if (currentHealth != maxHealth) {
            currentHealth++;

        }//if

    }

}
