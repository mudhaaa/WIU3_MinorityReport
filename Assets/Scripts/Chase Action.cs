using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        Chase(controller);
        FollowPath(controller);
    }

    private void Chase(StateController controller)
    {
        Vector3 destination = controller.chaseTarget.position;
        controller.seeker.StartPath(controller.rb.position, destination, p => OnPathComplete(p, controller));



    }

    void OnPathComplete(Path p, StateController controller)
    {
        if (!p.error)
        {
            controller.path = p;
        }
    }

    void FollowPath(StateController controller)
    {
        if (controller.path == null) return;

        int waypointIndex = 0;
        float distanceToWaypoint = float.PositiveInfinity;

        while (true)
        {
            if (waypointIndex >= controller.path.vectorPath.Count)
            {
                break;
            }

            Vector3 waypointPosition = controller.path.vectorPath[waypointIndex];
            distanceToWaypoint = Vector3.Distance(controller.transform.position, waypointPosition);

            if (distanceToWaypoint < 0.1f)
            {
                waypointIndex++;
                continue;
            }

            Vector3 directionToWaypoint = (waypointPosition - controller.transform.position).normalized;
            controller.characterRenderer.SetDirection(directionToWaypoint.x, directionToWaypoint.y);
            Vector2 force = directionToWaypoint * controller.moveSpeed * Time.deltaTime;
            controller.rb.AddForce(force);

            break;
        }
    }
}
