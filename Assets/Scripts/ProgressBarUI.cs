using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;

    [SerializeField] CuttingCOunter cuttingCOunter;

    private void Start()
    {
        cuttingCOunter.OnProgressChanged += cuttingCOunter_OnProgressChanged;
        barImage.fillAmount = 0f;

        Hide();
    }

    private void cuttingCOunter_OnProgressChanged(object sender, CuttingCOunter.OnProgrossChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            Hide();
        }
        else{
            Show();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
