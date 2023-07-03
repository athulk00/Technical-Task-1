using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RedTeamBaseState 
{
    public abstract void EnterState(RedTeamStateManager redTeam);
    public abstract void UpdateState(RedTeamStateManager redTeam, BlueTeamStateManager blueTeam);
    public abstract void OnCollisionEnter(RedTeamStateManager redTeam, Collider other);
}
