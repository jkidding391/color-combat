using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletDirection;

    private bool canShoot = true;
    void Start()
    {
        //controls.Controls.Shoot.performed += _ => playerShoot();
        
    }

    private void enemyShoot() {
        if (!canShoot) return;

        //Vector2 mousePosition = 
        GameObject g = Instantiate(bullet, bulletDirection.position, bulletDirection.rotation);
        g.SetActive(true);
        StartCoroutine(CanShoot());
        
    }

    IEnumerator CanShoot() {
        canShoot = false;
        yield return new WaitForSeconds(.30f);
        canShoot = true;
    }

    void Update()
    {   
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(ray, out hit, 25)) {
            if (hit.transform.CompareTag("Player")) {

            }
            enemyShoot();
        }

    }
}

