using UnityEngine;

[CreateAssetMenu(fileName = "GrowthStage", menuName = "ScriptableObjects/Organism/GrowthStage", order = 3)]
public class GrowthStage : ScriptableObject
{
    [Header("Information")]
    [SerializeField] string growthStageName = "";
}