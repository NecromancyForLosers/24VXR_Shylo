using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aceTowards : MonoBehaviour
{
    public Transform target; // The character or camera to face

    void Update()
    {
        if (target != null)
        {
            // Make the Canvas face the target
            transform.LookAt(target);

            // Optionally, flip the Canvas to face the correct direction
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);
        }
    }
}
