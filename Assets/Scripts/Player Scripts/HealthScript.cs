using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour

{
    [SerializeField] public int maxHealth = 3;
    public int currentHealth;

    [SerializeField] GameObject health1;
    [SerializeField] GameObject health2;
    [SerializeField] GameObject health3;
    //[SerializeField] GameObject healthNone;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        health3.SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    {
        //HealthUIController();

    }
    void OnTriggerEnter(Collider other) {   //Player takes damage if hit by an enemy bullet
        if (other.gameObject.CompareTag("EnemyBullet")){

            if (other.gameObject.GetComponent<EnemyBulletController>().currentColor != GetComponentInParent<ColorController>().getColor()) {

                if (currentHealth != 1) {
                    currentHealth--;
                    HealthUIController();

                }//if
                else {
                    currentHealth--;
                    HealthUIController();
                    Destroy(gameObject);

                }//else

            }//if

        }//if

    }
    public void IncreaseHealth() {  //To be used when player picks up a health item
        if (currentHealth != maxHealth) {
            currentHealth++;
            Debug.Log(currentHealth);

        }//if

    }

    /*IEnumerator LoseLevel() {
        Debug.Log("You Died! Restarting level...");
        yield return new WaitForSeconds(5f);
        RestartLevel();

    }*/

    public void HealthUIController(){
        if (currentHealth < maxHealth) {
            health3.SetActive(false);
        }
        else {
            health3.SetActive(true);

        }
        
        if (currentHealth < maxHealth-1) {
            health2.SetActive(false);
        }
        else {
            health2.SetActive(true);

        }

        if (currentHealth < maxHealth-2) {
            health1.SetActive(false);
        }
        else {
            health1.SetActive(true);
        }

    }

}
