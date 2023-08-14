using UnityEngine;
using FishNet.Object;


namespace Platformer.Mechanics
{
    public class PlayerNetwork : NetworkBehaviour
    {
        private Camera playerCamera;
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
            playerCamera = Camera.main;

            if(playerController == null || playerCamera == null)
            {
                Debug.LogError("Something got wrong with player network");
            }
        }


    }
}