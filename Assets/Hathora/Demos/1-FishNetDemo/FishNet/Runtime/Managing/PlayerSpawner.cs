using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using FishNet.Connection;
using UnityEngine;

public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField]
    private GameObject playerPrefab = null;

    public override void OnStartClient()
    {
        base.OnStartClient();
        SpawnPlayer();
    }

    [ServerRpc(RequireOwnership = false)]
    private void SpawnPlayer(NetworkConnection client = null)
    {
        Debug.Log("player connected");
        GameObject go = Instantiate(playerPrefab);
        Spawn(go, client);
    }
}
