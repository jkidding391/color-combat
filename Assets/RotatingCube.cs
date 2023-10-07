using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    public float rotationSpeed = 30.0f;
    public float colorChangeSpeed = 0.5f;

    public Color startColor = Color.red;
    public Color endColor = Color.blue;

    private float t = 0.0f;

    private Renderer cubeRenderer;
    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = startColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        t += colorChangeSpeed * Time.deltaTime;
        cubeRenderer.material.color = Color.Lerp(startColor, endColor, t);

        if (t >= 1.0f) {
            t = 0.0f;
            var tempColor = startColor;
            startColor = endColor;
            endColor = tempColor;

        }//if
        
    }
}
