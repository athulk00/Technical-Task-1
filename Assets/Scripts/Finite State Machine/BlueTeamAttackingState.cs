using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamAttackingState : BlueTeamBaseState
{

    public override void EnterState(BlueTeamStateManager blueTeam)
    {
        blueTeam.anim.SetBool("attack", true);
        Debug.Log("Attacking");
    }
    public override void UpdateState(BlueTeamStateManager blueTeam)
    {
        

    }
    public override void OnCollisionEnter(BlueTeamStateManager blueTeam, Collision collision)
    {

    }
}
