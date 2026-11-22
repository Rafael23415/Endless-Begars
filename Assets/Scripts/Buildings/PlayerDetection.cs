using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private Canvas canvas;

    [Header("Player Detection")]
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private Transform detectionPosition;
    [SerializeField]
    private Vector2 detectionZone;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
    }

    private void Update()
    {
        if (Physics2D.OverlapBox(detectionPosition.position, detectionZone, 0f, playerLayer))
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(detectionPosition.position, detectionZone);
    }
}
