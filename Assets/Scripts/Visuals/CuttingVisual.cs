using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingVisual : MonoBehaviour
{
    //Seriealized fields
    [SerializeField] private CuttingCOunter cuttingCounter;

    //fields
    private const string CUT = "Cut";
    private Animator animator;


    //methods
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
}
