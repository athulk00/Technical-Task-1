using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamWalkingState : BlueTeamBaseState
{
    public override void EnterState(BlueTeamStateManager blueTeam)
    {

        
        Debug.Log("walking state");
    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
        if (blueTeam.movementScript.velocity.magnitude <= 0) blueTeam.SwitchState(blueTeam.idleState);
        if (blueTeam.movementScript.velocity.magnitude <= 0 && blueTeam.movementScript.reachedEndOfPath)
            blueTeam.SwitchState(blueTeam.attackingState);
        
        
    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {

    }
}
