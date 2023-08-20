using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : Detector
{
    [SerializeField]
    private float targetDetectionRange = 5;

    [SerializeField]
    public LayerMask obstaclesLayerMask, playerLayerMask;

    [SerializeField]
    private bool showGizmos = false;

    //gizmo parameters
    private List<Transform> colliders;

    protected void Start()
    {
        colliders = new List<Transform>();
    }

    public override void Detect(AIData aiData)
    {

        //Find out if player is near
        Collider2D[] playersColliders = 
            Physics2D.OverlapCircleAll(transform.position, targetDetectionRange, playerLayerMask);

        if (playersColliders != null)
        {
            foreach (Collider2D pCollider in playersColliders)
            {
                //Check if you see the player
                Vector2 direction = (pCollider.transform.position - transform.position).normalized;
                RaycastHit2D hit =
                    Physics2D.Raycast(transform.position, direction, targetDetectionRange, obstaclesLayerMask);
                
                //Make sure that the collider we see is on the "Player" layer
                if (hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
                {
                    if (!colliders.Contains(pCollider.transform))
                        colliders.Add(pCollider.transform);
                }
            }
        }

        for (int i = colliders.Count - 1; i >= 0; i--)
        {
            Transform go = colliders[i];
            if(go == null)
            {
                colliders.RemoveAt(i);
                continue;
            }
            if (!go.gameObject.activeSelf)
            {
                colliders.RemoveAt(i);

                if (aiData.currentTarget == go)
                {
                    aiData.currentTarget = null;
                }
            }
        }

        

        aiData.targets = colliders;
    }

    private void OnDrawGizmosSelected()
    {
        if (showGizmos == false)
            return;

        Gizmos.DrawWireSphere(transform.position, targetDetectionRange);

        if (colliders == null)
            return;
        Gizmos.color = Color.magenta;
        foreach (var item in colliders)
        {
            Gizmos.DrawSphere(item.position, 0.3f);
        }
    }
}
