using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{

    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementScript.Instance.OnSelectedCounterChanged += Instance_OnSelecetedCounterChanged;
    }

    private void Instance_OnSelecetedCounterChanged(object sender, PlayerMovementScript.OnSelectedCounterChangedEventArgs e){

        if (e.selectedCounter == clearCounter)
        {
            Show();
        }   else 
        {
            Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
