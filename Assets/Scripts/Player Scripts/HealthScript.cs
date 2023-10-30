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

            if (other.gameObject.GetComponent<EnemyBulletController>().currentColor != GetComponentInParent<ColorController>().getColor()) {

                if (currentHealth != 1) {
                    currentHealth--;

                }//if
                else {
                    Destroy(gameObject);

                }//else

            }//if

        }//if

        //Not working for some reason?
        else if (other.gameObject.CompareTag("Wall") && (other.gameObject.GetComponentInParent<WallColorController>().getColor() == GetComponentInParent<ColorController>().getColor())) {

                Debug.Log("Touch");

                Physics.IgnoreCollision(transform.GetComponent<Collider>(), other.GetComponent<Collider>());

        }

    }
    public void IncreaseHealth() {  //To be used when player picks up a health item
        if (currentHealth != maxHealth) {
            currentHealth++;

        }//if

    }

}
