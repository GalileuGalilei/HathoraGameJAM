using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Vector2 PointerPosition { get; set;}

    [SerializeField] private Transform aimTransform;

    [SerializeField] private SpriteRenderer renderer;

    private void awake ( ) 
    {
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 object_pos = Camera.main.WorldToScreenPoint(aimTransform.position);
        Vector3 aimDirection = (mousePosition - object_pos).normalized;

        float angle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if(Math.Abs(angle) >= 90)
        {
            renderer.flipY = true;
        }
        else
        {
            renderer.flipY = false;
        }
    }
}
