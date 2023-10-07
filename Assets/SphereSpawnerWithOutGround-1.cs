using UnityEngine;
using System.Collections;

public class SphereSpawnerWithGround : MonoBehaviour
{
    public Vector3 startSpawnPosition = new Vector3(0, 1, 0); // Starting position for the first sphere.
    public float spacing = 2f; // Space between the spheres.
    public float spawnDelay = 1.5f; // Delay in seconds between spawns.

    void Start()
    {
        //AddPlane(); // Add the ground plane
        SpawnSpheres();
    }

    // This function can be manually triggered in the Unity Editor.
    public void SpawnSpheres()
    {
        StartCoroutine(SpawnSpheresCoroutine());
    }

    private IEnumerator SpawnSpheresCoroutine()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Rigidbody rb = sphere.AddComponent<Rigidbody>(); // Adding a rigidbody to the sphere
            sphere.transform.position = startSpawnPosition + new Vector3(0, i * spacing, 0);
            
            yield return new WaitForSeconds(spawnDelay); // Wait for the specified delay.
        }
    }

    //void AddPlane()
    //{
     //   GameObject groundPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
      //  groundPlane.transform.position = new Vector3(0, -10, 0); // Moves the plane 10 units down from the origin.
    //}
}
