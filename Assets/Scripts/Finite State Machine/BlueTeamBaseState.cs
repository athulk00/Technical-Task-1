
using UnityEngine;
public abstract class BlueTeamBaseState 
{
    public abstract void EnterState(BlueTeamStateManager blueTeam);
    public abstract void UpdateState(BlueTeamStateManager blueTeam, RedTeamStateManager redTeam);
    public abstract void OnCollisionEnter(BlueTeamStateManager blueTeam, Collider other);

}
