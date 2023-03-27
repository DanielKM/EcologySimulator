using UnityEngine;

public class EcologySimulator : MonoBehaviour
{
    [Header("References")]
    [SerializeField, Tooltip("Global Environment Scriptable Object to Use")] Environment environment;   

    [Header("Settings")]
    [SerializeField, Tooltip("Tick Rate for the Ecology Simulator")] private int tickRate = 1;   
 
    // Internal Variables
    private float elapseTime = 0f;

    private void Update()
    {
        CheckTick();
    }

    private void CheckTick()
    {
        elapseTime += Time.deltaTime;
        if (elapseTime >= 1f) 
        {
            elapseTime = elapseTime % 1f;
            Tick();
        }
    }

    private void Tick()
    {     
        Debug.Log("Tick");
        // add action
        UpdateEnvironments();
    }

    private void UpdateEnvironments()
    {
        environment.UpdateEnvironments();
    }
}
