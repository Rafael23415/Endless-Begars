using TMPro;
using UnityEngine;

public class GatheringBuildingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI woodNeededText;
    [SerializeField] private TextMeshProUGUI stoneNeededText;
    [SerializeField] private TextMeshProUGUI resourcePerSecondText;

    public void UpdateUI(int level, int woodNeeded, int stoneNeeded, bool isMaxLevel, string type)
    {
        levelText.text = "Level: " + level;
        if(!isMaxLevel)
        {
            woodNeededText.text = "Wood: " + woodNeeded;
            stoneNeededText.text = "Stone: " + stoneNeeded;
            if (type == "Wood" && level < 3)
            {
                stoneNeededText.enabled = false;
            }
            else
            {
                stoneNeededText.enabled = true;
            }

            if (type == "Stone" && level < 3)
            {
                woodNeededText.enabled = false;
            }
            else
            {
                woodNeededText.enabled = true;
            }


        }
        else
        {
            woodNeededText.text = "Max";
            stoneNeededText.text = "Max";
        }

        float resourcePerSecond = (1 / (5f / level));
        resourcePerSecondText.text = "Resources: " + resourcePerSecond + "/s";
    }
}
