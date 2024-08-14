using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        Vector3 direction = (controller.chaseTarget.position - controller.transform.position).normalized;

        // Set character animation direction
        controller.characterRenderer.SetDirection(direction.x, direction.y);

        // Move the StateController using the MovementController
        controller.movementController.MovePosition(new Vector2(direction.x, direction.y));
    }
}
