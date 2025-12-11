using UnityEngine;

public class TestCode : MonoBehaviour
{
    private void Awake()
    {
        foreach (Transform t in transform)
        {
            Debug.LogError(t.name);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
