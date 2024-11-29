using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrinkPlace2 : MonoBehaviour
{
    public Transform collectPoint; // The point where the item will be placed
    public float pullSpeed = 5f; // Speed at which the object moves to the collection point

    private GameObject ItemGrabbed; // Tracks the object currently held by this collector
    public Animator Animator;
    public GameObject TextBoxCanvas;
    public GameObject DuckyTalkBox;
    public GameObject DuckyModel;
    public Vector3 throwDirection = new Vector3(0, 1, 1); // Direction to throw the object
    public float throwForce = 10f;
    public AudioSource Correct;
    public AudioSource Wrong;
    public bool wrong = false;


    //public MonoBehaviour Grabbable;


    private void OnTriggerEnter(Collider other)
    {


        // Check if the collector already holds an object
        if (ItemGrabbed != null)
            return;

        //Check if the object is being held by the player
        XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null && grabInteractable.isSelected && other.gameObject.name.Contains("TempIced"))
        {
            // Stop the player from holding the object
            grabInteractable.interactionManager.CancelInteractableSelection(grabInteractable);

            // Start sucking the object in
            StartCoroutine(SuckInObject(other.gameObject));
            Correct.Play();
            Debug.Log($"Collided with IcedCoffee: {other.gameObject.name}");
            wrong = false;
        }
        else
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null && !other.gameObject.name.Contains("TempIced"))
            {
                // Apply force to the object
                rb.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
                Wrong.Play();
                wrong = true;

            }
        }

    }

    private System.Collections.IEnumerator SuckInObject(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();

        // Disable physics for smoother movement
        if (rb != null)
        {
            rb.isKinematic = true;
        }


        XRGrabInteractable Grabbable = obj.GetComponent<XRGrabInteractable>();

        if (Grabbable != null)
        {
            Grabbable.enabled = false;
            Debug.Log($"{Grabbable.name} has been disabled.");
        }

        // Gradually move the object to the collection point
        while (Vector3.Distance(obj.transform.position, collectPoint.position) > 0.01f)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, collectPoint.position, pullSpeed * Time.deltaTime);
            yield return null;
        }
        // Snap the object to the collection point
        obj.transform.position = collectPoint.position;

        // Re-parent the object to the collector and mark it as collected
        obj.transform.SetParent(collectPoint);
        ItemGrabbed = obj; // Store the collected object


        Destroy(obj);
        Animator.Play("DuckyWalkOut", -1, 0f);

        TextBoxCanvas.SetActive(false);
        DuckyTalkBox.SetActive(false);

    }







    //public void ReleaseObject()
    //{
    //    // If there is a collected object, release it
    //    if (CoffeeCup != null)
    //    {
    //        // Re-enable physics on the object
    //        Rigidbody rb = CoffeeCup.GetComponent<Rigidbody>();
    //        if (rb != null)
    //        {
    //            rb.isKinematic = false;
    //        }

    //        // Unparent the object
    //        CoffeeCup.transform.SetParent(null);
    //        CoffeeCup = null; // Clear the reference
    //    }
    //}
}

