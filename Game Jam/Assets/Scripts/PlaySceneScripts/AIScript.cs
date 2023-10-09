using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public Transform target;//set target from inspector instead of looking in Update

    public float speed = 3f;



    void Start()
    {

    }

    void FixedUpdate()
    {

        var step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target.position, step);



    }
}
