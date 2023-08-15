using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Agent : MonoBehaviour
{
    private AgentAnimations agentAnimations;
    private AgentMover agentMover;


    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;

    private Vector2 pointerInput, movementInput;

    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    private void Update()
    {
        pointerInput = GetPointerInput();
        movementInput = movement.action.ReadValue<Vector2>().normalized;

        agentMover.MovementInput = movementInput;

        AnimateCharacter();
    }

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void PerformAttack(InputAction.CallbackContext obj)
    {
        Debug.Log("Attack");
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
