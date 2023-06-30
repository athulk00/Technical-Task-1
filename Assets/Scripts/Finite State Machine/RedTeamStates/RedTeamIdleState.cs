using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeamIdleState : RedTeamBaseState
{

    public override void EnterState(BlueTeamStateManager blueTeam)
    {

    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
        if (blueTeam.movementScript.velocity.magnitude > 0)
        {
            blueTeam.SwitchStateR(blueTeam.walkingStateR);
        }
    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {

    }
}
