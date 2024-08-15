using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/Chase")]
public class ChaseDecision : Decision
{
    [SerializeField] float maxLookDistance = 10f; // adjust this value to your liking
    // Start is called before the first frame update
    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        float distanceToTarget = Vector2.Distance(controller.eyes.position, controller.chaseTarget.position);
        if (distanceToTarget > maxLookDistance) return false; // if too far away, don't bother checking

        Vector2 direction = (Vector2)controller.chaseTarget.position - (Vector2)controller.eyes.position;

        Debug.DrawRay(controller.eyes.position, direction, Color.green);
        LayerMask layerMask = LayerMask.GetMask("Player"); // Replace "Player" with the name of the layer your player is on
        RaycastHit2D hit = Physics2D.Linecast(controller.eyes.position, controller.chaseTarget.position, layerMask);
 


        if (hit.collider != null && !controller.playerstatus.Died && !controller.playerstatus.Hide)
        {
         
            return true;
        }
        else
        {
            return false;
        }
    }
}
