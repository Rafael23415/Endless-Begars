using UnityEngine;

public class UpgradeNPC : MonoBehaviour
{
    private AudioSource myAudioSource;
    private UpgradeNPCUI upgradeNPCUI;

    [Header("References")]
    [SerializeField] private PlayerMovement player;

    [Header("Upgrade Needs")]
    [SerializeField] private int maxLevel;
    private int level = 1;
    private int woodNeeded = 25;
    private int stoneNeeded = 25;
    private int coinsNeeded = 50;
    
    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        upgradeNPCUI = GetComponentInChildren<UpgradeNPCUI>();
    }

    private void Start()
    {
        player.UpgradeAxe(level);
        upgradeNPCUI.UpdateUI(woodNeeded, stoneNeeded, coinsNeeded, level, maxLevel, (int)Mathf.Pow(2, level) / 2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interaction"))
        {
            Upgrade();
        }
    }

    private void Upgrade()
    {
        if (level < maxLevel && ResourceManager.Instance.CheckResourcesAmount("Wood", woodNeeded) && 
            ResourceManager.Instance.CheckResourcesAmount("Stone", stoneNeeded) && 
            ResourceManager.Instance.CheckResourcesAmount("Coin", coinsNeeded))
        {
            myAudioSource.Play();
            level++;
            woodNeeded *= 2;
            stoneNeeded *= 2;
            coinsNeeded += 25;
            player.UpgradeAxe(level);
            upgradeNPCUI.UpdateUI(woodNeeded, stoneNeeded, coinsNeeded, level, maxLevel, (int)Mathf.Pow(2, level) / 2);
        }
    }
}
