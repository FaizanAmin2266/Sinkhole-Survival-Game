using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{
    public Logic logic;
    ScoreLogic scorelog;

    CarController cont;


    void Awake()
    {
        cont = GetComponent<CarController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        scorelog = GameObject.FindGameObjectWithTag("Logic2").GetComponent<ScoreLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scorelog.getAlive() == true)
        {
            Vector2 inputVector = Vector2.zero;
            //inputVector.x = UnityEngine.Input.GetAxis("Horizontal");
            inputVector.x = SimpleInput.GetAxis("Horizontal");
            //inputVector.y = UnityEngine.Input.GetAxis("Vertical");
            inputVector.y = 1;
            cont.SetInputVector(inputVector);
        }
        else
        {
            cont.SetInputVector(new Vector2(0, 0));
        }


        //Vector2 inputVector = Vector2.zero;
        //inputVector.x = UnityEngine.Input.GetAxis("Horizontal");
        //inputVector.y = UnityEngine.Input.GetAxis("Vertical");
        //cont.SetInputVector(inputVector);
    }
}
