using FishNet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientServerManager : MonoBehaviour
{
    [SerializeField]
    private bool isServer = false;

    private void Awake()
    {
        if (isServer)
        {
            InstanceFinder.ServerManager.StartConnection();
        }
        else
        {
            Debug.Log("Starting Connection");
            InstanceFinder.ClientManager.StartConnection();
        }
    }
}
