using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject bulletPrefab;

    IEnumerator DestroyBulletAfterTime() {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }

    void Start()
    {
        StartCoroutine(DestroyBulletAfterTime());
        gameObject.tag = "EnemyBullet";
        
    }

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);   //Moves bullet along it's z axis
        

    }

    private void OnTriggerEnter(Collider other) {
        if ((!other.gameObject.CompareTag("Enemy")) && (!other.gameObject.CompareTag("Bullet")) && (!other.gameObject.CompareTag("DetectionRadius"))){ //Doesn't destroy itself if it collides with player or another bullet
            Destroy(gameObject);

        }//if
        //Destroy(gameObject);

    }

}
