using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterComponents
{
    [SerializeField] private float walkSpeed = 5f;

    
    public float MoveSpeed { get; set; }

    
    private readonly int movingParamater = Animator.StringToHash("Moving");

    protected override void Start()
    {
        base.Start();
        MoveSpeed = walkSpeed;
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
        UpdateAnimations();
    }

    
    private void MoveCharacter()
    {
        Vector2 movement = new Vector2(x: horizontalInput, y: verticalInput);
        Vector2 movementNormalized = movement.normalized;
        Vector2 movementSpeed = movementNormalized * MoveSpeed;
        controller.SetMovement(movementSpeed);
    }

    
    private void UpdateAnimations()
    {
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            animator.SetBool(movingParamater, value: true);
        }
        else
        {
            animator.SetBool(movingParamater, value: false);
        }
    }

    
    public void ResetSpeed()
    {
        MoveSpeed = walkSpeed;
    }
}
