using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    
    public animation_controller(Animator animator)
    {
        this.animator = animator;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool WKeyPressed = Input.GetKey(KeyCode.W);
        bool IsWalking = animator.GetBool("IsWalking");
        if (WKeyPressed) 
        {
            animator.SetBool("IsWalking", true);
        }
        else if(IsWalking && !WKeyPressed)
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
