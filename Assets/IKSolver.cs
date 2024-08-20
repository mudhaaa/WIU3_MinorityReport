using UnityEngine;

public class IKSolver2D : MonoBehaviour
{
    [SerializeField] private Transform _pivot, _upper, _lower, _effector, _tip;
    public Vector2 Target;
    private float _upperLength, _lowerLength, _effectorLength;
    public bool Grounded = false;
    public bool followmouse = false;

    private void Start()
    {
        _effectorLength = (_tip.position - _effector.position).magnitude;
        _upperLength = (_lower.position - _upper.position).magnitude;
        _lowerLength = (_effector.position - _lower.position).magnitude;
    }

    private void Update()
    {
        if (followmouse)
        {
            if (!Input.GetMouseButton(0))
            {
                Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }


        // Calculate the direction to the target from the pivot
        Vector2 directionToTarget = (Target - (Vector2)_pivot.position).normalized;

        // Calculate the angle in degrees from the pivot to the target
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        // Apply the rotation around the Z-axis (which corresponds to 2D rotation in the XY plane)
        _pivot.rotation = Quaternion.Euler(0, 0, angle);

        // Calculate distances and lengths
        var a = _upperLength;
        var b = _lowerLength;
        var maxReach = a + b; // Maximum reach of the arm
        var distanceToTarget = (Target - (Vector2)_pivot.position).magnitude;

        // Ensure the target is reachable by clamping the distance to the max reach of the arm
        distanceToTarget = Mathf.Clamp(distanceToTarget, Mathf.Abs(a - b), maxReach);

        // Adjust the tempTarget position to avoid overlapping with the target
        Vector2 tempTarget = (Vector2)_pivot.position + directionToTarget * distanceToTarget;

        // Calculate the new distance from the upper arm to the target
        var c = (tempTarget - (Vector2)_upper.position).magnitude;

        // Calculate angles using the Law of Cosines
        var alpha = Mathf.Acos((a * a + c * c - b * b) / (2 * a * c)) * Mathf.Rad2Deg;
        var gamma = Mathf.Acos((a * a + b * b - c * c) / (2 * a * b)) * Mathf.Rad2Deg;

        if (!float.IsNaN(alpha) && !float.IsNaN(gamma))
        {
            var beta = 180 - gamma;

            // Rotate the upper arm and lower arm correctly to point at the target
            _upper.localRotation = Quaternion.AngleAxis(alpha, Vector3.forward); // Rotate around Z-axis (into the screen)
            _lower.localRotation = Quaternion.AngleAxis(-beta, Vector3.forward); // Rotate around Z-axis (into the screen)
        }

        // Correct effector's rotation to point directly at the target
        Vector2 effectorDirection = (Target - (Vector2)_effector.position).normalized;
        float effectorAngle = Mathf.Atan2(effectorDirection.y, effectorDirection.x) * Mathf.Rad2Deg;
        _effector.rotation = Quaternion.Euler(0, 0, effectorAngle);

        // Grounded check using raycast
        RaycastHit2D hitInfo = Physics2D.Raycast(_tip.position, Vector2.down, _tip.localScale.y, LayerMask.GetMask("Ground"));
        Grounded = hitInfo.collider != null;
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(Target.x, Target.y, 0), 0.1f);
    }
}
