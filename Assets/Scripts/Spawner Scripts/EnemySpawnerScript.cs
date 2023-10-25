using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] int spawnNum;
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
        StartCoroutine(canSpawn());
        spawnNum--;

    }

}
