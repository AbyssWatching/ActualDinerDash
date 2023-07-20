
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ContainerCounter : BaseCounter, IKitchenObjectInterface
{
    // serriallized fields
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    
    //regular fields
    public event EventHandler OnPlayerGrabbedObject;
    
    
    //methods
    public override void Interact(PlayerMovementScript player)
    {

        if (!player.HasKitchenObject())
        // {
        //     //play
        //     Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopSpawnPoint.transform);
        //     kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        //}
        if(!HasKitchenObject()){

            Debug.Log("We interacting with the clear counter!");
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }

 
}
