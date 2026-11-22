using System.Collections;
using UnityEngine;

public class GatheringBuilding : MonoBehaviour
{
    private AudioSource myAudioSource;
    private GatheringBuildingUI buildingUI;

    [Header("References")]
    [SerializeField] private ResourceAglomerous resourceAglomerous;    

    [Header("Level")]
    [SerializeField] private int maxLevel = 5;
    private int level;
    private int woodNeeded;
    private int stoneNeeded;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        buildingUI = GetComponentInChildren<GatheringBuildingUI>();
        
        CalculateResources(level);
    }

    private void Start()
    {
        SoundManager.Instance.AddAudioSource(myAudioSource);

        buildingUI.UpdateUI(level, woodNeeded, stoneNeeded, level == maxLevel, tag);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interaction"))
        {
            LevelUpBuilding();
        }
    }

    private void LevelUpBuilding()
    {
        CalculateResources(level);

        if (level < maxLevel && ResourceManager.Instance.CheckResourcesAmount("Wood", woodNeeded) && 
            ResourceManager.Instance.CheckResourcesAmount("Stone", stoneNeeded))
        {
            level++;
            CalculateResources(level);
            myAudioSource.Play();
            if (CompareTag("Wood"))
            {
                buildingUI.UpdateUI(level, woodNeeded, stoneNeeded, level == maxLevel, tag);
            }
            else
            {
                if(CompareTag("Stone"))
                {
                    buildingUI.UpdateUI(level, woodNeeded, stoneNeeded, level == maxLevel, tag);
                }
            }
            if(level == 1)
            {
                StartCoroutine(GetResources());
            }
        }
    }

    private void CalculateResources(int targetLevel)
    {
        if (CompareTag("Wood"))
        {
            woodNeeded = 15 * (targetLevel + 1);
            if (targetLevel >= 3)
            {
                stoneNeeded = 30 * (targetLevel - 2);
            }
            else
            {
                stoneNeeded = 0;
            }
        }
        else
        {
            if (CompareTag("Stone"))
            {
                stoneNeeded = 15 * (targetLevel + 1);
                if (targetLevel >= 3)
                {
                    woodNeeded = 30 * (targetLevel - 2);
                }
                else
                {
                    woodNeeded = 0;
                }
            }
        }
    }

    private IEnumerator GetResources()
    {
        while (true)
        {
            resourceAglomerous.MineResource(tag);
            yield return new WaitForSeconds(5 / level);
        }
    }
}
