using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTeamDiedState : RedTeamBaseState
{

    public override void EnterState(RedTeamStateManager redTeam)
    {
        redTeam.animR.SetTrigger("diedR");
    }
    public override void UpdateState(RedTeamStateManager redTeam, BlueTeamStateManager blueTeam)
    {
        
    }
    public override void OnCollisionEnter(RedTeamStateManager redTeam, Collider other)
    {

    }
}
