using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamAttackingState : BlueTeamBaseState
{
    
    public override void EnterState(BlueTeamStateManager blueTeam)
    {
        blueTeam.animB.SetBool("attack", true);
    }
    public override void UpdateState(BlueTeamStateManager blueTeam, RedTeamStateManager redTeam)
    {
       
        if (blueTeam.movementScript.velocity.magnitude > 0 ) {

            blueTeam.animB.SetBool("attack", false);
            blueTeam.SwitchState(blueTeam.walkingState);
        }
        if (blueTeam.isDiedB == true)
        {
            blueTeam.animB.SetBool("attack", false);
            blueTeam.SwitchState(blueTeam.diedState);
            redTeam.SwitchStateR(redTeam.idleStateR);
        }
        if (blueTeam.destination.target == null)
        {
            blueTeam.animB.SetBool("attack", false);
            blueTeam.SwitchState(blueTeam.idleState);
        }
    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {
     
    }
}
