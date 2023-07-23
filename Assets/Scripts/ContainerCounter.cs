
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

        //if (!player.HasKitchenObject())
        // {
        //     //play
        //     Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopSpawnPoint.transform);
        //     kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        //}
        if(!player.HasKitchenObject()){

            //Debug.Log("We interacting with the clear counter!");

            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
        
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }

 
}
