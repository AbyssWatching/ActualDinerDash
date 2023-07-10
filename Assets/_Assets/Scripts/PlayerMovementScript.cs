using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovementScript : MonoBehaviour, IKitchenObjectInterface
{

    public static PlayerMovementScript Instance { get;private set;}

    public event EventHandler <OnSelectedCounterChangedEventArgs>OnSelectedCounterChanged;

    public class OnSelectedCounterChangedEventArgs : EventArgs {
        public ClearCounter selectedCounter;
    }

    private float horizontalInput;
    private float verticalInput;
    private bool isWalking;
   
    [SerializeField] private float _rotationSpeed = 700.0f;
    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private PlayerInputScript PlayerInputScript;
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private GameObject KitchenObjectHoldPoint;
    
    private Vector3 lastInteractLocation;
   
    private ClearCounter selectedCounter;

    private KitchenObject kitchenObject;
    // Start is called before the first frame update


    void Start()
    {
        PlayerInputScript.OnInteractAction += PlayerInputActions_OnInteractAction;
    }

    private void Awake(){
        if (Instance != null){
            Debug.Log("Shit HIT THE FAN More than one player instance!");
        }
        Instance = this;
    }
    private void PlayerInputActions_OnInteractAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }

        //HandleInteractions();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        HandleInteractions();
        
    }

    public void PlayerMovement()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        // verticalInput = Input.GetAxis("Vertical");

        Vector2 playerInput = PlayerInputScript.GetMovement();

        Vector3 direction = new Vector3(playerInput.x, 0, playerInput.y);
        float playerRadius = .7f;
        float playerhieght = 2.2f;
        float moveDistance = Time.deltaTime * _speed;
        bool canMmove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerhieght, playerRadius, direction, moveDistance);


        if (!canMmove)
        {
            Vector3 directionX = new Vector3(direction.x, 0, 0).normalized;

            canMmove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerhieght, playerRadius, directionX, moveDistance);

            if (canMmove)
            {
                direction = directionX;
                //Debug.Log("direction.x is working");
            }

            else
            {

                Vector3 directionZ = new Vector3(0, 0, direction.z).normalized;

                canMmove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerhieght, playerRadius, directionZ, moveDistance);

                if (canMmove)
                {
                    direction = directionZ;
                   // Debug.Log("having trouble with the y directional");
                }
            }
        }

        if (canMmove)
        {
            transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        }

        isWalking = direction != Vector3.zero;

        if (isWalking)
        {

            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }


    private void HandleInteractions()
    {
        float interactDistance = 2.0f;

        Vector2 playerInput = PlayerInputScript.GetMovement();

        Vector3 direction = new Vector3(playerInput.x, 0, playerInput.y);

        if (direction != Vector3.zero)
        {
            lastInteractLocation = direction;
        }

       if (Physics.Raycast(transform.position, lastInteractLocation, out RaycastHit raycastHit, interactDistance, countersLayerMask)){
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)){
                //Has clearCounter
                if (clearCounter != selectedCounter){
                    selectedCounter = clearCounter;

                    SetSelectedCounter(clearCounter);
                }
            } else {
                SetSelectedCounter(null);;
                }
       } else {
        SetSelectedCounter(null);
        }
    //Debug.Log(selectedCounter);

    }

    private void SetSelectedCounter(ClearCounter selectedCounter){

        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs{
            selectedCounter = selectedCounter
        });

    }

    public Transform GetKitchenObjectFollowtransform()
    {
        return KitchenObjectHoldPoint.transform;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void VoidKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}

