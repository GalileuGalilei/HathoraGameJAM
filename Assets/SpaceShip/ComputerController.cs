using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public GameObject player;
    public Grid grid;

    [SerializeField]
    List<GameObject> roomsPrefabs = new List<GameObject>();
    [SerializeField]
    GameObject smallHUD;
    [SerializeField]
    GameObject largeHUD;

    [SerializeField]
    private float range = 5.0f;
    private bool smallHUDState = false;

    public void Start()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        player = GameObject.Find("Player");
        if(grid == null && player == null)
        {
            Debug.LogError("Grid or player not found");
            return;
        }

        grid.SetCanvas(false);
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

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
        grid.SetCanvas(false);
    }

    public void SetSmallHud(bool state)
    {
        smallHUD.SetActive(state);
        smallHUDState = state;
    }

    public void OnSelectRoom(int roomIndex)
    {
        grid.RoomPrefab = roomsPrefabs[roomIndex];
        grid.SetCanvas(true);
        //if(players.money < grid.RoomPrefab)
        //grid.SetCanvas(false);
    }

}
