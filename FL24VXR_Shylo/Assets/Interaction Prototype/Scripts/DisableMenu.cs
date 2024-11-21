using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMenu : MonoBehaviour
{

    public void disableMenu()
    { 
        Canvas Menu = GetComponent<Canvas>();
        
        Menu.enabled = false;

    }
}
