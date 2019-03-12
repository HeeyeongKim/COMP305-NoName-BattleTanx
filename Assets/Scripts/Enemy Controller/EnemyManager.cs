﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    int nextWayPoint = 0;

    [Header("Movement")]
    public float moveSpeed;
    public float rotateSpeed;
    public WayPointPath wayPointSystem;

    void Update()
    {
        MoveWayPoints();    
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