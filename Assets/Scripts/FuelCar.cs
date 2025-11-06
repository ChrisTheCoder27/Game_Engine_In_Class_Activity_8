using UnityEngine;

public class FuelCar : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.Fuel = 100f;
        }
    }
}
