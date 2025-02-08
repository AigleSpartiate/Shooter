using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;
    public bool attack;
    public bool locked;
    private InputAction _attackAction;
    private InputAction _escapeAction;
    private InputAction _jumpAction;
    private InputAction _lookAction;

    private InputAction _moveAction;
    private InputAction _sprintAction;

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _sprintAction = InputSystem.actions.FindAction("Sprint");
        _attackAction = InputSystem.actions.FindAction("Attack");
        _escapeAction = InputSystem.actions.FindAction("Escape");
    }

    private void Update()
    {
        MoveInput(_moveAction.ReadValue<Vector2>());
        LookInput(_lookAction.ReadValue<Vector2>());
        JumpInput(_jumpAction.IsPressed());
        SprintInput(_sprintAction.IsPressed());
        AttackInput(_attackAction.IsPressed());
    }

    private void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }

    private void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }

    private void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }

    private void SprintInput(bool newSprintState)
    {
        sprint = newSprintState;
    }

    private void AttackInput(bool newAttackState)
    {
        attack = newAttackState;
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
