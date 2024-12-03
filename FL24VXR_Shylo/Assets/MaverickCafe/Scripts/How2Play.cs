using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime = 10f; // Time in seconds before the object is destroyed

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
