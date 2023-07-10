using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectInterface
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private GameObject counterTopSpawnPoint;

    [SerializeField] private ClearCounter secondClearCounter;
    // Start is called before the first frame update
    [SerializeField] private bool testing;
   private KitchenObject kitchenObject;


    private void Update(){
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetKitchenObjectParent();
                Debug.Log("we moved the item over bois!");
            }
        }
    }
    public void Interact(PlayerMovementScript player)
    {
        if(kitchenObject == null){

            Debug.Log("We interacting with the clear counter!");
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopSpawnPoint.transform);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }else{
            //give object to parent
            kitchenObject.SetKitchenObjectParent(player);
            
        }
    }

    public Transform GetKitchenObjectFollowtransform()
    {
        return counterTopSpawnPoint.transform;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void VoidKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return (kitchenObject != null);
   
    }
}
