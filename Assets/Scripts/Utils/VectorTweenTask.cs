using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class VectorTweenTask : YieldTask
    {
        public VectorTweenTask(Action<Vector3> task, Vector3 startValue, Vector3 targetValue, float time) : base(
            DelayedTask(task, startValue, targetValue, time))
        {
        }

        private static IEnumerator DelayedTask(Action<Vector3> task, Vector3 startValue, Vector3 targetValue,
            float time)
        {
            float dif = Vector3.Distance(startValue, targetValue);
            Vector3 currentValue = startValue;
            while (Vector3.Distance(currentValue, targetValue) > 0.5f)
            {
                yield return new WaitForSeconds(0);
                currentValue = Vector3.MoveTowards(currentValue, targetValue, Time.deltaTime * (1 / time) * dif);
                task?.Invoke(currentValue);
            }

            task?.Invoke(targetValue);
        }
    }
}