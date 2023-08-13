using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{

    private enum State{

        Idle,
        Frying,
        Fried,
        Burned,

    }
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOs;
    [SerializeField] private BurningRecipeSO[] burningRecipeSOs;

    private State state;

    private float fryingTimer;

    private float burningTimer;

    private FryingRecipeSO fryingRecipeSO;

    private BurningRecipeSO burningRecipeSO;

    private void Start()
    {
        state = State.Idle;
    }

    public void Update()
    {

        if (HasKitchenObject())
        {
            switch(state){
                case State.Idle:
                    break;
                case State.Frying:
                    fryingTimer += Time.deltaTime;
            
                    if(fryingTimer > fryingRecipeSO.fryingTimerMax)
                    {
                        //fryied
                        Debug.Log("Fried");
                       
                        
                        GetKitchenObject().SelfDestruct();
                        KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);

                        state = State.Fried;
                        Debug.Log("Object Fried!");
                        burningTimer = 0f;
                        burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                    }
                    Debug.Log(fryingTimer);
                    break;
                case State.Fried:
                    burningTimer += Time.deltaTime;
            
                    if(burningTimer > burningRecipeSO.burningTimer)
                    {
                        //burned
                        Debug.Log("burned");
                       
                        
                        GetKitchenObject().SelfDestruct();
                        KitchenObject.SpawnKitchenObject(burningRecipeSO.output, this);
                        Debug.Log("Object Burned!");
                        state = State.Burned;
                    }
                    break;
                case State.Burned:
                    break;
            }
            Debug.Log(state);
        }

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

                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                    state = State.Frying;

                    fryingTimer = 0;
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
                state = State.Idle;
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

      return fryingRecipeSO != null;
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

        private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO inputkitchenObjectSO)
    {
        foreach (BurningRecipeSO test in burningRecipeSOs)
        {
            if (test.input == inputkitchenObjectSO)
            {
                return test;
            }
            
        }
        return null;
    }

}
