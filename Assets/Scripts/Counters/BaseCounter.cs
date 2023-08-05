using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectInterface
{
    
    private KitchenObject kitchenObject;
    [SerializeField] private GameObject counterTopSpawnPoint;

    public virtual void Interact(PlayerMovementScript player)
    {
        Debug.Log("interact");
    } 

        public virtual void InteractAlt(PlayerMovementScript player)
    {
        Debug.Log("interact Alt");
    } 

    public Transform GetKitchenObjectFollowtransform()
    {
        return counterTopSpawnPoint.transform;
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
        return (kitchenObject != null);
   
    }
}
