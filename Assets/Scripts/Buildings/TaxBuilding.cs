using UnityEngine;

public class TaxBuilding : MonoBehaviour
{
    private AudioSource myAudioSource;
    private TaxBuildingUI buildingUI;

    [Header("References")]
    [SerializeField] private EndGame endGame;
    
    [Header("Tax Amount")]
    [SerializeField] private int coinsNeeded;

    private bool finished;
    
    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        buildingUI = GetComponentInChildren<TaxBuildingUI>();
    }

    private void Start()
    {
        SoundManager.Instance.AddAudioSource(myAudioSource);
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interaction"))
        {
            PayTax();
        }
    }

    private void PayTax()
    {
        if (ResourceManager.Instance.CheckResourcesAmount("Coin", coinsNeeded))
        {
            coinsNeeded = 0;
            UpdateUI();
            myAudioSource.Play();

            if (!finished)
            {
                finished = true;
                endGame.StartCoroutine(endGame.PerformEndGame());
            }
        }
    }

    public void ChangeTaxValue(int newValue)
    {
        coinsNeeded = newValue;
        UpdateUI();
    }

    public int ReturnTaxValue()
    {
        return coinsNeeded;
    }

    private void UpdateUI()
    {
        buildingUI.UpdateUI(coinsNeeded);
    }
}
