using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] TextMeshProUGUI fuelText;

    private void OnEnable()
    {
        if (player != null)
        {
            player.OnFuelRefilled += UpdateFuelUI;
        }
    }
    private void OnDisable()
    {
        if (player != null)
        {
            player.OnFuelRefilled -= UpdateFuelUI;
        }
    }
    private void UpdateFuelUI(float maxFuel)
    {
        if (fuelText != null)
        {
            fuelText.text = "Fuel: " + maxFuel;
        }
    }
}
