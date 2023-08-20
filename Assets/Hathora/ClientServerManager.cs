using FishNet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientServerManager : MonoBehaviour
{
    [SerializeField] public bool isServer;
    [SerializeField] public GameObject menu;

    private void Awake()
    {
        if (!InstanceFinder.ServerManager.AnyServerStarted())
        {
            InstanceFinder.ServerManager.StartConnection();
            isServer = true;
        }
        else
        {
            InstanceFinder.ClientManager.StartConnection();
        }
       

    }
    

}