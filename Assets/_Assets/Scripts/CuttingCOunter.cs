using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCOunter : BaseCounter
{
    // Start is called before the first frame update

    [SerializeField] private KitchenObjectSO cutKitchenSO;
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
             player.GetKitchenObject().SetKitchenObjectParent(this);
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
        if (HasKitchenObject())
        {
            GetKitchenObject().SelfDestruct();

            KitchenObject.SpawnKitchenObject(cutKitchenSO, this);
        }
    }
}
