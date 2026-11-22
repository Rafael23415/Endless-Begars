using UnityEngine;

public class SellingBuilding : MonoBehaviour
{
    private AudioSource myAudioSource;
    private SellingBuildingUI buildingUI;

    [Header("Resources To Sell")]
    [SerializeField] private int woodNeeded;
    [SerializeField] private int stoneNeeded;
    [SerializeField] private int coinsAmount;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        buildingUI = GetComponentInChildren<SellingBuildingUI>();
    }

    private void Start()
    {
        SoundManager.Instance.AddAudioSource(myAudioSource);
        buildingUI.UpdateUI(woodNeeded, stoneNeeded, coinsAmount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interaction"))
        {
            SellStuff();
        }
    }

    private void SellStuff()
    {
        if (ResourceManager.Instance.CheckResourcesAmount("Wood", woodNeeded) && ResourceManager.Instance.CheckResourcesAmount("Stone", stoneNeeded))
        {
            ResourceManager.Instance.GetResources("Coin", coinsAmount);
            myAudioSource.Play();
        }
    }
}
