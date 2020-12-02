using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class TweenTask : YieldTask
    {
        public TweenTask(Action<float> task, float startValue, float targetValue, float time) : base(
            DelayedTask(task, startValue, targetValue, time))
        {
        }

        private static IEnumerator DelayedTask(Action<float> task, float startValue, float targetValue, float time)
        {
            float min, max;
            if (startValue < targetValue)
            {
                min = startValue;
                max = targetValue;
            }
            else
            {
                min = targetValue;
                max = startValue;
            }

            float dif = targetValue - startValue;
            float currentValue = startValue + dif * 0.02f;
            while (currentValue > min && currentValue < max)
            {
                yield return new WaitForSeconds(0);
                currentValue += Time.deltaTime * (1 / time) * dif;
                task?.Invoke(currentValue);
            }

            task?.Invoke(targetValue);
        }
    }
}