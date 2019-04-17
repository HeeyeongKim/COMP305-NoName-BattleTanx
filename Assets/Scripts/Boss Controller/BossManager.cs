using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
     int nextWayPoint = 0;

    [Header("Movement")]
    public float moveSpeed;
    public float rotateSpeed;
    public WayPointPath wayPointSystem;
    public Transform target;
    public GameObject turret1;
    public GameObject turret2;

    void Update()
    {
        MoveWayPoints();    
        TurretRotation();
    }
    void TurretRotation()
    {

        Transform tfPlayer = null;
        Transform tfPlayer2 = null;

        if (GameObject.FindWithTag("Player") != null)
        {
            tfPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        if (GameObject.FindWithTag("Player2") != null)
        {
            tfPlayer2 = GameObject.FindWithTag("Player2").GetComponent<Transform>();
        }


        Vector3 targetPosition;
        Vector2 direction;

        //If the appointed target is still alive, aim at the target conutinuously.
        if (target != null)
        {
            targetPosition = target.position;

            direction = new Vector2(targetPosition.x - turret1.transform.position.x, targetPosition.y - turret1.transform.position.y);

            turret1.transform.up = direction;
        }
        //If the appointed target is already destroyed, try to aim at another alive target.
        else if (tfPlayer != null)
        {
            targetPosition = tfPlayer.position;

            direction = new Vector2(targetPosition.x - turret1.transform.position.x, targetPosition.y - turret1.transform.position.y);

            turret1.transform.up = direction;
        }
        else if (tfPlayer2 != null)
        {
            targetPosition = tfPlayer2.position;

            direction = new Vector2(targetPosition.x - turret1.transform.position.x, targetPosition.y - turret1.transform.position.y);

            turret1.transform.up = direction;

        }

        // 2nd turret
        if (target != null)
        {
            targetPosition = target.position;

            direction = new Vector2(targetPosition.x - turret2.transform.position.x, targetPosition.y - turret2.transform.position.y);

            turret2.transform.up = direction;
        }
        //If the appointed target is already destroyed, try to aim at another alive target.
        else if (tfPlayer2 != null)
        {
            targetPosition = tfPlayer2.position;

            direction = new Vector2(targetPosition.x - turret2.transform.position.x, targetPosition.y - turret2.transform.position.y);

            turret2.transform.up = direction;
        }
        else if (tfPlayer != null)
        {
            targetPosition = tfPlayer.position;

            direction = new Vector2(targetPosition.x - turret2.transform.position.x, targetPosition.y - turret2.transform.position.y);

            turret2.transform.up = direction;

        }


    }

    void MoveWayPoints()
    {
        if(wayPointSystem.wayPoints.Count > 0)
        {
            float wayPointDistance = Vector3.Distance(transform.position, wayPointSystem.wayPoints[nextWayPoint].Position.position);

            if(wayPointDistance == 0)
            {
                if(nextWayPoint == wayPointSystem.wayPoints.Count-1)
                {
                    nextWayPoint = 0;
                }
                else
                {
                    nextWayPoint++;
                }

            }

            Vector3 vectorToTarget = wayPointSystem.wayPoints[nextWayPoint].Position.position - transform.position;
            float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
            Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotateSpeed);

            if(transform.rotation == qt)
            {
                transform.position = Vector3.MoveTowards(transform.position, wayPointSystem.wayPoints[nextWayPoint].Position.position, Time.deltaTime * moveSpeed);

            }
        }
    }
}
