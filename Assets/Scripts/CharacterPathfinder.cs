using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CharacterPathfinder : MonoBehaviour
{
    public Vector2 targetPos;
    [SerializeField] float nextWaypointDistance;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    CharacterController charCtrl;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        charCtrl = GetComponent<CharacterController>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    private void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(transform.position, targetPos, OnPathComplete);
            reachedEndOfPath = true;
        }
    }

    private void OnPathComplete(Path newPath)
    {
        if(!newPath.error)
        {
            Debug.Log("Generating Path");
            path = newPath;
            currentWaypoint = 0;
        }
    }

    private void Update()
    {
        if(path == null)
        { return; }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 currentWaypointPos = new Vector2(path.vectorPath[currentWaypoint].x, path.vectorPath[currentWaypoint].y);
        charCtrl.MoveToWaypoint(currentWaypointPos);

        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
