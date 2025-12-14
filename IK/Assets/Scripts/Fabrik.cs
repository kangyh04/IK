using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

[RequireComponent(typeof(FabrikChain))]
public class Fabrik : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private FabrikChain RootChain;
    [SerializeField, ReadOnly]
    private List<FabrikSolver> Solvers;
    [SerializeField, ReadOnly]
    private List<FabrikChain> TailChains;

    private void LateUpdate()
    {
        foreach (var solver in Solvers)
        {
            var child = solver.GetComponent<FabrikChain>();
        }

        foreach (var tailchain in TailChains)
        {
            if (tailchain.FabrikSolver != null)
            {
                var solver = tailchain.FabrikSolver;
                var targetPos = solver.transform.position;
                var dir = solver.transform.position - this.transform.position;
                var distanceToSolver = dir.magnitude;
                // NOTE : if distance of root to solver were farer than distance of root to tail
                // modify the target position to the same angle and max distance
                if (distanceToSolver > tailchain.DistanceFromToRoot)
                {
                    targetPos = dir.normalized * tailchain.DistanceFromToRoot + this.transform.position;
                }

                tailchain.SolveIK(targetPos);
            }
        }
    }

    private void Reset()
    {
        RootChain = this.GetComponent<FabrikChain>();
        RootChain.SetUp();

        FindTailChains();

        FindSolvers();
    }

    private void FindTailChains()
    {
        foreach (Transform t in transform)
        {
            if (t.GetComponent<FabrikChain>() != null)
            {
                var chain = t.GetComponent<FabrikChain>();
                var tailChains = chain.FindTailChains();
                TailChains.AddRange(tailChains);
            }
        }
    }

    private void FindSolvers()
    {
        Solvers = TailChains
            .Where(tail => tail.FabrikSolver != null)
            .Select(tail => tail.FabrikSolver)
            .ToList();
    }
}
