using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishJump : StateMachineBehaviour
{
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsJumping", false);
    }
}
