using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{

    [SerializeField] private FryingRecipeSO[] fryingRecipeSOs;


public override void Interact(PlayerMovementScript player)
    {

        if(!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
             //do something   
            
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    // cuttingProgress = 0;

                    // FryingRecipeSO outputCuttingObjectSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                    // OnProgressChanged?.Invoke(this, new OnProgrossChangedEventArgs{
                        
                       
                    //     progressNormalized = (float)cuttingProgress / outputCuttingObjectSO.cuttingProgressMax

                    //});
                    
                }
            }
            else{
                //player doesn't have the kitchenObject
            }
        } 
        else{
            //there is a kitchen object on the table
            if (player.HasKitchenObject())
            {
                //player is carrying obj
            }
            else
            {
                //player has nothing in hand
                GetKitchenObject().SetKitchenObjectParent(player);
            }

        }
    }

    //     public override void InteractAlt(PlayerMovementScript player)
    // {
    //     if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
    //     {

    //         cuttingProgress ++;

    //         OnCut?.Invoke(this, EventArgs.Empty);

    //         FryingRecipeSO outputCuttingObjectSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());


    //         OnProgressChanged?.Invoke(this, new OnProgrossChangedEventArgs{
                
                
    //             progressNormalized = (float)cuttingProgress / outputCuttingObjectSO.cuttingProgressMax

    //         });

    //         if (cuttingProgress >= outputCuttingObjectSO.cuttingProgressMax)
    //         {
    //         KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

    //         GetKitchenObject().SelfDestruct();

    //         KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
    //          }
    //     }
    // }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);

        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        return null;
    }

    private bool HasRecipeWithInput (KitchenObjectSO kitchenObject)
    {
      FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(kitchenObject);

      return (fryingRecipeSO != null);
      }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputkitchenObjectSO)
    {
        foreach (FryingRecipeSO test in fryingRecipeSOs)
        {
            if (test.input == inputkitchenObjectSO)
            {
                return test;
            }
            
        }
        return null;
    }

}
