using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargetCircles : MonoBehaviour
{
    [SerializeField] StickFindTargetCircle stickscript;
    public GameObject TargetCirclePrefab;
    // Start is called before the first frame update
    void OnEnable()
    {
        Vector3 pos = transform.position + new Vector3(transform.localScale.x / 2.1f, 0, 0);
        Vector2 rotatedpos = RotatePoint(pos, transform.position, Random.Range(0.0f, 360.0f));
        Instantiate(TargetCirclePrefab, rotatedpos, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (stickscript.Hit)
        {
            Vector3 pos = transform.position + new Vector3(transform.localScale.x / 2.1f, 0, 0);
            Vector2 rotatedpos = RotatePoint(pos, transform.position, Random.Range(0.0f, 360.0f));
            Instantiate(TargetCirclePrefab, rotatedpos, Quaternion.identity, transform);
        }
    }

    Vector2 RotatePoint(Vector2 point, Vector2 pivot, float angleDegrees)
    {
        float angleRadians = angleDegrees * Mathf.Deg2Rad; // Convert angle to radians
        float cosTheta = Mathf.Cos(angleRadians);
        float sinTheta = Mathf.Sin(angleRadians);

        Vector2 direction = point - pivot; // Vector from pivot to point
        Vector2 rotatedDirection = new Vector2(
            cosTheta * direction.x - sinTheta * direction.y,
            sinTheta * direction.x + cosTheta * direction.y
        );

        return pivot + rotatedDirection; // The new rotated position
    }
    void OnDisable()
    {
        DeleteAllChildren();
    }
    public void DeleteAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
