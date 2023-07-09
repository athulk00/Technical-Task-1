using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButtonScript : MonoBehaviour
{
    public GameObject eventList;

    public void OpenEventList()
    {
        eventList.SetActive(true);
    }
    public void CloseEventList()
    {
        eventList.SetActive(false);
    }

}
