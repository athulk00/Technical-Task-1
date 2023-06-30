using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamAttackingState : BlueTeamBaseState
{

    public override void EnterState(BlueTeamStateManager blueTeam)
    {
        blueTeam.animB.SetBool("attack", true);
        
        Debug.Log("Attacking");
    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
        if (blueTeam.movementScript.velocity.magnitude > 0 ) {
            blueTeam.animB.SetBool("attack", false);
            blueTeam.SwitchState(blueTeam.walkingState);
        }
           

    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {
       /* if (other.CompareTag("TeamBlue") && blueTeam.isTriggerRed == true)
        {
            blueTeam.SwitchState(blueTeam.hittingState);
        }*/
       
    }
}
