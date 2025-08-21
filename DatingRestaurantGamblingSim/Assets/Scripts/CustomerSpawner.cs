using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [Header("Objects in Scene")]
    public GameObject customerPrefab;
    public GameObject specialCustomerPrefab;
    public SpecialNPCData[] specialCustomers;
    // Private Variables
    private float spawnTimer = 0f;
    private float spawnInterval = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (Globals.dayStarted && !Globals.dayOver)
        {
            // Spawn customers at a rate of Random.Range(0, 0.1*reputation) per second
            float spawnRate = Random.Range(0, 0.01f * Globals.reputation);
            if (spawnTimer >= spawnInterval / spawnRate)
            {
                // int randomSpecialIndex = Random.Range(0, specialCustomers.Length);
                // GameObject specialCustomerPrefab = specialCustomerPrefabs[randomSpecialIndex];
                // GAMBLING TIME
                bool spawnSpecial = Random.value < 0.03f;
                GameObject customerToSpawn = spawnSpecial ? specialCustomerPrefab : customerPrefab;

                // Instantiate the customer at a random door
                Vector3 spawnPosition = Globals.doorPositions[Random.Range(0, Globals.doorPositions.Count)];

                GameObject instance = Instantiate(customerToSpawn, spawnPosition, Quaternion.identity);

                // Handle special NPC
                if (spawnSpecial)
                {
                    int randIndex = Random.Range(0, specialCustomers.Length);
                    SpecialNPCData chosenData = specialCustomers[randIndex];
                    instance.GetComponent<SpecialCustomer>().Initialize(chosenData);
                }

                // Randomize spawn interval
                spawnInterval = Random.Range(1f, 10f);
                spawnTimer = 0f; // Reset the timer after spawning
            }
        }
    }
}
