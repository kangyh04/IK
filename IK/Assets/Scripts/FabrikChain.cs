using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class FabrikChain : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private FabrikChain Parent;
    [SerializeField, ReadOnly]
    private List<FabrikChain> Children;
    [SerializeField, ReadOnly]
    private float LengthToChild;
    [SerializeField, ReadOnly]
    private Vector3 OriginLocalPos;
    [SerializeField, ReadOnly]
    private FabrikSolver Solver;
    [SerializeField, ReadOnly]
    private float DistanceFromRoot;

    public FabrikSolver FabrikSolver { get => Solver; }
    public float DistanceFromToRoot { get => DistanceFromRoot; }

    public void SetUp()
    {
        Children = new List<FabrikChain>();

        if (this.transform.parent != null && this.transform.parent.GetComponent<FabrikChain>() != null)
        {
            Parent = this.transform.parent.GetComponent<FabrikChain>();
            DistanceFromRoot = Parent.DistanceFromRoot + Vector3.Distance(this.transform.position, Parent.transform.position);
        }
        foreach (Transform child in this.transform)
        {
            if (child.GetComponent<FabrikChain>() != null)
            {
                var childChain = child.GetComponent<FabrikChain>();
                Children.Add(child.GetComponent<FabrikChain>());
                LengthToChild = Vector3.Distance(this.transform.position, child.transform.position);
                childChain.SetUp();
            }

            if (child.GetComponent<FabrikSolver>() != null)
            {
                Solver = child.GetComponent<FabrikSolver>();
            }
        }
        OriginLocalPos = this.transform.localPosition;
    }

    public Vector3 SolveIK(Vector3 targetPos)
    {
        var parentPos = this.transform.position;
        var distanceFromParent = 0.0f;

        MoveBone(targetPos, LengthToChild);

        if (Parent != null)
        {
            parentPos = Parent.SolveIK(this.transform.position);
            distanceFromParent = Parent.LengthToChild;
        }

        MoveBone(parentPos, distanceFromParent);

        return this.transform.position;
    }

    private void MoveBone(Vector3 targetPos, float length)
    {
        var dir = (this.transform.position - targetPos).normalized;
        var nextPos = dir * length;
        this.transform.position = nextPos + targetPos;
    }

    public List<FabrikChain> FindTailChains()
    {
        var children = new List<FabrikChain>();
        foreach (var child in Children)
        {
            children.AddRange(child.FindTailChains());
        }
        if (!children.Any())
        {
            children.Add(this);
        }
        return children;
    }
}
