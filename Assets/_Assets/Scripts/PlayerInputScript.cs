using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
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
