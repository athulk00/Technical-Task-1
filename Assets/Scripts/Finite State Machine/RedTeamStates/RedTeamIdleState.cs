using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeamIdleState : RedTeamBaseState
{

    public override void EnterState(RedTeamStateManager redTeam)
    {

    }
    public override void UpdateState(RedTeamStateManager redTeam, BlueTeamStateManager blueTeam)
    {
        if (redTeam.movementScript.velocity.magnitude > 0)
        {
            redTeam.SwitchStateR(redTeam.walkingStateR);
        }
    }
    public override void OnCollisionEnter(RedTeamStateManager redTeam, Collider other)
    {

    }
}
