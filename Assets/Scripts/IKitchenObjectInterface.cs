using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectInterface
{
    public Transform GetKitchenObjectFollowtransform();
   

    public void SetKitchenObject(KitchenObject kitchenObject);
   

    public KitchenObject GetKitchenObject();
   

    public void VoidKitchenObject();
  

    public bool HasKitchenObject();
  
    
}
