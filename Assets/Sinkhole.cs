using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinkhole : MonoBehaviour
{
    
    public Logic logic;
    public float timer = 0;
    public float timeUntilDespawn = 4;
    
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        
    }

    
    void Update()                       // Removes sinkhole after certain amount of time.
    {
        if (timer < timeUntilDespawn)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)        // Checks if car has entered sinkhole, ends game if true
    {
        if (timer > 2.1)
        {
            
            logic.gameOver();
        }
        
    }
}
