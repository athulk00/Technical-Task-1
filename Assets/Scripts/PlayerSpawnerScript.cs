using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour
{
    public static List<GameObject> blueMembers;
    public static List<GameObject> redMembers;



    private int count = 0;
    void Start()
    {
        blueMembers = new List<GameObject>();
        redMembers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
    }
    public void SpawnTeamA()
    {
        PlayerSpawnerEvent Onevent = GetComponent<PlayerSpawnerEvent>();
        GameObject instanceBlue = Instantiate(Onevent.teamA, Onevent.leftMouseClickPosition, Quaternion.identity);
        instanceBlue.transform.SetParent(this.transform);
        blueMembers.Add(instanceBlue);

        Debug.Log("instantiating");
    }
    public void SpawnTeamB()
    {
        PlayerSpawnerEvent Onevent = GetComponent<PlayerSpawnerEvent>();
        GameObject instanceRed = Instantiate(Onevent.teamB, Onevent.rightMouseClickPosition, Quaternion.identity);
        redMembers.Add(instanceRed);

    }
    public void SetTarget()
    {
        for(int i = 0; i< blueMembers.Count; i++)
        {
            if (blueMembers.Count == redMembers.Count)
            {
                Debug.Log("entering");
                blueMembers[i].GetComponent<AIDestinationSetter>().target = redMembers[i].transform;
            }
            else if(blueMembers.Count > redMembers.Count)
            {
                int missingTarget = blueMembers.Count - redMembers.Count;
                
                for(int j =blueMembers.Count-missingTarget; j< blueMembers.Count;j++)
                {
                    int redmemberIndex = UnityEngine.Random.Range(0, redMembers.Count);
                    blueMembers[j].GetComponent<AIDestinationSetter>().target = redMembers[redmemberIndex].transform;
                }
            }
            
            
        }
    }
}
