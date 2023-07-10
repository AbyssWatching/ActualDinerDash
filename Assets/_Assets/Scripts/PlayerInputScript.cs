using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInputScript : MonoBehaviour
{
    // Start is called before the first frame update
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        OnInteractAction?.Invoke(this, EventArgs.Empty);
       // Debug.Log(obj);
    }

    public Vector2 GetMovement()
    {

        Vector2 playerInput = playerInputActions.Player.Move.ReadValue<Vector2>();

        // playerInput.x = Input.GetAxis("Horizontal");

        // playerInput.y = Input.GetAxis("Vertical");

        playerInput=playerInput.normalized;
    
        return playerInput;
    }


}
