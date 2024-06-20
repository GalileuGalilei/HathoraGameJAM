using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;

    [SerializeField] private SpriteRenderer renderer;

    [SerializeField] private GameObject bulletModel;

    private void awake ( ) 
    {
    }

    void Start()
    {
         
    }

    void Update()
    {
        aim();
    }

    private void shoot(float angle)
    {
        if(Input.GetMouseButtonDown(0)) 
        { 
            Instantiate(bulletModel, GetComponentInChildren<Transform>().position, Quaternion.Euler(new Vector3(0, 0, angle + 90)));
        }
    }

    private void aim()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 object_pos = Camera.main.WorldToScreenPoint(aimTransform.position);
        Vector3 aimDirection = (mousePosition - object_pos).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (Math.Abs(angle) >= 90)
        {
            renderer.flipY = true;
        }
        else
        {
            renderer.flipY = false;
        }
        shoot(angle);
    }
}
