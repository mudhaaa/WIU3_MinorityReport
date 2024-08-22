using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
    private static readonly string[] manAnimations =
    { "Men_Move North", "Men_Move North West",
      "Men_Move West", "Men_Move South East", "Men_Move South",
      "Men_Move South West", "Men_Move East", "Men_Move North East" };

    private static readonly string[] manIdleAnimations =
    {
        "Men_Idle North", "Men_Idle North West", "Men_Idle West",
        "Men_Idle South West", "Men_Idle South", "Men_Idle South East",
        "Men Idle East", "Men_Idle North East"
    };

    private static readonly string[] womanAnimations =
    {
      "Women_Move North", "Women_Move North West",
      "Women_Move West", "Women_Move South East", "Women_Move South",
      "Women_Move South West", "Women_Move East", "Women_Move North East"
    };

    private static readonly string[] womanIdleAnimations =
    {
        "Women_Idle North", "Women_Idle North West", "Women_Idle West",
        "Women_Idle South West", "Women_Idle South", "Women_Idle South East",
        "Women Idle East", "Women_Idle North East"
    };

    [SerializeField] private Animator animator;

    [SerializeField] private RuntimeAnimatorController MaleController;
    [SerializeField] private RuntimeAnimatorController FemaleController;


    private void OnEnable()
    {
        if (GameManager.isMale == true)
        {
            animator.runtimeAnimatorController = FemaleController;
        }
        else
        {
            animator.runtimeAnimatorController = MaleController;
        }
    }

    // Convert X and Y inputs to direction index        
    private int DirectionToIndex(float x, float y)
    {
        // Calculate angle based on X and Y inputs
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        // Adjust angle to be positive
        if (angle < 0)
            angle += 360;

        // Get index based on the angle
        return Mathf.FloorToInt(angle / 45.0f);
    }

    // Set the animation and return the X and Y inputs
    public Vector2 SetDirection(float x, float y)
    {
        bool isMoving = (x != 0 || y != 0);
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            int index = DirectionToIndex(x, y);
            animator.SetFloat("x", x);
            animator.SetFloat("y", y);
        }

        return new Vector2(x, y);
    }
    void Update()
    {


    }
}
