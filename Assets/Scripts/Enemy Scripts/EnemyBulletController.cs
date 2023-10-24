using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject bulletPrefab;
    public Renderer colorRender;
    public string currentColor;

    IEnumerator DestroyBulletAfterTime() {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }

    void Start()
    {
        StartCoroutine(DestroyBulletAfterTime());
        colorRender = bulletPrefab.GetComponent<Renderer>();

         if (currentColor == "Red") {
            colorRender.material.color = Color.red;

        }//if
        else if (currentColor == "Yellow") {
            colorRender.material.color = Color.yellow;

        }//else-if
        else if (currentColor == "Blue") {
            colorRender.material.color = Color.blue;

        }//else-if
        else if (currentColor == "Green") {
            colorRender.material.color = Color.green;

        }//else-if

        gameObject.tag = "EnemyBullet";
        
    }

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);   //Moves bullet along it's z axis
        

    }

    private void OnTriggerEnter(Collider other) {
        if ((!other.gameObject.CompareTag("Enemy")) && (!other.gameObject.CompareTag("Bullet")) && (!other.gameObject.CompareTag("EnemyBullet")) && (!other.gameObject.CompareTag("DetectionRadius"))){ //Doesn't destroy itself if it collides with player or another bullet
            Destroy(gameObject);

        }//if
        //Destroy(gameObject);

    }

}
