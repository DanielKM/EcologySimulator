using UnityEngine;

[CreateAssetMenu(fileName = "Organism", menuName = "ScriptableObjects/Organism/Organism", order = 1)]
public class Organism : ScriptableObject
{
    [Header("Information")]
    [SerializeField] string organismName = "";
    [SerializeField] public GameObject prefab = null;

    [Header("Biological Information")]
    [SerializeField] public Types.TrophicLevel trophicLevel = Types.TrophicLevel.PrimaryProducer;
    [SerializeField] Types.Kingdom kingdom = Types.Kingdom.Animal;
    [SerializeField] Types.Class phylum = Types.Class.None;
    [SerializeField] Types.ResourceStatus resourceStatus = Types.ResourceStatus.None;
    [SerializeField] Types.Movement[] movement;
    [SerializeField] Types.Sex[] sexes;

    /// DAILY CALORIC REQUIREMENT
    // CALORIES GIVEN ON DEATH
    
    // Temperature range
    // Sunlight needs

    [Header("Health Requirements")]
    [SerializeField, Tooltip("Put needs in order of how important they are.")] Need[] needs;
    [SerializeField, Tooltip("Make sure these stages are in order.")] GrowthStage[] growthStages;    

    [Header("Health Traits")]
    [SerializeField, Tooltip("Base Hit Points (Human is 100)"), Min(1)] private int hitPoints = 100;
    [SerializeField, Tooltip("Base Toughness (Human is 100)"), Min(1)] private int toughness = 100;
    [SerializeField, Tooltip("Base Strength (Human is 100)"), Min(1)] private int strength = 100;
    [SerializeField, Tooltip("Base Speed (Human is 100)"), Min(0)] private int speed = 100; // find actual unit speed
    [SerializeField, Tooltip("Growth Speed (Human is 100)"), Min(0)] private int growthSpeed = 100;
    [SerializeField, Tooltip("Speed that the Organism Decays (Human is 100)"), Min(0)] private int decaySpeed = 0;
    [SerializeField, Tooltip("Max Life Span (Years, Human is 100)"), Min(0)] private float lifeSpan = 100;
    [SerializeField, Tooltip("Age of Sexual Maturity (Years, Human is 15)"), Min(0)] private int sexualMaturity = 15;   
    [SerializeField, Tooltip("Gestation Period (Days, Human is 280)"), Min(0)] private int gestationPeriod = 280;    
    [SerializeField, Tooltip("Average Offspring Amount (Human is 1, Can't go below 1)"), Min(1)] private int offspringAmount = 1;    
    [SerializeField, Tooltip("Offspring Variability (Human is 3)"), Min(0)] private int offspringVariability = 3;    

    [Header("Behavioural Information")]
    [SerializeField] Types.Range range = Types.Range.Stationary;
    [SerializeField] int wanderDistance = 50;

    [Header("Preferences")]
    [SerializeField, Tooltip("Make sure these are in order of preference.")] Biome[] preferredBiomes;
    [SerializeField, Tooltip("Make sure these are in order of preference.")] Types.Class[] preferredFoodTypes;
    [SerializeField, Tooltip("Make sure these are in order of preference.")] Organism[] preferredFood;
    [SerializeField, Tooltip("Make sure these are in order of preference.")] GrowthStage[] preferredFoodGrowthStage;
    [SerializeField, Tooltip("")] bool canEatOutsideOfPreferredGrowthStage;
    [SerializeField, Tooltip("Make sure these are in order of preference.")] Organism[] beneficialOrganisms;
    [SerializeField, Tooltip("Make sure these are in order of preference.")] Organism[] enemyOrganisms;

    // how to respond to friendly/enemy organisms run/attack/approach
    // run/

    [Header("Personality Traits")]
    [SerializeField] private int sociability = 50;
    [SerializeField] private int boldness = 50;
    [SerializeField] private int selfishness = 50;
    [SerializeField] private int adaptability = 50;
    [SerializeField] private int integrity = 50;
    [SerializeField] private int willpower = 50;
    [SerializeField] private int intelligence = 50;
    
    public bool AreAllNeedsMet ()
    {
        bool needsMet = true;
        foreach (Need need in needs)
        {
            if (!need.IsMet()) 
            {
                needsMet = false;
            }
        }
        return needsMet;
    }
}