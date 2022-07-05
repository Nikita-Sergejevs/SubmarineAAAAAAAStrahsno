using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private bool doorOpen = false;
        private bool otherDoor = false;

        [Header("Animation Name")]
        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;
        [SerializeField] private GameObject door;
        private void Awake()
        {
            doorOpen = false;
            if(door)
                otherDoor = true;
        }

        private void Update()
        {
            if(_keyInventory.hasKey)
                GetComponent<Outline>().enabled = true;
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if(_keyInventory.hasKey)
            {
                if (!doorOpen && !pauseInteraction)
                {
                    doorOpen = true;
                    StartCoroutine(PauseDoorInteraction());
                    gameObject.SetActive(false);
                }
                else if (doorOpen && !pauseInteraction)
                {
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());

                }
                if(otherDoor)
                {
                    door.SetActive(false);
                }
            }
        }
    }
}
