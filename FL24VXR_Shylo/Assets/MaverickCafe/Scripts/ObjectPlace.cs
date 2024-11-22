using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectPlace : MonoBehaviour
{
    public Transform collectPoint; // The point where the item will be placed
    public float pullSpeed = 5f; // Speed at which the object moves to the collection point

    private GameObject CoffeeCup; // Tracks the object currently held by this collector
    public GameObject DemoCat;
    public Animator Animator;

    //public MonoBehaviour Grabbable;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collector already holds an object
        if (CoffeeCup != null)
            return;

        // Check if the object is being held by the player
        XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null && grabInteractable.isSelected)
        {
            // Stop the player from holding the object
            grabInteractable.interactionManager.CancelInteractableSelection(grabInteractable);

            // Start sucking the object in
            StartCoroutine(SuckInObject(other.gameObject));
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
        CoffeeCup = obj; // Store the collected object

        Destroy(obj);
        Animator.Play("WalkOut", -1, 0f);
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
