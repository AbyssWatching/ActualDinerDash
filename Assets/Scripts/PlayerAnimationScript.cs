using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{

    private Animator animator;
    [SerializeField]private PlayerMovementScript playerMovementScript;
    private const string IS_WALKING =  "IsWalking";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(IS_WALKING, playerMovementScript.IsWalking());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
     animator.SetBool(IS_WALKING, playerMovementScript.IsWalking());

    }
}
