using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartJump : StateMachineBehaviour
{

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
        }
    }
}
