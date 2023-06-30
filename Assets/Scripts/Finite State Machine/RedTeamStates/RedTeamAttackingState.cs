using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeamAttackingState : RedTeamBaseState
{
    public override void EnterState(BlueTeamStateManager blueTeam)
    {
        blueTeam.animR.SetBool("attackR", true);

    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
        if (blueTeam.movementScript.velocity.magnitude > 0)
        {
            blueTeam.animR.SetBool("attackR", false);
            blueTeam.SwitchStateR(blueTeam.walkingStateR);
        }
    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {
       /* if (other.CompareTag("TeamRed") && blueTeam.isTriggerBlue == true)
        {
            blueTeam.SwitchStateR(blueTeam.hittingStateR);
        }*/
    }
}
