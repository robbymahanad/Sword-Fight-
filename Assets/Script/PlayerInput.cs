using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private Vector2 moveDir;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Player player;
    [SerializeField] private EventAnim animatorEvent;

    private void FixedUpdate()
    {
        SetMoveDir();
        playerMovement.PlayerMove(moveDir);
        Debug.Log(moveDir);
    }
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
        jumpAction.performed += JumpAction_performed;
        attackAction.performed += AttackAction_performed;
    }

    private void AttackAction_performed(InputAction.CallbackContext obj)
    {
        player.AttackAnim();
        moveDir = Vector2.zero;
    }

    private void JumpAction_performed(InputAction.CallbackContext obj)
    {
        playerMovement.PlayerJump();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
    }
    private void SetMoveDir()
    {
        if (!animatorEvent.isBusy)
        {
            moveDir = moveAction.ReadValue<Vector2>();
        }
        else if (animatorEvent.isBusy)
        {
            moveDir = Vector2.zero;
        }
    }
}
