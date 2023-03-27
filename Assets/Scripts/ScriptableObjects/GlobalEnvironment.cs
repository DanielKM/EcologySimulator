using UnityEngine;

[CreateAssetMenu(fileName = "GlobalEnvironment", menuName = "ScriptableObjects/Environment/Global", order = 1)]
public class GlobalEnvironment : ScriptableObject
{
    [Header("Information")]
    [SerializeField] string globalEnvironmentName = "";

    [SerializeField, Tooltip("All the biomes within this global environment.")] public Biome[] biomes;

    [SerializeField, Tooltip("Average Temperature of the Biome (Degrees Celsius).")] public int averageTemperature = 20;

    // sun
    // season
    // day/night cycle
    // cloud cover
    // ecosystem age
    // moisture modifier/range
    // rainfall modifier/range
    
    // current ecosystem health
}