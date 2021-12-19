using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAttack : StateMachineBehaviour
{
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown("e"))
        {
            animator.SetBool("IsAttacking", true);
        }
    }

}
