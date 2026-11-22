using System.Collections;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private AudioSource myAudioSource;

    [Header("Stats")]
    [SerializeField] private int initialHp = 5;
    private int hp;
    [SerializeField] private int resourceAmount = 1;
    [SerializeField] private int timeToRegrow = 25;

    [Header("Sprites")]
    [SerializeField]
    private Sprite grownedSprite;
    [SerializeField]
    private Sprite minedSprite;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        myAudioSource = GetComponent<AudioSource>();

        hp = initialHp;
    }

    private void Start()
    {
        SoundManager.Instance.AddAudioSource(myAudioSource);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Interaction") && CanBeMined())
        {
            myAudioSource.Play();
            MineResource();
        }
    }

    public void MineResource()
    {
        hp--;
        myAnimator.SetTrigger("Hit");
        ResourceManager.Instance.GetResources(tag, resourceAmount);

        if (hp <= 0)
        {
            mySpriteRenderer.sprite = minedSprite;
            
            StartCoroutine(RegrowResource());
        }
    }

    private IEnumerator RegrowResource()
    {
        yield return new WaitForSeconds(timeToRegrow);
        mySpriteRenderer.sprite = grownedSprite;
        hp = initialHp;
    }

    public bool CanBeMined()
    {
        if(hp > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
