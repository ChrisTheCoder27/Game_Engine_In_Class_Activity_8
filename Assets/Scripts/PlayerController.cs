using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    [SerializeField] float moveSpeed = 5f;
    Vector2 moveDirection = Vector2.zero;

    [SerializeField] InputActionAsset inputs;
    InputAction move;

    void OnEnable()
    {
        inputs.FindActionMap("Player").Enable();
    }

    void OnDisable()
    {
        inputs.FindActionMap("Player").Disable();
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveDirection.x, 0, moveDirection.y);

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}
