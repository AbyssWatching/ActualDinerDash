using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingItemVisualFromContainer : MonoBehaviour
{
    //Seriealized fields
    [SerializeField] private ContainerCounter containerCounter;

    //fields
    private const string OPEN_CLOSE = "OpenClose";
    private Animator animator;


    //methods
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ContainerCounter_OnPlayerGrabbedObj(object sender, System.EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
