using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamIdleState : BlueTeamBaseState
{
    
    public override void EnterState(BlueTeamStateManager blueTeam)
    {

        Debug.Log("idle");
    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
        if (blueTeam.movementScript.velocity.magnitude > 0)
        {
            blueTeam.SwitchState(blueTeam.walkingState);
        }
      
       

    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {
       /*if(collision.gameObject.CompareTag("dsfsf") )
        {
            blueTeam.SwitchState(blueTeam.hittingState);
        }*/
    }
}
