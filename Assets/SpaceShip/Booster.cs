using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject bar = GameObject.Find("SpaceShipMin");
        bar.GetComponent<ProgressionBar>().SpeedUp(5f);
    }
}
