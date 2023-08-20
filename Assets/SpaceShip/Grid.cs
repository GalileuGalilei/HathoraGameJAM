using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Grid of rooms of the spaceShip. [0,0] is the bottom left room and also the Transform position of the grid.
/// </summary>
public class Grid : MonoBehaviour
{
    [SerializeField]
    private Vector2Int gridDim;
    [SerializeField]
    public GameObject RoomPrefab;

    [SerializeField]
    private RoomController[,] rooms;
    private Vector2 roomSize;

    void Start()
    {
        rooms = new RoomController[gridDim.x, gridDim.y];

        for(int i = 0; i < gridDim.x; i++)
        {
            for(int j = 0; j < gridDim.y; j++)
            {
                rooms[i, j] = null;
            }
        }

        Mesh mesh = RoomPrefab.GetComponent<MeshFilter>().sharedMesh;
        roomSize = mesh.bounds.size;
        Debug.Log($"carreado room com size {roomSize}");

        CreateRoom(3, 1);
    }

    public void CreateRoom(int x, int y)
    {
        Debug.Log($"x = {x}, y = {y}");
        if (IsOutOfRange(x, y) || rooms[x, y] != null) 
        {
            return;
        }

        RoomController room = Instantiate(RoomPrefab).GetComponent<RoomController>();
        Vector2 position = new Vector2(x * roomSize.x, y * roomSize.y);
        position.x += transform.position.x;
        position.y += transform.position.y;

        room.transform.position = new Vector3(position.x, position.y, 0);
        room.gridPosition = new Vector2Int(x, y);
        room.grid = this;
        rooms[x, y] = room;

        RemoveNeighborWindows();
    }

    public RoomController GetRoomAt(int x, int y)
    {
        if(IsOutOfRange(x,y))
        {
            return null;
        }

        return rooms[x, y];
    }

    public bool IsOutOfRange(int x, int y)
    {
        if (x < 0 || y < 0 || x >= gridDim.x || y >= gridDim.y)
        {
            return true;
        }

        return false;
    }

    public void SetCanvas(bool state)
    {
        foreach(RoomController room in rooms)
        {
            if(room != null)
            {
                GameObject[] windows = room.windows;

                foreach(GameObject window in  windows) 
                {
                    if(window != null) 
                    {
                        window.transform.GetChild(0).gameObject.SetActive(state);
                    }
                }
            }
        }
    }

    private void RemoveNeighborWindows()
    {
        for(int x = 0; x < gridDim.x; x++)
        {
            for(int y = 0;  y < gridDim.y; y++)
            {
                RoomController room = GetRoomAt(x, y);
                RoomController neigh;

                if (room == null)
                {
                    continue;
                }

                neigh = GetRoomAt(x - 1, y);
                if (neigh != null)
                {
                    Destroy(room.windows[0]);
                }

                neigh = GetRoomAt(x, y + 1);
                if (neigh != null)
                {
                    Destroy(room.windows[1]);
                }

                neigh = GetRoomAt(x + 1, y);
                if (neigh != null)
                {
                    Destroy(room.windows[2]);
                }

                neigh = GetRoomAt(x, y - 1);
                if (neigh != null)
                {
                    Destroy(room.windows[3]);
                }
            }
        }
    }
}
