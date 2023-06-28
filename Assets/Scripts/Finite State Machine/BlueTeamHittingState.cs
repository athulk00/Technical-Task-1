using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamHittingState : BlueTeamBaseState
{
    public override void EnterState(BlueTeamStateManager blueTeam)
    {
        blueTeam.anim.SetBool("hitting", true);
    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
        
    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collision collision)
    {
        
    }
}
