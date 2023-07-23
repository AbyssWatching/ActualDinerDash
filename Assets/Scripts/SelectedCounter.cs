using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{

    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObject;
    // Start is called before the first frame update
    void Start()
    {
       // Hide();
        PlayerMovementScript.Instance.OnSelectedCounterChanged += Instance_OnSelecetedCounterChanged;
    }

    private void Instance_OnSelecetedCounterChanged(object sender, PlayerMovementScript.OnSelectedCounterChangedEventArgs e){

        if (e.selectedCounter == baseCounter)
        {
            Show();
        }   else 
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach (GameObject visualObject in visualGameObject)
        {
            visualObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject visualObject in visualGameObject)
        {
            visualObject.SetActive(false);
        }
    }
}
