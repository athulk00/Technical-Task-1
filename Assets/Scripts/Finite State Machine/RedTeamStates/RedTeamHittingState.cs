using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeamHittingState : RedTeamBaseState
{

    public override void EnterState(BlueTeamStateManager blueTeam)
    {
        /*if(blueTeam.isTriggerBlue == true)
        {
            blueTeam.animR.SetBool("hittingR", true);
            blueTeam.redTeamHealth -= blueTeam.blueTeamDamage;
        }   */
    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
       /* if (blueTeam.isTriggerBlue == false)
        {
            blueTeam.animR.SetBool("hittingR", false);
            blueTeam.SwitchStateR(blueTeam.attackingStateR);
        }
        if (blueTeam.redTeamHealth <= 0)
        {
            blueTeam.animR.SetBool("hittingR", false);
            blueTeam.SwitchStateR(blueTeam.diedStateR);
        }
        if (blueTeam.isTriggerBlue == false && blueTeam.movementScript.velocity.magnitude > 0) blueTeam.SwitchStateR(blueTeam.walkingStateR);*/
    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {

    }
}
