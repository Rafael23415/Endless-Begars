using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI coinText;

    [Header("Resources")]
    [SerializeField] private int wood;
    [SerializeField] private int stone;
    [SerializeField] private int coin;
    [SerializeField] private int planks;
    [SerializeField] private int bricks;

    private int resourceMultiplier;
    

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void GetResources(string type, int amount)
    {
        if (type == "Wood")
        {
            wood += amount * resourceMultiplier;
        }
        if (type == "Stone")
        {
            stone += amount * resourceMultiplier;
        }
        if (type == "Coin")
        {
            coin += amount * resourceMultiplier;
        }
        if(type == "Planks")
        {
            planks += amount;
        }
        if(type == "Bricks")
        {
            bricks += amount;
        }

        UpdateUI();
    }

    public void ChangeMultiplier(int multiplier)
    {
        resourceMultiplier = multiplier;
    }

    private void UpdateUI()
    {
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        coinText.text = coin.ToString();
    }

    public bool CheckResourcesAmount(string type, int necessaryAmount)
    {
        if (type == "Wood" && wood >= necessaryAmount)
        {
            wood -= necessaryAmount;
            UpdateUI();
            return true;
        }
        else
        {
            if (type == "Stone" && stone >= necessaryAmount)
            {
                stone -= necessaryAmount;
                UpdateUI();
                return true;
            }
            else
            {
                if (type == "Coin" && coin >= necessaryAmount)
                {
                    coin -= necessaryAmount;
                    UpdateUI();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
    }
}
