using UnityEngine;

public class ResourceAglomerous : MonoBehaviour
{
    private Resource[] resourceSources;

    private void Start()
    {
        resourceSources = GetComponentsInChildren<Resource>();
    }

    public void MineResource(string type)
    {
        for (int i = 0; i < resourceSources.Length; i++)
        {
            Resource resource = resourceSources[i];
            if (resource.tag == type && resource.CanBeMined())
            {
                resource.MineResource();
                return;
            }
        }
    }
}
