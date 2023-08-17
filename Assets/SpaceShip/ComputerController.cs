using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    List<GameObject> roomsPrefabs = new List<GameObject>();
    [SerializeField]
    GameObject smallHUD;
    [SerializeField]
    GameObject largeHUD;

    [SerializeField]
    private float range = 1.0f;
    private bool smallHUDState = false;
    private bool largeHUDState = false;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance < range)
        {
            if(!smallHUDState)
            {
                SetSmallHud(true);
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                SetLargeHud(true);
                SetSmallHud(false);
            }
        }
        else
        {
            SetSmallHud(false);
        }
    }

    public void SetLargeHud(bool state)
    { 
        largeHUD.SetActive(state);
    }

    public void SetSmallHud(bool state)
    {
        smallHUD.SetActive(state);
        smallHUDState = state;
    }
}
