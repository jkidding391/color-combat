using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
   public Vector3 RotateAmount;  // degrees per second to rotate in each axis. Set in inspector.

   public Vector3 posOffset = new Vector3();
   public Vector3 tempPos = new Vector3();
   
    // Update is called once per frame
    void Start() {
        posOffset = transform.position;

    }

    void Update () {
        transform.Rotate(RotateAmount * Time.deltaTime);
        
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * 1f) * 0.5f;
        transform.position = tempPos;

    }

}
