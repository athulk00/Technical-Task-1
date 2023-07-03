using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamWalkingState : BlueTeamBaseState
{
    public override void EnterState(BlueTeamStateManager blueTeam)
    {
    }
    public override void UpdateState(BlueTeamStateManager blueTeam, RedTeamStateManager redTeam)
    {
        if (blueTeam.movementScript.velocity.magnitude <= 0) blueTeam.SwitchState(blueTeam.idleState);
        if (blueTeam.movementScript.velocity.magnitude <= 0 && blueTeam.movementScript.reachedEndOfPath)
            blueTeam.SwitchState(blueTeam.attackingState); 
    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {

    }
}
