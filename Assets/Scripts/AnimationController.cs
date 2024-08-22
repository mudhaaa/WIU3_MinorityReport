using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private RuntimeAnimatorController ManController;
    [SerializeField] private RuntimeAnimatorController WomanController;
    private static readonly string[] walkanimations = { "Walk North", "Walk North West", "Walk West", "Walk South West", "Walk South", "Walk South East", "Walk East", "Walk North East" };
    private static readonly string[] attackanimations = { "Attack North", "Attack North West", "Attack West", "Attack South West", "Attack South", "Attack South East", "Attack East", "Attack North East" };
    private static readonly string[] sprintanimations = { "Sprint North", "Sprint North West", "Sprint West", "Sprint South West", "Sprint South", "Sprint South East", "Sprint East", "Sprint North East" };
    private static readonly string[] idleanimations = { "Idle North", "Idle North West", "Idle West", "Idle South West", "Idle South", "Idle South East", "Idle East", "Idle North East" };
    private static readonly string[] deathanimations = { "Death North", "Death North West", "Death West", "Death South West", "Death South", "Death South East", "Death East", "Death North East" };

    private void Start()
    {
        if (GameManager.isMale == true)
        {
            animator.runtimeAnimatorController = ManController;
        }
        else
        {
            animator.runtimeAnimatorController = WomanController;
        }
    }

    // Find index based direction
    private int DirectionToIndex(Vector2 direction)
    {
        // Get the normalized direction
        Vector2 normDir = direction.normalized;

        // Get angle formed by direction
        float angle = Vector2.SignedAngle(Vector2.up, normDir);

        if (angle < 0) angle += 360; // Make the angle positive

        // Get index based on the angle
        return Mathf.FloorToInt(angle / 45.0f);

    }

    // Set the animation
    public string PlayAnimation(Vector2 direction, string Animation)
    {
        if (direction.magnitude < 0.01f)
        {
            animator.Play("", -1, 0f);  // Stop and reset animation
        }
        else
        {
            int index = DirectionToIndex(direction);
            if (index < 0) Debug.Log(index);

            if (Animation == "Walk")
            {
                animator.Play(walkanimations[index]);
                return walkanimations[index];
            }
            else if (Animation == "Attack")
            {
                animator.Play(attackanimations[index]);
                return attackanimations[index];
            }
            else if (Animation == "Sprint")
            {
                animator.Play(sprintanimations[index]);
                return sprintanimations[index];
            }
            else if (Animation == "Idle")
            {
                animator.Play(idleanimations[index]);
                return idleanimations[index];
            }
            else if (Animation == "Death")
            {
                animator.Play(deathanimations[index]);
                return deathanimations[index];
            }
        }
        return null;
    }
}
