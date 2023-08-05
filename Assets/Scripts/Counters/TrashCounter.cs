using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public override void Interact(PlayerMovementScript player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().SelfDestruct();
        }
        //base.Interact(player);
    }

   
}
