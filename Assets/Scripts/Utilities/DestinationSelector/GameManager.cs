using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Target> destinationCounts;
    [SerializeField]
    public TextAsset targetModelData;

    private void Start()
    {
        GenerateTargetItems();
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }

    // Lists all Targets from the Target List JSON FIle
    private void GenerateTargetItems()
    {
        IEnumerable<Target> targets = GenerateTargetDataFromSource();
        

        foreach (Target target in targets)
        {
            if(target.TargetType == 0)
            {
                Debug.Log("Target: " + target.Name);
                destinationCounts.Add(target);
            }
            
        }
        Debug.Log("Number of targets: " + destinationCounts.Count());
    }

    private IEnumerable<Target> GenerateTargetDataFromSource()
    {
        return JsonUtility.FromJson<TargetWrapper>(targetModelData.text).TargetList;
    }
}
