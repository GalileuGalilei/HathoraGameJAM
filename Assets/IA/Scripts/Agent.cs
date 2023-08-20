using Platformer.Mechanics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Agent : MonoBehaviour
{
    private AgentAnimations agentAnimations;
    private AgentMover agentMover;

    [SerializeField] private AIData data;

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;

    private Vector2 pointerInput, movementInput;

    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    private void Update()
    {
        pointerInput = GetPointerInput();
        movementInput = movement.action.ReadValue<Vector2>().normalized;

        //agentMover.MovementInput = movementInput;

        AnimateCharacter();
    }

   

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void PerformAttack()
    {
        if(GetComponent<Collider2D>().Distance(data.currentTarget.GetComponent<Collider2D>()).distance < .1f)
        {
            Health targetHealth = data.currentTarget.GetComponent<Health>();
            if (targetHealth == null)
            {
                Debug.Log("Objeto target sem script necessário: Health.cs");
            }

            if (targetHealth.IsAlive)
            {
                targetHealth.Decrement();
                if (!targetHealth.IsAlive)
                    data.currentTarget.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Erro, o objeto ja devia estar morto");
            }
        }
            

    }

    private void Awake()
    {
        agentAnimations = GetComponentInChildren<AgentAnimations>();

        agentMover = GetComponent<AgentMover>();
    }

    private void AnimateCharacter()
    {

    }

    

}
