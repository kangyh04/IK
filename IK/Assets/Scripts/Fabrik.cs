using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[RequireComponent(typeof(FabrikChain))]
public class Fabrik : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private FabrikChain RootChain;
    [SerializeField, ReadOnly]
    private List<FabrikSolver> Solvers;

    private void LateUpdate()
    {

    }

    private void Reset()
    {
        RootChain = this.GetComponent<FabrikChain>();
        RootChain.SetUp();

        FindTailChains();
    }

    private void FindTailChains()
    {
        foreach (Transform t in transform)
        {
            if (t.GetComponent<FabrikChain>() != null)
            {
                var chain = t.GetComponent<FabrikChain>();
                var tailChains = chain.FindTailChains();
                foreach (var tailChain in tailChains)
                {
                    if (tailChain.GetComponent<FabrikSolver>() != null)
                    {
                        Solvers.Add(tailChain.GetComponent<FabrikSolver>());
                    }
                }
            }
        }
    }
}
