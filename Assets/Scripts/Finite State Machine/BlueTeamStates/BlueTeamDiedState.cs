using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamDiedState : BlueTeamBaseState
{
    public override void EnterState(BlueTeamStateManager blueTeam)
    {
        blueTeam.animB.SetTrigger("died");
    }
    public override void UpdateState(BlueTeamStateManager blueTeam, RedTeamStateManager redTeam)
    {
        
    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other)
    {

    }
}
