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
        Vector2 force = direction * controller.moveSpeed * Time.deltaTime;
        controller.rb.AddForce(force);
        controller.seeker.StartPath(controller.rb.position, controller.chaseTarget.position);
        // Set character animation direction
        controller.characterRenderer.SetDirection(direction.x, direction.y);

    
    }
}
