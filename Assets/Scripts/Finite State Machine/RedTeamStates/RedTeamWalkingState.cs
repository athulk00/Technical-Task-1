using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeamWalkingState : RedTeamBaseState
{

    public override void EnterState(RedTeamStateManager redTeam)
    {

    }
    public override void UpdateState(RedTeamStateManager redTeam, BlueTeamStateManager blueTeam)
    {
        if (redTeam.movementScript.velocity.magnitude <= 0) redTeam.SwitchStateR(redTeam.idleStateR);
        if (redTeam.movementScript.velocity.magnitude <= 0 && redTeam.movementScript.reachedEndOfPath)
            redTeam.SwitchStateR(redTeam.attackingStateR);
    }
    public override void OnCollisionEnter(RedTeamStateManager redTeam, Collider other)
    {

    }
}
