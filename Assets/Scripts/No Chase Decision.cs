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
        if (targetVisible)
        {
            // If no chase, set the next way point to the nearest one
            SetNearestWayPoint(controller);
        }
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

        if (hit.collider != null && !controller.playerstatus.Died && !controller.playerstatus.Hide)
        {
           
            return false;
        }
        else
        {
            return true;
        }
    }

    private void SetNearestWayPoint(StateController controller)
    {
        float minDistance = float.MaxValue;
        int nearestWayPointIndex = -1;

        for (int i = 0; i < controller.wayPointList.Count; i++)
        {
            float distance = Vector3.Distance(controller.transform.position, controller.wayPointList[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestWayPointIndex = i;
            }
        }

        if (nearestWayPointIndex != -1)
        {
            controller.nextWayPoint = nearestWayPointIndex;
        }
    }
}
