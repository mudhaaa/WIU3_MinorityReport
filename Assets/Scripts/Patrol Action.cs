using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Add this namespace for NavMeshAgent
using Pathfinding;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }


    void OnPathComplete(Path p, StateController controller)
    {
        if (!p.error)
        {
            controller.path = p;
        }
    }
    private void Patrol(StateController controller)
    {
      
        Vector3 destination = controller.wayPointList[controller.nextWayPoint].position;
        Vector3 direction = (destination - controller.transform.position).normalized;

        float horizontal = direction.x;
        float vertical = direction.y;

        // Set the character animation direction
        controller.characterRenderer.SetDirection(horizontal, vertical);
        Vector2 force = direction * controller.moveSpeed * Time.deltaTime;
        controller.rb.AddForce(force);
        // Move the StateController using the MovementController
       

        float distance = Vector3.Distance(destination, controller.transform.position);
        controller.seeker.StartPath(controller.rb.position, destination);
        if (distance < 1.1f)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }

}
