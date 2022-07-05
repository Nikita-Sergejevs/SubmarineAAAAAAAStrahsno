using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [Header("Raycast settings")]
        [SerializeField] private int rayLenghy = 1;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerMask = null;

        private KeyItemController raycastObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

        private string interactableTag = "InteractiveObject";
        private bool isCrosshairActive;
        private bool doOnce;

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerMask) | layerMaskInteract.value;

            if(Physics.Raycast(transform.position, fwd, out hit, rayLenghy, mask))
            {
                if(hit.collider.CompareTag(interactableTag))
                { 
                    if(!doOnce)
                    {
                        raycastObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if(Input.GetKeyDown(openDoorKey))
                        raycastObject.ObjectInteraction();
                }
            }
            else
            {
                if(isCrosshairActive)
                    doOnce = false;
            }
        }
    }
}