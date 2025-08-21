using UnityEngine;

public class SpecialCustomer : MonoBehaviour
{
    private SpecialNPCData data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Initialize(SpecialNPCData customerData)
    {
        data = customerData;
        GetComponent<SpriteRenderer>().sprite = data.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
