using UnityEngine;

public class ResourceProcessing : MonoBehaviour
{
    [SerializeField] private int resourcesNeeded = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interaction"))
        {
            ProcessWood();
        }
    }
    
    private void ProcessWood()
    {
        ResourceManager.Instance.CheckResourcesAmount(tag, resourcesNeeded);
        ResourceManager.Instance.GetResources("Planks", resourcesNeeded);
    }
}
