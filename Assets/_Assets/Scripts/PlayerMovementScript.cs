using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float _rotationSpeed = 700.0f;
    [SerializeField]private float _speed = 8.0f;
    [SerializeField] private PlayerInputScript PlayerInputScript;
    private bool isWalking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        // verticalInput = Input.GetAxis("Vertical");

        Vector2 playerInput = PlayerInputScript.GetMovement();

        Vector3 direction = new Vector3(playerInput.x,0,playerInput.y);
        float playerRadius = .7f;
        float playerhieght = 2.2f;
        float moveDistance = Time.deltaTime  * _speed ;
        bool canMmove = !Physics.CapsuleCast(transform.position ,transform.position + Vector3.up * playerhieght, playerRadius, direction, moveDistance);
        
       
        if(!canMmove)
        {   
            Vector3 directionX = new Vector3(direction.x,0,0);

            canMmove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerhieght, playerRadius, directionX, moveDistance);

            if(canMmove)
            {
                direction = directionX;
                Debug.Log("direction.x is working");
            }

            else
            {
                
                Vector3 directionZ = new Vector3(0,0,direction.z);

                canMmove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerhieght, playerRadius, directionZ, moveDistance);

                if (canMmove)
                {
                    direction = directionZ;
                    Debug.Log("having trouble with the y directional");
                }
            }
        }

        if(canMmove)
        {
            transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        }

        isWalking = direction != Vector3.zero;

        if(isWalking){

            Quaternion rotation = Quaternion.LookRotation( direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
