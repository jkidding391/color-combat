using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] int spawnNum;
    [SerializeField] bool onlyOneColor; //If selected, spawner will only spawn one colored type of enemy
    [SerializeField] string colorPreference;    //Color that the enemies spawned will be if above is checked

    private bool CanSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnEnemy();
        if (spawnNum == 0) {
            Destroy(gameObject);

        }
    }

    IEnumerator canSpawn(){
        CanSpawn = false;
        yield return new WaitForSeconds(1.5f);
        CanSpawn = true;

    }

    private void spawnEnemy() {
        if (!CanSpawn) return;

        GameObject enemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);
        enemy.SetActive(true);

        if (onlyOneColor == true) { //If onlyOneColor is checked, enemy will spawn as listed color
            enemy.GetComponent<EnemyColorController>().randomizeColor = false;
            enemy.GetComponent<EnemyColorController>().ChangeColor(colorPreference);

            //Debug.Log(colorPreference);
            
        }
        else {  //Otherwise the color will be random
            enemy.GetComponent<EnemyColorController>().randomizeColor = true;

        }

        //Debug.Log("After Change");

        StartCoroutine(canSpawn());
        spawnNum--;

    }

}
