using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] woodTreePrefab;

    [SerializeField]
    private Transform woodTreeParent;

    [SerializeField] private Transform appleTreeParent;

    [SerializeField] private Transform stoneParent;
    [SerializeField] private Transform goldParent;

    [SerializeField]
    private ResourceSource[] resources;
    public ResourceSource[] Resources { get { return resources; } }

    public static ResourceManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindAllResource();
    }

    private void FindAllResource()
    {
        resources = FindObjectsOfType<ResourceSource>();
    }

}
