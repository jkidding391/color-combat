using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletDirection;
    private PlayerControls controls;

    private bool canShoot = true;

    private void Awake() {
        controls = new PlayerControls();

    }

    private void OnEnable() {
        controls.Enable();

    }

    private void OnDisable() {
        controls.Disable();

    }
    void Start()
    {
        //controls.Controls.Shoot.performed += _ => playerShoot();
        
    }

    private void playerShoot() {
        if (!canShoot) return;

        //Vector2 mousePosition = 
        GameObject g = Instantiate(bullet, bulletDirection.position, bulletDirection.rotation);
        g.SetActive(true);
        StartCoroutine(CanShoot());
        
    }

    IEnumerator CanShoot() {
        canShoot = false;
        yield return new WaitForSeconds(.15f);
        canShoot = true;
    }

    void Update()
    {
        if (controls.Controls.Shoot.IsPressed() == true) {
            playerShoot();
        }
        
    }
}
