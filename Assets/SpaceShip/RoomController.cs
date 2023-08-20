using FishNet.Connection;
using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class RoomController : NetworkBehaviour
{
    [SerializeField]
    public int Cost = 1;

    //one for each side of the room
    public GameObject[] windows = new GameObject[4];
    public Vector2Int gridPosition;
    
    public Grid grid;


    private void Start()
    {
        int x = gridPosition.x;
        int y = gridPosition.y;

        if(grid.IsOutOfRange(x - 1, y))
        {
            windows[0].transform.GetChild(0).gameObject.SetActive(false);
        }

        if (grid.IsOutOfRange(x, y + 1))
        {
            windows[1].transform.GetChild(0).gameObject.SetActive(false);
        }

        if (grid.IsOutOfRange(x + 1, y))
        {
            windows[2].transform.GetChild(0).gameObject.SetActive(false);
        }

        if (grid.IsOutOfRange(x, y - 1))
        {
            windows[3].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    //0 = left, 1 = top, 2 = right, 3 = bottom
    public void CreateNeighbor(int offset, NetworkConnection client = null)
    {
        int offsetX, offsetY;
        switch (offset)
        {
            case 0:
                offsetX = -1;
                offsetY = 0;
                break;

            case 1:
                offsetX = 0;
                offsetY = 1;
                break;

            case 2:
                offsetX = 1;
                offsetY = 0;
                break;

            case 3:
                offsetX = 0;
                offsetY = -1;
                break;

            default:
                return;
        }

        grid.CreateRoom(gridPosition.x + offsetX, gridPosition.y + offsetY, client);
    }
}
