using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Biome", menuName = "ScriptableObjects/Environment/Biome", order = 2)]
public class Biome : ScriptableObject
{
    [Header("Information")]
    [SerializeField] public string biomeName = "";
    
    [SerializeField, Tooltip("All the plants within this local environment.")] public Organism[] plants;
    [SerializeField, Tooltip("All the animals within this local environment.")] public Organism[] animals;

    [SerializeField, Tooltip("Have organisms been spawned?")] private bool organismsSpawned = false;
    
    [SerializeField, Tooltip("Temperature Modifier of the Biome (Degrees Celsius, Default is 20).")] public int temperatureModifier = 0;
    [SerializeField, Tooltip("Determines how mature the ecosystem is.")] private Types.EcosystemAge ecosystemAge = Types.EcosystemAge.Mature;
    [SerializeField, Tooltip("Determines amount of predators/prey in the biome.")] private Types.EcosystemBalance ecosystemBalance = Types.EcosystemBalance.Balanced;
    [SerializeField, Tooltip("INACTIVE - Determines whether to start the biome in a balanced state or use the organism breakdown below.")] public bool useEcosystemBalance = true;

    [Header("Organism Breakdown")]
    [SerializeField, Tooltip("All the organisms within this local environment that are primary producers.")] public Organism[] primaryProducers;
    [SerializeField, Tooltip("All the organisms within this local environment that are primary consumers.")] public Organism[] primaryConsumers;
    [SerializeField, Tooltip("All the organisms within this local environment that are seconadry consumers.")] public Organism[] secondaryConsumers;
    [SerializeField, Tooltip("All the organisms within this local environment that are apex predators.")] public Organism[] apexPredators;

    [System.Serializable, Tooltip("Overrides predetermined ecosystem balance.")]
    public class OrganismBreakdown
    {
        public int primaryProducers = 1000;
        public int primaryConsumers = 100;
        public int secondaryConsumers = 10;
        public int apexPredators = 1;
    }

    [SerializeField] OrganismBreakdown organismBreakdown;
     // temperature modifier/range
    // moisture modifier/range
    // rainfall modifier/range

    // current ecosystem health
    public void SpawnAllOrganisms(GameObject terrain)
    {
        if(organismsSpawned) { return; }

        // check predators
        Organism[] allOrganisms = plants.Concat(animals).ToArray();

        SpawnOrganisms(allOrganisms, terrain);

    }

    // depending on ecosystem balance
    // 1000 plants, 100 primary consumer, 10 secondary consumer, 1 tertiary/1 apex


    private void SpawnOrganisms(Organism[] organisms, GameObject terrain)
    {
        Bounds bounds = terrain.GetComponent<Collider>().bounds;

        ArrangeOrganismsByTrophicLevel(organisms);
        SpawnTrophicLevel(primaryProducers, organismBreakdown.primaryProducers, bounds);
        SpawnTrophicLevel(primaryConsumers, organismBreakdown.primaryConsumers, bounds);
        SpawnTrophicLevel(secondaryConsumers, organismBreakdown.secondaryConsumers, bounds);
        SpawnTrophicLevel(apexPredators, organismBreakdown.apexPredators, bounds);
        organismsSpawned = true; // need to reset on closing play mode

        // add to 4 different arrays based on trophic level
        // while spawning randomly select one of the organisms

        // spawn based on the 4 criteria
        // choose a random spawnpoint in the bounds
    }

    private void SpawnTrophicLevel(Organism[] organismArray, int count, Bounds bounds)
    {
        if(organismArray.Length <= 0) { return; }
        for(int i=0; i<count; i++) 
        {
            int randomIndex = UnityEngine.Random.Range(0, organismArray.Length);
            float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
            float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
            float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);

            GameObject newOrganism = GameObject.Instantiate(organismArray[randomIndex].prefab);
            newOrganism.transform.position = bounds.center + new Vector3(offsetX, offsetY, offsetZ);

            // choose random organisms
            // choose random locations within the bounds
        }
    }

    private void ArrangeOrganismsByTrophicLevel(Organism[] organisms)
    {
        List<Organism> temporaryPrimaryProducers = new List<Organism>();
        List<Organism> temporaryPrimaryConsumers = new List<Organism>();
        List<Organism> temporarySecondaryConsumers = new List<Organism>();
        List<Organism> temporaryApexPredators = new List<Organism>();

        foreach(Organism organism in organisms)
        {
            switch(organism.trophicLevel) {
                case Types.TrophicLevel.PrimaryProducer:
                    temporaryPrimaryProducers.Add(organism);
                    break;
                case Types.TrophicLevel.PrimaryConsumer:
                    temporaryPrimaryConsumers.Add(organism);
                    break;
                case Types.TrophicLevel.SecondaryConsumer:
                    temporarySecondaryConsumers.Add(organism);
                    break;
                case Types.TrophicLevel.ApexPredator:
                    temporaryApexPredators.Add(organism);
                    break;
            }
        }

        primaryProducers = temporaryPrimaryProducers.ToArray();
        primaryConsumers = temporaryPrimaryConsumers.ToArray();
        secondaryConsumers = temporarySecondaryConsumers.ToArray();
        apexPredators = temporaryApexPredators.ToArray();
    }
}