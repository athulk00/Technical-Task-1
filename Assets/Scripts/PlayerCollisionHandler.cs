using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private RedTeamStateManager redManager;
    private BlueTeamStateManager blueManager;


    public void Start()
    {
        if(this.gameObject.tag == "TeamRed")
        {
            redManager = GetComponent<RedTeamStateManager>();
        }
        else
        {
            blueManager = GetComponent<BlueTeamStateManager>();
        }
        
        
    }

    public void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "TeamBlue")
        {
            blueManager = other.GetComponent<BlueTeamStateManager>();
            blueManager.TakeDamage();
            
            
        }
        else if(other.gameObject.tag =="TeamRed")
        {
            redManager = other.GetComponent<RedTeamStateManager>();
            redManager.TakeDamage();
        }

    }
   
}
