using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamStateManager : MonoBehaviour
{
    private Rigidbody rb;
    public Animator animB;
    public Animator animR;
    public float blueTeamHealth;
    public float redTeamHealth;
    public float blueTeamDamage;
    public float redTeamDamage;
    public bool isTriggerBlue;
    public bool isTriggerRed;
    public bool isDiedB = false;
    public bool isDiedR = false;
    public BlueTeamBaseState currentState;
    public RedTeamBaseState currentStateR;
    public BlueTeamIdleState idleState = new BlueTeamIdleState();
    public BlueTeamWalkingState walkingState = new BlueTeamWalkingState();
   // public BlueTeamHittingState hittingState = new BlueTeamHittingState();
    public BlueTeamAttackingState attackingState = new BlueTeamAttackingState();
   // public BlueTeamDiedState diedState = new BlueTeamDiedState();
    public RedTeamIdleState idleStateR = new RedTeamIdleState();
    public RedTeamWalkingState walkingStateR = new RedTeamWalkingState();
   // public RedTeamHittingState hittingStateR = new RedTeamHittingState();
    public RedTeamAttackingState attackingStateR= new RedTeamAttackingState();
   // public RedTeamDiedState diedStateR = new RedTeamDiedState();

    public static List<GameObject> blueMembers;
    public static List<GameObject> redMembers;


    public int sampleSize = 10;
    public float movingAverageSpeed;
    public AIPath movementScript;
    public AllPlayerDataScriptable dataScriptable;
    



    void Start()
    {
        blueMembers = new List<GameObject>();
        redMembers = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
        SwitchState(idleState);
        SwitchStateR(idleStateR);
        blueTeamHealth = dataScriptable.blueTeamHealth;
        redTeamHealth = dataScriptable.redTeamHealth;
        blueTeamDamage = dataScriptable.blueTeamDamage;
        redTeamDamage = dataScriptable.redTeamDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentState.UpdateState(this);
        currentStateR.UpdateState(this);
        animB.SetFloat("moveSpeed", movementScript.velocity.magnitude);
        animR.SetFloat("moveSpeed", movementScript.velocity.magnitude);
        
        
    }

    public void SwitchState(BlueTeamBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    public void SwitchStateR(RedTeamBaseState state)
    {
        currentStateR = state;
        currentStateR.EnterState(this);
    }
    public void OnTriggerEnter(Collider other)
    {    //for blue team
        if (other.CompareTag("TeamRed"))
        {
            isTriggerBlue = true;
            if (isTriggerBlue == true) TakeDamageRed();
        }
        // for red team
        if (other.CompareTag("TeamBlue"))
        {
            isTriggerRed = true;
            if (isTriggerRed == true) TakeDamageBlue();
        }


    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TeamBlue"))
        {
            isTriggerRed = false;

        }
        if (other.CompareTag("TeamRed"))
        {
            isTriggerBlue = false;

        }
    }

    public void TakeDamageRed()
    {
        redTeamHealth -= blueTeamDamage;
        if(redTeamHealth <= 0)
        {
            animR.SetTrigger("deathR");
            isDiedR = true;
        }
    }
    public void TakeDamageBlue()
    {
        blueTeamHealth -= redTeamDamage;
        if (blueTeamHealth <= 0)
        {
            animB.SetTrigger("death");
            isDiedB = true;
        }
    }




}
