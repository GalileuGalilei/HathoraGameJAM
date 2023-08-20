using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStation : MonoBehaviour
{
    [SerializeField]
    private float RegenRate = 0.1f;
    [SerializeField]
    private float RegenRange = 6.0f;
    private GameObject player = null;

    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogError("Player not found");
            return;
        }

        StartCoroutine(RegenPlayer());
    }

    private IEnumerator RegenPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < RegenRange)
        {
            player.GetComponent<Health>().Increment();
        }

        yield return new WaitForSeconds(RegenRate);
    }
}
