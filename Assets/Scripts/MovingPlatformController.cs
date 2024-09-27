using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [SerializeField] private Transform BaseObject;
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    private int direction = 1;
    public float MovingSpeed;
    

    // Update is called once per frame
    void Update()
    {
        Vector2 Target = CurrentMovementTarget();
        BaseObject.position = Vector2.Lerp(BaseObject.position, Target, MovingSpeed * Time.deltaTime);
        float distance = (Target - (Vector2)BaseObject.position).magnitude;
        if (distance <= 0.1f)
        {
            direction *= -1;

        }
    }

    private Vector2 CurrentMovementTarget()
    {
        if (direction == 1)
        {
           
            return PointA.position;

        }
        else
        {
            
            return PointB.position;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
