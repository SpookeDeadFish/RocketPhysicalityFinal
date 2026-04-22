using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float speed;
    Vector2 horizontalMovement;

    [SerializeField] float gravity = -20.0f;
    Vector3 verticalVelocity; //characterController.Move() takes a Vector3, but we're only using the vertical component

    bool isGrounded = false;
    public LayerMask groundLayer;

    bool isJumping = false;
    [SerializeField] float jumpHeight = 3.5f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void ReceiveInput(Vector2 _horizontalMovement)
    {
        horizontalMovement = _horizontalMovement;
    }

    void Update()
    {
        Vector3 movementVelocity = (transform.right * horizontalMovement.x + transform.forward * horizontalMovement.y) * speed;
        characterController.Move(movementVelocity * Time.deltaTime);

        verticalVelocity.y += gravity * Time.deltaTime;
        checkGround(); //reset vertical velocity to 0 if grounded
        if (isJumping)
        {
            Jump();
            isJumping = false;
        }
        characterController.Move(verticalVelocity * Time.deltaTime);
        Debug.Log(verticalVelocity);
    }

    void checkGround()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0f, 1f, 0f), 0.52f, groundLayer);
        if (isGrounded)
        {
            verticalVelocity.y = 0;
        }
    }

    public void shouldJump()
    {
        Debug.Log("jumping");
        isJumping = true;
    }

    void Jump()
    {
        if (isGrounded)
        {
            verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
        }
    }
}
