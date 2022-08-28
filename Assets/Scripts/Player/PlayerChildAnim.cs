using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildAnim : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetJump()
    {
        animator.SetBool("isJump", true);
    }

    public void SetIdle()
    {
        animator.SetBool("isJump", false);
    }
}
