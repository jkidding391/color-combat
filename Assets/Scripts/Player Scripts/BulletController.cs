using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject bulletPrefab;

    //Color
    public Renderer colorRender;
    public string currentColor;
    //[SerializeField] private GameObject player;

    IEnumerator DestroyBulletAfterTime() {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }

    void Start()
    {
        StartCoroutine(DestroyBulletAfterTime());

        //Color shenanigans
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


        gameObject.tag = "Bullet";
        
    }

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);   //Moves bullet along it's z axis
        

    }

    private void OnTriggerEnter(Collider other) {
        if ((!other.gameObject.CompareTag("Player")) && (!other.gameObject.CompareTag("Bullet")) && (!other.gameObject.CompareTag("DetectionRadius")) && (!other.gameObject.CompareTag("EnemyBullet"))){ //Doesn't destroy itself if it collides with player or another bullet

            if (other.gameObject.CompareTag("Wall") && (other.gameObject.GetComponentInParent<WallColorController>().getColor() == currentColor)) {

                Physics.IgnoreCollision(transform.GetComponent<Collider>(), other.GetComponent<Collider>());

            }
            else {
                Destroy(gameObject);

            }

        }//if
        //Destroy(gameObject);

    }

    public string GetColor(){
        return currentColor;

    }

}
