using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    // Start is called before the first frame update
   

   private IKitchenObjectInterface kitchenObjectInterface;


    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParent(IKitchenObjectInterface kitchenObjectInterface)
    {
        if(this.kitchenObjectInterface != null){
            this.kitchenObjectInterface.VoidKitchenObject();
        }

        this.kitchenObjectInterface = kitchenObjectInterface;

        if (kitchenObjectInterface.HasKitchenObject())
        {
            Debug.LogError("IKitchenObject Already has kitchen object");
        }
        
        kitchenObjectInterface.SetKitchenObject(this);

        transform.parent = kitchenObjectInterface.GetKitchenObjectFollowtransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectInterface GetKitchenObjectParent()
    {
        return kitchenObjectInterface;
    }
}
