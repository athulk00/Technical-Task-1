using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RedTeamStateManager : MonoBehaviour
{
    public Animator animR;
    private Rigidbody rb;
    public float redTeamHealth;
    public float blueTeamDamage;
    public bool isDiedR = false;
    public bool diedB;
    public bool isTriggerRed;
    public HealthBar healthbar;
    public RedTeamBaseState currentStateR;
    public RedTeamIdleState idleStateR = new RedTeamIdleState();
    public RedTeamWalkingState walkingStateR = new RedTeamWalkingState();
    public RedTeamAttackingState attackingStateR = new RedTeamAttackingState();
    public RedTeamDiedState diedStateR = new RedTeamDiedState();

    public AIPath movementScript;
    public AIDestinationSetter destination;
    public BlueTeamStateManager blueManager;
    public AllPlayerDataScriptable dataScriptable;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SwitchStateR(idleStateR);
        redTeamHealth = dataScriptable.redTeamHealth;
        blueTeamDamage = dataScriptable.blueTeamDamage;
        healthbar.SetMaxHealth(dataScriptable.redTeamHealth);
        
    }

    // Update is called once per frame
    void Update()
    {

        currentStateR.UpdateState(this, blueManager);
        animR.SetFloat("moveSpeed", movementScript.velocity.magnitude);
        
        
    }

    public void SwitchStateR(RedTeamBaseState state)
    {
        currentStateR = state;
        currentStateR.EnterState(this);
    }
 
    public void TakeDamage()
    {
        
        redTeamHealth -= blueTeamDamage;
        healthbar.SetHealth(redTeamHealth);
        if (redTeamHealth <= 0)
        {
            isDiedR = true;
            
        }
    }



}
