using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class NextLevelInteractive : MonoBehaviour, IInteractive
    {
        public string DisplayText => "Climb Ladder";

        [SerializeField]
        private GameObject player;

        [SerializeField]
        private GameObject nextRoomSpawnPoint;

        [Tooltip("Is the next zone in zero gravity?")]
        [SerializeField]
        private bool isInZeroG;

        private RigidbodyFirstPersonController controller;

        private void Awake()
        {
            controller = player.GetComponent<RigidbodyFirstPersonController>();
        }
        public void InteractWith()
        {
            player.transform.position = nextRoomSpawnPoint.transform.position;
            if (isInZeroG)
                controller.SwitchToZeroGravity();
            else
                controller.SwitchToNormalGravity();
        }
    }
}
