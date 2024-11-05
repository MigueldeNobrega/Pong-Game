using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteriaGoal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Ball ball = collision.GetComponent<Ball>();
        

        if(ball)
        {
            ball.ResetPosition();



        }
    }



}
