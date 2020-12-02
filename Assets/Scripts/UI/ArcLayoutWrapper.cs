using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace UI
{
    public class ArcLayoutWrapper : MonoBehaviour
    {
        [SerializeField] float deltaAngle = 5;
        private readonly Dictionary<Transform, float> cardToAngle = new Dictionary<Transform, float>();

        public void RemakeArc()
        {
            new ScheduleTask(RemoveUnusedChild, 0).Start();

            new ScheduleTask(RecalculateArc, 0.04f).Start();
        }

        private void RecalculateArc()
        {
            int i = 0;
            float angle = (transform.childCount + 1) % 2 * (deltaAngle / 2);
            foreach (Transform child in transform)
            {
                float targetAngle = -deltaAngle * (i - transform.childCount / 2) - angle;
                if (!cardToAngle.ContainsKey(child))
                {
                    cardToAngle.Add(child, 0);
                }

                child.GetComponent<ArcContainer>().StartTween(cardToAngle[child], targetAngle);
                cardToAngle[child] = targetAngle;


                ++i;
            }
        }



        private void RemoveUnusedChild()
        {
            List<Transform> destroyList = new List<Transform>();

            foreach (Transform child in transform)
            {
                if (child.childCount == 0)
                {
                    destroyList.Add(child);
                }
            }

            foreach (Transform t in destroyList)
            {
                cardToAngle.Remove(t);
                Destroy(t.gameObject);
            }
        }
    }
}