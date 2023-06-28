using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamStateManager : MonoBehaviour
{
    private Rigidbody rb;
    public Animator anim;
    public BlueTeamBaseState currentState;
    public BlueTeamIdleState idleState = new BlueTeamIdleState();
    public BlueTeamWalkingState walkingState = new BlueTeamWalkingState();
    public BlueTeamHittingState hittingState = new BlueTeamHittingState();
    public BlueTeamAttackingState attackingState = new BlueTeamAttackingState();

    public static List<GameObject> blueMembers;
    public static List<GameObject> redMembers;


    public int sampleSize = 10;
    public float movingAverageSpeed;
    public AIPath movementScript;
    



    void Start()
    {
        blueMembers = new List<GameObject>();
        redMembers = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
        SwitchState(idleState);
       
    }

    // Update is called once per frame
    void Update()
    {
        
        currentState.UpdateState(this);
        anim.SetFloat("moveSpeed", movementScript.velocity.magnitude);
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
    public void SwitchState(BlueTeamBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

   


}
