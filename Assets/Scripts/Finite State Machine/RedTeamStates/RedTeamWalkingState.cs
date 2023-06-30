using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeamWalkingState : RedTeamBaseState
{

    public override void EnterState(BlueTeamStateManager blueTeam)
    {

    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
        if (blueTeam.movementScript.velocity.magnitude <= 0) blueTeam.SwitchStateR(blueTeam.idleStateR);
        if (blueTeam.movementScript.velocity.magnitude <= 0 && blueTeam.movementScript.reachedEndOfPath)
            blueTeam.SwitchStateR(blueTeam.attackingStateR);
    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {

    }
}
