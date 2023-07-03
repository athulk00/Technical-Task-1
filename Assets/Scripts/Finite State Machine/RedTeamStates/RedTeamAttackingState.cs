using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeamAttackingState : RedTeamBaseState
{
    
    public override void EnterState(RedTeamStateManager redTeam)
    {
        redTeam.animR.SetBool("attackR", true);
    }
    public override void UpdateState(RedTeamStateManager redTeam, BlueTeamStateManager blueteam)
    {
        
        if (redTeam.movementScript.velocity.magnitude > 0)
        {
            redTeam.animR.SetBool("attackR", false);
            redTeam.SwitchStateR(redTeam.walkingStateR);
        }
        if (redTeam.isDiedR == true)
        {
            redTeam.animR.SetBool("attackR", false);
            redTeam.SwitchStateR(redTeam.diedStateR);
            
        }
        if (redTeam.destination.target == null) {
            redTeam.animR.SetBool("attackR", false);
            redTeam.SwitchStateR(redTeam.idleStateR);
        } 

    }
    public override void OnCollisionEnter(RedTeamStateManager redTeam, Collider other)
    {
      
    }
}
