using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Bullet")){
            Destroy(gameObject);
            
        }//if

    }

    private void HandleRotation() {
        if (target != null) {
            transform.LookAt(target);

        }
    }
}
