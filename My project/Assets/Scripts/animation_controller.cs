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
        bool SKeyPressed = Input.GetKey(KeyCode.S);
        bool AKeyPressed = Input.GetKey(KeyCode.A);
        bool DKeyPressed = Input.GetKey(KeyCode.D);
        bool IsWalking = animator.GetBool("IsWalking");
        if (WKeyPressed || SKeyPressed || AKeyPressed || DKeyPressed) 
        {
            animator.SetBool("IsWalking", true);
        }
        else if(IsWalking && !WKeyPressed && !AKeyPressed && !SKeyPressed && !DKeyPressed)
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
