using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCOunter : BaseCounter
{
    // Start is called before the first frame update

    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOsuttingRecipeSOs;
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
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

            GetKitchenObject().SelfDestruct();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO test in cuttingRecipeSOsuttingRecipeSOs)
        {
            if (test.input == inputKitchenObjectSO)
            {
                return test.output;
            }
            
        }
        return null;
    }

    private bool HasRecipeWithInput (KitchenObjectSO kitchenObject)
    {
        foreach (CuttingRecipeSO test in cuttingRecipeSOsuttingRecipeSOs)
        {
            if (test.input == kitchenObject)
            {
                return true;
            }
            
        }
        return false;
    }
}
