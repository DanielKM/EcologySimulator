using UnityEngine;

[CreateAssetMenu(fileName = "Need", menuName = "ScriptableObjects/Organism/Need", order = 2)]
public class Need : ScriptableObject
{
    [Header("Information")]
    [SerializeField] string needName = "";

    public bool IsMet () 
    {
        Debug.Log("Is Met");
        return true;
    }

    // FindBiome(biome)

}