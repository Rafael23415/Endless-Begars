using Cinemachine;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerMovement playerController;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private TaxBuilding taxBuilding;

    [Header("UI References")]
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI creditsText;
    [SerializeField] private Image creditsBackgroundImage;

    [Header("Values")]
    [SerializeField] private int newTaxValue;
    [SerializeField] private string[] phrases;
    [SerializeField] private string[] phrasesAlternativeEnd;
    [SerializeField] private int phraseIndexChangeCamera;
    [SerializeField] private int phraseIndexCredits;
    [SerializeField] private int phraseIndexAlternativeEnd;
    [SerializeField] private int phraseIndexInteract;
    [SerializeField] private float textTime;

    private bool canAlternativeEnd;

    private void Start()
    {
        endGameUI.SetActive(false);
        creditsBackgroundImage.enabled = false;
        creditsText.enabled = false;
    }

    public IEnumerator PerformEndGame()
    {
        playerController.DisablePlayerController();
        endGameUI.SetActive(true);
        if(ResourceManager.Instance.CheckResourcesAmount("Coin", newTaxValue + taxBuilding.ReturnTaxValue()))
        {
            canAlternativeEnd = true;
        }

        for (int i = 0; i < phrases.Length; i++)
        {
            if (i == phraseIndexChangeCamera)
            {
                virtualCamera.m_Lens.OrthographicSize = 5;
                CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                virtualCamera.Follow = taxBuilding.transform;
                taxBuilding.ChangeTaxValue(newTaxValue);
                noise.m_AmplitudeGain = 2;
                noise.m_FrequencyGain = 2;
                yield return new WaitForSeconds(0.25f);
                noise.m_AmplitudeGain = 0;
                noise.m_FrequencyGain = 0;
            }

            if (canAlternativeEnd && i >= phraseIndexAlternativeEnd)
            {
                if (i < phraseIndexCredits)
                {
                    dialogueText.text = phrasesAlternativeEnd[i - phraseIndexAlternativeEnd];
                    if(i == phraseIndexInteract)
                    {
                        playerInteract.Interact();
                    }
                }
                else
                {
                    EnableCredits();
                    creditsText.text = phrasesAlternativeEnd[i - phraseIndexAlternativeEnd];
                }
            }
            else
            {
                if (i < phraseIndexCredits)
                {
                    dialogueText.text = phrases[i];
                }
                else
                {
                    EnableCredits();
                    creditsText.text = phrases[i];
                }
            }

            yield return new WaitForSeconds(textTime);
        }
        Application.Quit();
    }

    private void EnableCredits()
    {
        creditsBackgroundImage.enabled = true;
        creditsBackgroundImage.color = new Color(creditsBackgroundImage.color.r, creditsBackgroundImage.color.g, creditsBackgroundImage.color.b, 1);
        if (!creditsText.enabled)
        {
            creditsText.enabled = true;
        }
    }
}
