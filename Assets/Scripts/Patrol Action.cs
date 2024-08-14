using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        Vector3 destination = controller.wayPointList[controller.nextWayPoint].position;
        Vector3 direction = (destination - controller.transform.position).normalized;

        float horizontal = direction.x;
        float vertical = direction.y;

        // Set the character animation direction
        controller.characterRenderer.SetDirection(horizontal, vertical);

        // Move the StateController using the MovementController
        controller.movementController.MovePosition(new Vector2(horizontal, vertical));

        float distance = Vector3.Distance(destination, controller.transform.position);
        if (distance < 0.5f)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }
}
