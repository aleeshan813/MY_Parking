using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_vehicle : MonoBehaviour
{
    [SerializeField] Color lineColor;

    private List<Transform> nodes = new List<Transform>();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = lineColor;

        Transform[] PathTransform = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < PathTransform.Length; i++)
        {
            if (PathTransform[i] != transform)
            {
                nodes.Add(PathTransform[i]);
            }
        }

        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 CurrentNode = nodes[i].position;
            Vector3 PreviousNOde = Vector3.zero ; 

            if (i > 0)
            {
                PreviousNOde = nodes[i - 1].position;
            }

            else if (i == 0 && nodes.Count > 1)
            {
                PreviousNOde = nodes[nodes.Count - 1].position;
            }

            Gizmos.DrawLine(PreviousNOde , CurrentNode);
            Gizmos.DrawSphere(CurrentNode, 0.3f);
        }
    }
}
