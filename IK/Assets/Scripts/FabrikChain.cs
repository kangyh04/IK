using Unity.Collections;
using UnityEngine;

public class FabrikChain : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private FabrikChain Parent;
    [SerializeField, ReadOnly]
    private FabrikChain Child;
    [SerializeField, ReadOnly]
    private float LengthToChild;
    [SerializeField, ReadOnly]
    private Vector3 OriginLocalPos;

    public void SetUp()
    {
        if (this.transform.parent != null && this.transform.parent.GetComponent<FabrikChain>() != null)
        {
            Parent = this.transform.parent.GetComponent<FabrikChain>();
        }
        foreach (Transform child in this.transform)
        {
            if (child.GetComponent<FabrikChain>() != null)
            {
                Child = child.GetComponent<FabrikChain>();
                LengthToChild = Vector3.Distance(this.transform.localPosition, child.transform.localPosition);
            }
        }
        OriginLocalPos = this.transform.localPosition;
    }

    public Vector3 SolveIK(Vector3 targetPos)
    {
        MoveBone(targetPos);

        var parentLocalPos = this.transform.localPosition;

        if (Parent != null)
        {
            parentLocalPos = Parent.SolveIK(this.transform.localPosition);
        }

        MoveBone(parentLocalPos);

        return this.transform.localPosition;
    }

    private void MoveBone(Vector3 targetPos)
    {
        var dir = (this.transform.localPosition - targetPos).normalized;
        var nextPos = dir * LengthToChild;
        this.transform.localPosition = nextPos;
    }
}
