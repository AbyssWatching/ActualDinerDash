using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CuttingCOunter : BaseCounter
{

    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOsuttingRecipeSOs;

    public event EventHandler<OnProgrossChangedEventArgs> OnProgressChanged;

    public class OnProgrossChangedEventArgs : EventArgs
    {
        public float progressNormalized;
    }

    public event EventHandler OnCut;

    private int cuttingProgress;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
                    cuttingProgress = 0;

                    CuttingRecipeSO outputCuttingObjectSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                    OnProgressChanged?.Invoke(this, new OnProgrossChangedEventArgs{
                        
                       
                        progressNormalized = (float)cuttingProgress / outputCuttingObjectSO.cuttingProgressMax

                    });
                    
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

    public override void InteractAlt(PlayerMovementScript player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {

            cuttingProgress ++;

            OnCut?.Invoke(this, EventArgs.Empty);

            CuttingRecipeSO outputCuttingObjectSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());


            OnProgressChanged?.Invoke(this, new OnProgrossChangedEventArgs{
                
                
                progressNormalized = (float)cuttingProgress / outputCuttingObjectSO.cuttingProgressMax

            });

            if (cuttingProgress >= outputCuttingObjectSO.cuttingProgressMax)
            {
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

            GetKitchenObject().SelfDestruct();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
             }
        }
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);

        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        return null;
    }

    private bool HasRecipeWithInput (KitchenObjectSO kitchenObject)
    {
      CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(kitchenObject);

      return (cuttingRecipeSO != null);
      }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputkitchenObjectSO)
    {
        foreach (CuttingRecipeSO test in cuttingRecipeSOsuttingRecipeSOs)
        {
            if (test.input == inputkitchenObjectSO)
            {
                return test;
            }
            
        }
        return null;
    }
}
