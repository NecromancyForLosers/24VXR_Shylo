using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject Button;
    public UnityEvent onpress;
    public UnityEvent onrelease;
    GameObject presser;
    bool isPressed;

    private void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            Button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onpress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            Button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onrelease.Invoke();
            isPressed = false;
        }
    }

    public void SpawnCoffee()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(12, 2, -14);
        sphere.AddComponent<Rigidbody>();
    }
}
