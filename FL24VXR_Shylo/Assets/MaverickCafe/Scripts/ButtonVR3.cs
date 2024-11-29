using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR3 : MonoBehaviour
{
    public GameObject Button;
    public UnityEvent onpress;
    public UnityEvent onrelease;
    GameObject presser;
    bool isPressed;
    public GameObject IcedCoffee;

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

    public void SpawnIcedCoffee()
    {

        Vector3 spawnPosition = new Vector3(0f, 0.9f, -10.32f);
        GameObject instance = Instantiate(IcedCoffee, spawnPosition, Quaternion.identity);
        instance.name = "TempIced";
       
    }
}
