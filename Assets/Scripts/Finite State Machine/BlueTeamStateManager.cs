using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeamStateManager : MonoBehaviour
{
    private Rigidbody rb;
    public Animator animB;
    public float blueTeamHealth;
    public float redTeamDamage;
    public float blueTeamDamage;
    public bool isTriggerBlue;
    public bool isDiedB = false;
    public bool diedR;
    public HealthBar healthbar;
    public BlueTeamBaseState currentState;
    public RedTeamStateManager redTeam;
    public BlueTeamIdleState idleState = new BlueTeamIdleState();
    public BlueTeamWalkingState walkingState = new BlueTeamWalkingState();
    public BlueTeamAttackingState attackingState = new BlueTeamAttackingState();
    public BlueTeamDiedState diedState = new BlueTeamDiedState();
  


    public AIPath movementScript;
    public AIDestinationSetter destination;
    public RedTeamStateManager redManager ;
    public AllPlayerDataScriptable dataScriptable;
 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SwitchState(idleState);
        blueTeamHealth = dataScriptable.blueTeamHealth;
        redTeamDamage = dataScriptable.redTeamDamage;
        healthbar.SetMaxHealth(dataScriptable.blueTeamHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        currentState.UpdateState(this, redManager);
        animB.SetFloat("moveSpeed", movementScript.velocity.magnitude);
       
    }

    public void SwitchState(BlueTeamBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void TakeDamage()
    {
        blueTeamHealth -= redTeamDamage;
        healthbar.SetHealth(blueTeamHealth);
        if (blueTeamHealth <= 0)
        {
            isDiedB = true;
        }
    }
  
  




}
