using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Transform BaseObject;
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    private int direction=1;
    public float MovingSpeed;
    [SerializeField] SpriteRenderer spriterenderer;

    // Update is called once per frame
    void Update()
    {
        Vector2 Target = CurrentMovementTarget();
        float t = Time.deltaTime * MovingSpeed; // Easing function
        BaseObject.position = Vector2.Lerp(BaseObject.position, Target,t);
        float distance = (Target - (Vector2)BaseObject.position).magnitude;
        if(distance <= 0.1f)
        {
            direction *= -1;
           
        }
    }

    private Vector2 CurrentMovementTarget()
    {
        if (direction == 1)
        {
            spriterenderer.flipX = false;
            return PointA.position;
            
        }
        else
        {
            spriterenderer.flipX = true; 
            return PointB.position;
            
        }
    }
}
