using UnityEngine;

public class MouseLook : MonoBehaviour
{
    InputSystem_Actions inputActions;
    Vector2 mouseInput;
    Camera mainCamera;
    public float mouseXSensitivity;
    public GameObject lookCenter;

    void Start()
    {
        inputActions = GetComponent<MovementInput>().inputActions;
        inputActions.Player.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
        mainCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, mainCamera.gameObject.transform.eulerAngles.y - transform.eulerAngles.y); //rotate by the difference between camera and player rotation - i.e. rotate to face camera
    }
}
