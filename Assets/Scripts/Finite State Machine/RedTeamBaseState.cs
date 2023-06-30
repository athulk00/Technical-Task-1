using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RedTeamBaseState 
{
    public abstract void EnterState(BlueTeamStateManager blueTeam);
    public abstract void UpdateState(BlueTeamStateManager blueTeam);
    public abstract void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other);
}
