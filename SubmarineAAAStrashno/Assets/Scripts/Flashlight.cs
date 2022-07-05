using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Header("Flashlight Setting")]
    [SerializeField] GameObject flashlight;
    private bool flashlightActive = false;

    private void Start()
    {
        flashlight.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!flashlightActive)
            {
                flashlight.gameObject.SetActive(true);
                flashlightActive = true;
            }
            else
            {
                flashlight.gameObject.SetActive(false);
                flashlightActive = false; 
            }
        }
    }
}
