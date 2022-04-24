using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroler : MonoBehaviour
{
    public float speed;

    public int positionOfPatrol;
    public Transform point;
    bool movingRight = true;

    Transform player;
    public float stoppingDistance;
    bool chill = false;
    bool angry = false;
    bool goBack = false;    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, point.position)< positionOfPatrol && angry == false)
        {
           chill = true;    
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true; 
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }
        if(chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            angry = true;
        }
        else if (goBack == true)
        {
            GoBack();
        }
    }

    void Chill()
    {
        if(transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;

        }
        else if(transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
        }
        if(movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 5;
    }
     void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);

    }
}
