using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : StateMachineBehaviour
{
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown("r"))
        {
            animator.SetBool("IsDamaged", true);
        }
    }
}
