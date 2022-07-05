using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [Header("Key Syste")]
        [SerializeField] private bool key = false;
        [SerializeField] private bool door = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            _keyInventory.hasKey = false;
            if(door)
                doorObject = GetComponent<KeyDoorController>();
        }

        public void ObjectInteraction()
        {

            if(door)
                doorObject.PlayAnimation();
            else if (key)
            {
                _keyInventory.hasKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
