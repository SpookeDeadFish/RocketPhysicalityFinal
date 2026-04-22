using UnityEngine;

public class MovementInput : MonoBehaviour
{
    public InputSystem_Actions inputActions;
    Vector2 horizontalInput;
    PlayerMovement playerMovement;

    void Awake()
    {
        inputActions = new InputSystem_Actions();

        inputActions.Player.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        playerMovement = GetComponent<PlayerMovement>();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    void Update()
    {
        playerMovement.ReceiveInput(horizontalInput);
        if (inputActions.Player.Jump.triggered)
        {
            playerMovement.shouldJump();
        }
    }
}
