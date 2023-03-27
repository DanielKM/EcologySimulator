public static class Types
{
    // Organism Types
    public enum TrophicLevel 
    {
        PrimaryProducer,
        PrimaryConsumer,
        SecondaryConsumer,
        ApexPredator
    }
    
    public enum Kingdom 
    {
        Animal,
        Plant,
        Fungi
    }

    public enum Range 
    {
        Stationary,
        Nomadic,
        Territorial,
    }

    public enum Movement 
    {
        None,
        Water,
        Land,
        Air
    }

    public enum ResourceStatus
    {
        None,
        Unavailable,
        Available,
        Gathered,
        PickedClean
    }

    public enum EcosystemBalance
    {
        NoPredators,
        FewPredators,
        Balanced,
        ManyPredators,
        HeavyPredators
    }

    public enum EcosystemAge
    {
        New,
        Young,
        Mature
    }

    public enum Sex
    {
        None,
        Male,
        Female,
        Clone,
        Other
    }

    public enum Class
    {
        None,
        Arthropod,
        Fish,
        Amphibian,
        Reptile,
        Birds,
        Mammals,
        Fungi,
        Fern,
        Conifer,
        Flowering
    }
}