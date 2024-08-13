using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/NoChase")]
public class NoChaseDecision : Decision
{
    [SerializeField] float maxLookDistance = 10f; // adjust this value to your liking
    public override bool Decide(StateController controller)
    {
        bool targetVisible = NoLook(controller);
        return targetVisible;
    }

    private bool NoLook(StateController controller)
    {
        float distanceToTarget = Vector2.Distance(controller.eyes.position, controller.chaseTarget.position);
        if (distanceToTarget > maxLookDistance) return true; // if too far away, consider it "no look"

        Vector2 direction = (Vector2)controller.chaseTarget.position - (Vector2)controller.eyes.position;

        Debug.DrawRay(controller.eyes.position, direction, Color.green);
        LayerMask layerMask = LayerMask.GetMask("Player"); // Replace "Player" with the name of the layer your player is on
        RaycastHit2D hit = Physics2D.Linecast(controller.eyes.position, controller.chaseTarget.position, layerMask);

        if (hit.collider != null)
        {
           
            return false;
        }
        else
        {
            return true;
        }
    }
}
