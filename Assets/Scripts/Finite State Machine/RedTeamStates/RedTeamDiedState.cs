using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeamDiedState : RedTeamBaseState
{

    public override void EnterState(BlueTeamStateManager blueTeam)
    {
        
        
           // blueTeam.animR.SetTrigger("deathR");
            
        
    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
        
    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {

    }
}
