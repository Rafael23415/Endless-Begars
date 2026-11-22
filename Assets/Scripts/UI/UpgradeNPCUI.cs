using TMPro;
using UnityEngine;

public class UpgradeNPCUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI multiplierText;
    
    public void UpdateUI(int woodNeeded, int stoneNeeded, int coinsNeeded, int level, int maxLevel, int multiplier)
    {
        woodText.text = woodNeeded.ToString() + " Wood";
        stoneText.text = stoneNeeded.ToString() + " Stone";
        coinsText.text = coinsNeeded.ToString() + " Coins";
        levelText.text = "Level: " + level.ToString();
        multiplierText.text = "Multiplier: X" + multiplier.ToString();
    }
}
