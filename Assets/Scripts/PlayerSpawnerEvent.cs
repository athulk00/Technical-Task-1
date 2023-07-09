using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerSpawnerEvent : MonoBehaviour
{
    public UnityEvent teamBlueSpawnEvent;
    public UnityEvent teamRedSpawnEvent;
    public Vector3 leftMouseClickPosition;
    public Vector3 rightMouseClickPosition;
    public Camera mainCam;
    public LayerMask ground;
    private bool isClickOnUI;




    public void Update()
    {
        isClickOnUI = EventSystem.current.IsPointerOverGameObject();
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isClickOnUI)
        {
            leftMouseClickPosition = Input.mousePosition;
            Ray ray = mainCam.ScreenPointToRay(leftMouseClickPosition);
            if(Physics.Raycast(ray, out RaycastHit hit, ground))
            {
                leftMouseClickPosition = hit.point;
            }
            teamBlueSpawnEvent?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !isClickOnUI)
        {
            rightMouseClickPosition = Input.mousePosition;
            Ray ray = mainCam.ScreenPointToRay(rightMouseClickPosition);
            if (Physics.Raycast(ray, out RaycastHit hit, ground))
            {
                rightMouseClickPosition = hit.point;
            }
            teamRedSpawnEvent?.Invoke();
        }

    }
}
