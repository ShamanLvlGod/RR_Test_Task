using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ArcLayoutHandler : MonoBehaviour
    {
        [SerializeField] private ArcLayoutWrapper anchorPoint;
        [SerializeField] private ArcContainer arcContainer;
    

        public void ApplyArcContainers()
        {
            List<Tuple<ArcContainer, Transform>> arcs = new List<Tuple<ArcContainer, Transform>>();
            for (int i = 0; i < transform.childCount; i++)
            {
                ArcContainer arc = Instantiate(arcContainer, anchorPoint.transform);
                arc.gameObject.name = i.ToString();
                arc.ApplyArc();
                arcs.Add(new Tuple<ArcContainer, Transform>(arc, transform.GetChild(i)));
            }

            foreach (Tuple<ArcContainer, Transform> tuple in arcs)
            {
                tuple.Item2.SetParent(tuple.Item1.transform);
            }

            anchorPoint.RemakeArc();
        }

        public void UpdateArc()
        {
            anchorPoint.RemakeArc();
        }
    }
}