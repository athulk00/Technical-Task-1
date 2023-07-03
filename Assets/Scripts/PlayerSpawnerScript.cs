using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour
{
    public  List<GameObject> blueMembers;
    public  List<GameObject> redMembers;
    public AllPlayerDataScriptable dataScriptable;
    public Transform aiRedParent;
    private GameObject diedPlayerB;
    private GameObject diedPlayerR;
    
    void Start()
    {
        blueMembers = new List<GameObject>();
        redMembers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
        CheckDeadState();   
    }
    public void SpawnTeamA()
    {
        PlayerSpawnerEvent Onevent = GetComponent<PlayerSpawnerEvent>();
        GameObject instanceBlue = Instantiate(dataScriptable.blueTeamPrefab, Onevent.leftMouseClickPosition, Quaternion.identity);
        instanceBlue.transform.SetParent(this.transform);
        blueMembers.Add(instanceBlue);

        Debug.Log("instantiating");
    }
    public void SpawnTeamB()
    {
        PlayerSpawnerEvent Onevent = GetComponent<PlayerSpawnerEvent>();
        GameObject instanceRed = Instantiate(dataScriptable.redTeamPrefab, Onevent.rightMouseClickPosition, Quaternion.identity);
        instanceRed.transform.SetParent(aiRedParent.transform);
        redMembers.Add(instanceRed);

    }
    public void CheckDeadState()
    {
        for (int i = blueMembers.Count-1; i >= 0; i--)
        {
            if (blueMembers[i].GetComponent<BlueTeamStateManager>().isDiedB == true)
            {
                diedPlayerB = blueMembers[i];
                StartCoroutine(DelayB());
                blueMembers.RemoveAt(i);
                
            }

        }
        for (int i = redMembers.Count-1; i >= 0; i--)
        {
            if (redMembers[i].GetComponent<RedTeamStateManager>().isDiedR == true)
            {
                diedPlayerR = redMembers[i];
                StartCoroutine(DelayR());
                redMembers.RemoveAt(i);
            }
        }
    }
    public void SetTarget()
    {
         if (blueMembers.Count == 0 || redMembers.Count == 0) return;
      if(blueMembers.Count == redMembers.Count)
        {
            for(int i = 0; i < blueMembers.Count; i++)
            {
                blueMembers[i].GetComponent<AIDestinationSetter>().target = redMembers[i].transform;
                redMembers[i].GetComponent<AIDestinationSetter>().target = blueMembers[i].transform;
            }
        }
      else if (blueMembers.Count > redMembers.Count)
        {
            int missingIndex = blueMembers.Count - redMembers.Count;
            for(int i = 0; i< blueMembers.Count - missingIndex; i++)
            {
                blueMembers[i].GetComponent<AIDestinationSetter>().target = redMembers[i].transform;
                redMembers[i].GetComponent<AIDestinationSetter>().target = blueMembers[i].transform;

            }
            for(int j = blueMembers.Count - missingIndex; j< blueMembers.Count; j++)
            {
                int intex = UnityEngine.Random.Range(0, redMembers.Count);
                blueMembers[j].GetComponent<AIDestinationSetter>().target = redMembers[0].transform;
            }
        }
      else if(redMembers.Count > blueMembers.Count)
        {
            int missingIndex = redMembers.Count - blueMembers.Count;
            for(int i = 0; i< redMembers.Count- missingIndex; i++)
            {
                blueMembers[i].GetComponent<AIDestinationSetter>().target = redMembers[i].transform;
                redMembers[i].GetComponent<AIDestinationSetter>().target = blueMembers[i].transform;
            }
            for(int j = redMembers.Count - missingIndex; j< redMembers.Count; j++)
            {
                int intex = UnityEngine.Random.Range(0, blueMembers.Count);
                redMembers[j].GetComponent<AIDestinationSetter>().target = blueMembers[0].transform;
            }
        }
    }
    public void GetTargetForBlue(List<GameObject> listB)
    {

    }
    IEnumerator DelayB()
    {
        yield return new WaitForSeconds(2f);
        Destroy(diedPlayerB);
        
    }
    IEnumerator DelayR()
    {
        yield return new WaitForSeconds(2f);
        Destroy(diedPlayerR);

    }



}
