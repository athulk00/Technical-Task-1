using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamHittingState : BlueTeamBaseState
{
    public override void EnterState(BlueTeamStateManager blueTeam)
    {
       /* if(blueTeam.isTriggerRed == true)
        {
            blueTeam.animB.SetBool("hitting", true);
            blueTeam.blueTeamHealth -= blueTeam.redTeamDamage;
        }*/
     
    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
       /* if (blueTeam.isTriggerRed == false)
        {
            blueTeam.animB.SetBool("hitting", false);
            blueTeam.SwitchState(blueTeam.attackingState);
        }
        if (blueTeam.blueTeamHealth <= 0 )
        {
            blueTeam.animB.SetBool("hitting", false);
            blueTeam.SwitchState(blueTeam.diedState);
        }       
        if (blueTeam.isTriggerRed == false && blueTeam.movementScript.velocity.magnitude > 0) blueTeam.SwitchState(blueTeam.walkingState);
        */

    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {
        
    }
}
