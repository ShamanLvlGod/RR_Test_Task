using System;

namespace UnityEngine.UI.Extensions
{
    [AddComponentMenu("Layout/Extensions/Arc Layout")]
    public class ArcLayoutGroup : HorizontalOrVerticalLayoutGroup
    {
        [SerializeField] public Vector3 curveOffset;

        [Tooltip("axis along which to place the items, Normalized before use")] [SerializeField]
        public float angleAxis;

        protected override void OnEnable()
        {
            base.OnEnable();
            CalculateRadial();
        }

        public override void CalculateLayoutInputVertical()
        {
            CalcAlongAxis(0, false);
            CalculateRadial();
        }

        public override void SetLayoutHorizontal()
        {
            CalcAlongAxis(0, false);
            CalculateRadial();
        }

        public override void SetLayoutVertical()
        {
            CalculateRadial();
        }

        private void CalculateRadial()
        {
            m_Tracker.Clear();
            if (transform.childCount == 0)
                return;

            //one liner for figuring out the pivot (why not a utility function switch statement?)
            Vector2 pivot = new Vector2(((int) childAlignment % 3) * 0.5f, ((int) childAlignment / 3) * 0.5f);

            //this seems to work ok-ish
            Vector3 lastPos = new Vector3(
                GetStartOffset(0, GetTotalPreferredSize(0)),
                GetStartOffset(1, GetTotalPreferredSize(1)),
                0f
            );

            // 0 = first, 1 = last child
            float lerp = 0;
            //no need to catch divide by 0 as childCount > 0
            float step = 1f / transform.childCount;
            Vector3 itemAxis = Quaternion.AngleAxis(angleAxis, Vector3.forward) * Vector3.right;
            //normalize and create a distance between items
            var dist = itemAxis.normalized * GetTotalPreferredSize(Mathf.RoundToInt(itemAxis.normalized.x));

            for (int i = 0; i < transform.childCount; i++)
            {
                RectTransform child = (RectTransform) transform.GetChild(i);
                if (child != null)
                {
                    //stop the user from altering certain values in the editor
                    m_Tracker.Add(this, child,
                        DrivenTransformProperties.Anchors |
                        DrivenTransformProperties.AnchoredPosition |
                        DrivenTransformProperties.Pivot);
                    Vector3 vPos = lastPos + dist;
                    const float centerPoint = 0.5f;
                    child.localPosition = lastPos = vPos + (lerp - centerPoint) * curveOffset;

                    child.pivot = pivot;
                    //child anchors are not yet calculated, each child should set it's own size for now
                    child.anchorMin = child.anchorMax = new Vector2(0.5f, 0.5f);
                    lerp += step;
                }
            }
        }
#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            CalculateRadial();
        }
#endif
    }
}