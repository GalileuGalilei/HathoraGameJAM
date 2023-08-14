using UnityEngine;
using FishNet.Object;
using FishNet.Component.Animating;

namespace Platformer.Mechanics
{
    public class PlayerNetwork : NetworkBehaviour
    {
        private Camera playerCamera;
        private NetworkAnimator networkAnimator;
        private Animator animator;
        private PlayerController playerController;

        public override void OnStartClient()
        {
            base.OnStartClient();

            if(!base.IsOwner)
            {
                GetComponent<PlayerController>().enabled = false;
                GetComponent<PlayerNetwork>().enabled = false;
                return;
            }

            playerController = GetComponent<PlayerController>();
            animator = GetComponent<Animator>();
            playerCamera = Camera.main;

            if(playerController == null || playerCamera == null)
            {
                Debug.LogError("Something got wrong with player network");
            }
        }

    }
}