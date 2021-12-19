using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishAttack : StateMachineBehaviour
{
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsAttacking", false);
    }
}
