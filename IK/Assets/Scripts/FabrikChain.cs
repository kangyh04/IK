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
        Children.Clear();

        if (this.transform.parent != null && this.transform.parent.GetComponent<FabrikChain>() != null)
        {
            Parent = this.transform.parent.GetComponent<FabrikChain>();
        }
        foreach (Transform child in this.transform)
        {
            if (child.GetComponent<FabrikChain>() != null)
            {
                var childChain = child.GetComponent<FabrikChain>();
                Children.Add(child.GetComponent<FabrikChain>());
                LengthToChild = Vector3.Distance(this.transform.localPosition, child.transform.localPosition);
                childChain.SetUp();
            }

            if (child.GetComponent<FabrikSolver>() != null)
            {
                Solver = child.GetComponent<FabrikSolver>();
            }
        }
        OriginLocalPos = this.transform.localPosition;

        DistanceFromRoot = Parent.DistanceFromRoot + (this.transform.localPosition - Parent.transform.localPosition).sqrMagnitude;
    }

    public Vector3 SolveIK(Vector3 targetPos)
    {
        var parentLocalPos = this.transform.localPosition;

        MoveBone(targetPos, LengthToChild);

        if (Parent != null)
        {
            parentLocalPos = Parent.SolveIK(this.transform.localPosition);
        }

        MoveBone(parentLocalPos, Parent.LengthToChild);

        return this.transform.localPosition;
    }

    private void MoveBone(Vector3 targetPos, float length)
    {
        var dir = (this.transform.localPosition - targetPos).normalized;
        var nextPos = dir * length;
        this.transform.localPosition = nextPos;
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
            children = Children;
        }
        return children;
    }
}
