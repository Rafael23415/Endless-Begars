using TMPro;
using UnityEngine;

public class TaxBuildingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsNeededText;
    
    public void UpdateUI(int coinsNeeded)
    {
        coinsNeededText.text = "Pay Taxes: " + coinsNeeded.ToString() + " Coins";
    }
}
