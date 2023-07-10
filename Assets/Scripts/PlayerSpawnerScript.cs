using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSpawnerScript : MonoBehaviour
{
    public  List<GameObject> blueMembers;
    public  List<GameObject> redMembers;
    public AllPlayerDataScriptable dataScriptable;
    public Transform aiRedParent;
    private GameObject diedPlayerB;
    private GameObject diedPlayerR;

    public GameEvent playerBlueSpawnEvent;
    public GameEvent playerRedSpawnEvent;
    public GameEvent playerRedDiedEvent;
    public GameEvent playerBlueDiedEvent;
    public GameObject dialougeBoxBlue;
    public GameObject dialougeBoxRed;
    public GameObject parentPanal;
    private int bluePlayerId = 1;
    private int redPlayerId = 1;
    private float currentTime;
    private float referenceTimeBlue;
    private float timeDefferenceBlue;
    private int minutesAgoBlue;
    private float referenceTimeRed;
    private float timeDefferenceRed;
    private int minutesAgoRed;
    private int idBlue;
    private int idRed;
    private float referenceTimeDiedBlue;
    private float referenceTimeDiedRed;

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
        currentTime = Time.time;
        timeDefferenceBlue = (currentTime - referenceTimeBlue) / 60f;
        minutesAgoBlue = Mathf.FloorToInt(timeDefferenceBlue);
        timeDefferenceRed = (currentTime - referenceTimeRed) / 60f;
        minutesAgoBlue = Mathf.FloorToInt(timeDefferenceRed);
    }
    public void SpawnTeamA()
    {
        PlayerSpawnerEvent Onevent = GetComponent<PlayerSpawnerEvent>();
        GameObject instanceBlue = Instantiate(dataScriptable.blueTeamPrefab, Onevent.leftMouseClickPosition, Quaternion.identity);
        instanceBlue.transform.SetParent(this.transform);
        playerBlueSpawnEvent.Raise();
        blueMembers.Add(instanceBlue);
        bluePlayerId++;
    }
    public void SpawnTeamB()
    {
        PlayerSpawnerEvent Onevent = GetComponent<PlayerSpawnerEvent>();
        GameObject instanceRed = Instantiate(dataScriptable.redTeamPrefab, Onevent.rightMouseClickPosition, Quaternion.identity);
        instanceRed.transform.SetParent(aiRedParent.transform);
        playerRedSpawnEvent.Raise();
        redMembers.Add(instanceRed);
        redPlayerId++;
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

    public void CheckDeadState()
    {
        for (int i = blueMembers.Count - 1; i >= 0; i--)
        {
            if (blueMembers[i].GetComponent<BlueTeamStateManager>().isDiedB == true)
            {
                blueMembers[i].GetComponent<BlueTeamStateManager>().destination.target = null;
                referenceTimeDiedBlue = Time.time;
                idBlue = blueMembers.IndexOf(blueMembers[i]) + 1;
                diedPlayerB = blueMembers[i];
                playerBlueDiedEvent.Raise();
                StartCoroutine(DelayB());
                blueMembers.RemoveAt(i);

            }

        }
        for (int i = redMembers.Count - 1; i >= 0; i--)
        {
            if (redMembers[i].GetComponent<RedTeamStateManager>().isDiedR == true)
            {
                redMembers[i].GetComponent<RedTeamStateManager>().destination.target = null;
                referenceTimeDiedRed = Time.time;
                idRed = redMembers.IndexOf(redMembers[i]) + 1;
                diedPlayerR = redMembers[i];
                playerRedDiedEvent.Raise();
                StartCoroutine(DelayR());
                redMembers.RemoveAt(i);
            }
        }
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

    public void OnPlayerSpawnBlue()
    {
        GameObject instance = Instantiate(dialougeBoxBlue);
        instance.transform.SetParent(parentPanal.transform);
        instance.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        TextMeshProUGUI[] textFields = instance.GetComponentsInChildren<TextMeshProUGUI>();
        PlayerSpawnerEvent Onevent = GetComponent<PlayerSpawnerEvent>();
        referenceTimeBlue = Time.time;
        foreach (TextMeshProUGUI textField in textFields)
        {
            if (textField.name == "PlayerIDText")
                textField.text = "BluePlayer_" + bluePlayerId;
            if (textField.name == "EventDetailsText")
                textField.text = "BluePlayer_" + bluePlayerId +" "+ "Spawn at " + " " + Onevent.leftMouseClickPosition;
            if (textField.name == "EventOcuredTimeText")
            {
                
                
                textField.text = minutesAgoBlue.ToString() + "min ago";
            }
                
        }
    }
    public void OnPlayerRedSpawn()
    {
        GameObject instance = Instantiate(dialougeBoxRed);
        instance.transform.SetParent(parentPanal.transform);
        instance.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        TextMeshProUGUI[] textFields = instance.GetComponentsInChildren<TextMeshProUGUI>();
        PlayerSpawnerEvent Onevent1 = GetComponent<PlayerSpawnerEvent>();
        referenceTimeRed = Time.time;
        foreach (TextMeshProUGUI textField in textFields)
        {
            if (textField.name == "PlayerIDText")
                textField.text = "RedPlayer_" + redPlayerId;
            if (textField.name == "EventDetailsText")
                textField.text = "RedPlayer_" + redPlayerId + " " + "Spawn at " + " " + Onevent1.rightMouseClickPosition;
            if (textField.name == "EventOcuredTimeText")
            {


                textField.text = minutesAgoRed.ToString() + "min ago";
            }

        }

    }
    public void OnDieBlue()
    {
        GameObject instance = Instantiate(dialougeBoxBlue);
        instance.transform.SetParent(parentPanal.transform);
        instance.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        TextMeshProUGUI[] textFields = instance.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textField in textFields)
        {
            if (textField.name == "PlayerIDText")
                textField.text = "BluePlayer_" + idBlue;
            if (textField.name == "EventDetailsText")
                textField.text = "BluePlayer_" + idBlue + " " + "Killed By RedPlayer";
            if (textField.name == "EventOcuredTimeText")
            {
                float timeDifference = (currentTime - referenceTimeRed) / 60f;
                float minutesAgoBlueDied = Mathf.FloorToInt(timeDifference);

                textField.text = minutesAgoBlueDied.ToString() + "min ago";
            }

        }
    }
    public void OnDieRed()
    {
        GameObject instance = Instantiate(dialougeBoxRed);
        instance.transform.SetParent(parentPanal.transform);
        instance.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        TextMeshProUGUI[] textFields = instance.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textField in textFields)
        {
            if (textField.name == "PlayerIDText")
                textField.text = "RedPlayer_" + idRed;
            if (textField.name == "EventDetailsText")
                textField.text = "RedPlayer_" + idRed + " " + "Killed By BluePlayer";
            if (textField.name == "EventOcuredTimeText")
            {
                float timeDifference = (currentTime - referenceTimeRed) / 60f;
                float minutesAgoRedDied = Mathf.FloorToInt(timeDifference);

                textField.text = minutesAgoRedDied.ToString() + "min ago";
            }

        }

    }
  

}
