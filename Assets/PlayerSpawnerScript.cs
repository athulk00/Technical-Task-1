using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour
{
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTeamA()
    {
        PlayerSpawnerEvent Onevent = GetComponent<PlayerSpawnerEvent>();
        Instantiate(Onevent.teamA, Onevent.leftMouseClickPosition, Quaternion.identity);
        Debug.Log("instantiating");
    }
    public void SpawnTeamB()
    {
        PlayerSpawnerEvent Onevent = GetComponent<PlayerSpawnerEvent>();
        Instantiate(Onevent.teamB, Onevent.rightMouseClickPosition, Quaternion.identity);
    }
}
