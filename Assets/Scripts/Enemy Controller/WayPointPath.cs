using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointPath : MonoBehaviour
{
    public List<WayPoint> wayPoints = new List<WayPoint>();
    public Color lineColor = Color.white;
    public Color SphereColor = Color.white;
    public GameObject turret;

    void OnDrawGizmos()
    {


        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        wayPoints = new List<WayPoint>();
        
        foreach(Transform t in pathTransform)
        {
            if(t != transform)
            {
                WayPoint newWayPoint = new WayPoint();
                newWayPoint.Position = t;
                wayPoints.Add(newWayPoint);
            }
        }

        for (int i = 0; i < wayPoints.Count; i++)
        {
            Vector3 currentWaypoint = wayPoints[i].Position.position;
            Vector3 previousWaypoint = Vector3.zero;

            if (i > 0)
            {
                previousWaypoint = wayPoints[i - 1].Position.position;
            }
            else if (i == 0 && wayPoints.Count >= 2)
            {
                previousWaypoint = wayPoints[wayPoints.Count - 1].Position.position;
            }

            Gizmos.color = lineColor;

            Gizmos.DrawLine(previousWaypoint, currentWaypoint);

            Gizmos.color = SphereColor;
            Gizmos.DrawWireSphere(currentWaypoint, 0.2f);
        }
    }

    //void Update()
    //{
    //    TurrentRotation();
    //}

    //void TurrentRotation()
    //{
    //    Vector3 mousePosition = Input.mousePosition;
    //    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

    //    Vector2 direction = new Vector2(mousePosition.x - turret.transform.position.x, mousePosition.y - turret.transform.position.y);

    //    turret.transform.up = direction;
    //}


}
