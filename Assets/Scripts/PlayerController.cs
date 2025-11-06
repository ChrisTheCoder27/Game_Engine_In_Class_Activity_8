using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    [SerializeField] float moveSpeed = 5f;
    Vector2 moveDirection = Vector2.zero;

    public delegate void OnFuelRefilledDelegate(float maxFuel);
    public event OnFuelRefilledDelegate OnFuelRefilled;
    float fuel = 50;
    bool isDirty = true;

    [SerializeField] InputActionAsset inputs;
    InputAction move;

    public float Fuel
    {
        get { return fuel; }
        set
        {
            fuel = value;
            SetDirty();
        }
    }

    void SetDirty()
    {
        isDirty = true;
        OnFuelRefilled?.Invoke(fuel);
    }

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

        if (isDirty)
        {
            Debug.Log("Updating internal state by resetting fuel: " + fuel);
            isDirty = false;
        }
    }
}
