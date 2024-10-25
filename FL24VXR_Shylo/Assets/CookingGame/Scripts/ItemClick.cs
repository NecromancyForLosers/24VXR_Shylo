using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    public GameObject Prefab; // Assign your prefab in the inspector

    public Transform spawnLocation; // Optional: set where to spawn the object

    void OnMouseDown()
    {
        if (Prefab != null)
        {
            // Use the spawnLocation transform or the position of the object
            Vector3 positionToSpawn = spawnLocation ? spawnLocation.position : transform.position;
            Instantiate(Prefab, positionToSpawn, Quaternion.identity);
        }
    }
}
