using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerSpawnerEvent : MonoBehaviour
{
    public UnityEvent teamBlueSpawnEvent;
    public UnityEvent teamRedSpawnEvent;
    public Vector3 leftMouseClickPosition;
    public Vector3 rightMouseClickPosition;
    public Camera mainCam;
    public GameObject teamA;
    public GameObject teamB;
    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            leftMouseClickPosition = Input.mousePosition;
            Ray ray = mainCam.ScreenPointToRay(leftMouseClickPosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                leftMouseClickPosition = hit.point;
            }
            teamBlueSpawnEvent?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            rightMouseClickPosition = Input.mousePosition;
            Ray ray = mainCam.ScreenPointToRay(rightMouseClickPosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                rightMouseClickPosition = hit.point;
            }
            teamRedSpawnEvent?.Invoke();
        }

    }
}
