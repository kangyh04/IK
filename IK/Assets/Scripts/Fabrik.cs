using Unity.Collections;
using UnityEngine;

[RequireComponent(typeof(FabrikChain))]
public class Fabrik : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private FabrikChain RootChain;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Reset()
    {
        RootChain = this.GetComponent<FabrikChain>();
        RootChain.SetUp();

        foreach (Transform t in this.transform)
        {
            if (t.GetComponent<FabrikChain>() != null)
            {
                var chain = t.GetComponent<FabrikChain>();
                Debug.LogError(chain.name);
                chain.SetUp();
            }
        }
    }
}
