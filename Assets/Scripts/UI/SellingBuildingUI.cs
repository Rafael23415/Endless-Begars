using TMPro;
using UnityEngine;

public class SellingBuildingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodNeededText;
    [SerializeField] private TextMeshProUGUI stoneNeededText;
    [SerializeField] private TextMeshProUGUI coinsAmountText;

    public void UpdateUI(int woodNeeded, int stoneNeeded, int coinsAmount)
    {
        woodNeededText.text = "Sell: " + woodNeeded.ToString() + " Wood";
        stoneNeededText.text = "Sell: " + stoneNeeded.ToString() + " Stone";
        coinsAmountText.text = "Get: " + coinsAmount.ToString() + " Coins";
    }
}
