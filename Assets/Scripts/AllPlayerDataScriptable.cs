using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data")]
public class AllPlayerDataScriptable : ScriptableObject
{
    public  GameObject blueTeamPrefab;
    public  GameObject redTeamPrefab;

    public  float blueTeamHealth;
    public  float redTeamHealth;
    public  float blueTeamDamage;
    public  float redTeamDamage;
}
