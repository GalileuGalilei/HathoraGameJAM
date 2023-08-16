using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField]
    private SpaceShipController[,] grid = new SpaceShipController[3,6];
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
