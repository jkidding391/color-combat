using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    }
    public void IncreaseHealth() {  //To be used when player picks up a health item
        if (currentHealth != maxHealth) {
            currentHealth++;

        }//if

    }

    /*IEnumerator LoseLevel() {
        Debug.Log("You Died! Restarting level...");
        yield return new WaitForSeconds(5f);
        RestartLevel();

    }*/

}
