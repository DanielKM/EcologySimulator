using UnityEngine;

public class Environment : MonoBehaviour
{
    [Header("References")]
    [SerializeField, Tooltip("Sun GameObject")] GameObject sun = null;   
    [SerializeField, Tooltip("Terrain GameObject")] GameObject terrain = null;   
    [SerializeField, Tooltip("Global Environment Scriptable Object to Use")] public GlobalEnvironment globalEnvironment;   
    [SerializeField, Tooltip("Current Biomes")] Biome[] biomes;    
    
    [Header("Global Environment")]
    public int currentGlobalTemperature = 0;
    public int averageGlobalTemperature = 0;

    [System.Serializable]
    public class ListedBiome
    {
        public string biomeName;
        public int temperature;
        [SerializeField, Tooltip("All the plants within this local environment.")] public Organism[] plants;
        [SerializeField, Tooltip("All the animals within this local environment.")] public Organism[] animals;

        [Header("Trophic Level Breakdown")]
        [SerializeField, Tooltip("All the organisms within this local environment that are primary producers.")] public Organism[] primaryProducers;
        [SerializeField, Tooltip("All the organisms within this local environment that are primary consumers.")] public Organism[] primaryConsumers;
        [SerializeField, Tooltip("All the organisms within this local environment that are seconadry consumers.")] public Organism[] secondaryConsumers;
        [SerializeField, Tooltip("All the organisms within this local environment that are apex predators.")] public Organism[] apexPredators;
        // ADD HERE TO POPULATE CONTAINED BIOMES
    }

    public ListedBiome[] containedBiomes = new ListedBiome[] {};
    
    public void UpdateEnvironments()
    {
        UpdateGlobalEnvironment();
        UpdateBiomes();
        SpawnOrganisms();
    }

    private void UpdateGlobalEnvironment()
    {        
        currentGlobalTemperature = globalEnvironment.averageTemperature;
    }

    private void UpdateBiomes()
    {
        biomes = globalEnvironment.biomes;

        ListedBiome[] listedBiomes = new ListedBiome[biomes.Length];

        for(int i=0; i<biomes.Length; i++)
        {
            ListedBiome newBiome = new ListedBiome();
            newBiome.biomeName = biomes[i].biomeName;
            newBiome.temperature = globalEnvironment.averageTemperature + biomes[i].temperatureModifier;
            newBiome.plants = biomes[i].plants;
            newBiome.animals = biomes[i].animals;

            newBiome.primaryProducers = biomes[i].primaryProducers;
            newBiome.primaryConsumers = biomes[i].primaryConsumers;
            newBiome.secondaryConsumers = biomes[i].secondaryConsumers;
            newBiome.apexPredators = biomes[i].apexPredators;

            listedBiomes[i] = newBiome;
        }
        containedBiomes = listedBiomes;
    }
    
    private void SpawnOrganisms()
    {
        foreach(Biome biome in biomes)
        {
            biome.SpawnAllOrganisms(terrain);
        }
    }
}
