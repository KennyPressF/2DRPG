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
    [SerializeField] bool isMoving = false;

    Seeker seeker;
    CharacterMotor charCtrl;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        charCtrl = GetComponent<CharacterMotor>();

        targetPos = transform.position;
    }
    public void SetNewPath(Vector2 clickPos)
    {
        targetPos = clickPos;
        isMoving = true;

        if (seeker.IsDone() && isMoving)
        {
            seeker.StartPath(transform.position, targetPos, OnGeneratePathComplete);
        }
    }

    private void OnGeneratePathComplete(Path newPath)
    {
        if (!newPath.error)
        {
            Debug.Log("Generating Path");
            path = newPath;
            currentWaypoint = 0;
        }
    }

    private void Update()
    {
        if (path == null)
        { return; }


        if (currentWaypoint >= path.vectorPath.Count)
        {
            isMoving = false;
            return;
        }
        else
        {
            isMoving = true;
        }


        if(isMoving)
        {
            Vector2 currentWaypointPos = new Vector2(path.vectorPath[currentWaypoint].x, path.vectorPath[currentWaypoint].y);
            charCtrl.MoveToWaypoint(currentWaypointPos);
        }
        

        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
