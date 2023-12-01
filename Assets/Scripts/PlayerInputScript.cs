using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInputScript : MonoBehaviour
{

    
    // Start is called before the first frame update
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlt;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;

        playerInputActions.Player.InteractAlt.performed += InteractAlt_performed;
    }


    private void InteractAlt_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        OnInteractAction?.Invoke(this, EventArgs.Empty);
       // Debug.Log(obj);
    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        OnInteractAlt?.Invoke(this, EventArgs.Empty);
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
