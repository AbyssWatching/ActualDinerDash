using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    [SerializeField]private float _speed = 8.0f;
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
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput,0,verticalInput);

        transform.Translate(direction * _speed * Time.deltaTime, Space.World);


        Quaternion rotation = Quaternion.LookRotation( direction, Vector3.up);
    }
}
