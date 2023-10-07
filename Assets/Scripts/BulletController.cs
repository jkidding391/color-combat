using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    IEnumerator DestroyBulletAfterTime() {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }

    void Start()
    {
        StartCoroutine(DestroyBulletAfterTime());
        
    }

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World); //Won't work because it relies on the Vector3's forward, not the Transform's forward

    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);

    }
}
