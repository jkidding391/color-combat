using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // Reference to the sphere prefab you want to spawn.
    public int numberOfSpheres = 20; // Number of spheres to spawn.
    public float spawnRadius = 10f; // Maximum distance from the spawn point.

    void Start()
    {
        // Ensure that you have assigned a prefab to the spherePrefab variable in the Unity editor.
        if (spherePrefab == null)
        {
            Debug.LogError("Sphere prefab is not assigned!");
            return;
        }

        // Spawn the spheres.
        for (int i = 0; i < numberOfSpheres; i++)
        {
            // Generate a random position within the spawn radius.
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;

            // Instantiate a new sphere at the random position.
            GameObject newSphere = Instantiate(spherePrefab, randomPosition, Quaternion.identity);
            Rigidbody rb = newSphere.AddComponent<Rigidbody>();
            newSphere.transform.localScale += new Vector3(i, i, i);

            // Optionally, you can modify other properties of the spawned sphere here.
            // For example, you can change the scale or material.

            // Make sure the spawned sphere is a child of the spawner for organization.
            newSphere.transform.parent = transform;
        }
    }
}
