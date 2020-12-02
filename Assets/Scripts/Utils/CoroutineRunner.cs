using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class CoroutineRunner : MonoBehaviour
    {
        static CoroutineRunner instance;

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }

        public static Coroutine RunCoroutine(IEnumerator task)
        {
            return instance.StartCoroutine(task);
        }

        public static void Stop(Coroutine coroutine)
        {
            if (instance)
            {
                instance.StopCoroutine(coroutine);
            }
        }
    }

    public class ScheduleTask : YieldTask
    {
        public ScheduleTask(Action task, float timer) : base(DelayedTask(task, timer))
        {
        }

        private static IEnumerator DelayedTask(Action task, float timer)
        {
            yield return new WaitForSeconds(timer);

            task?.Invoke();
        }
    }

    public class YieldTask : CustomYieldInstruction
    {
        private readonly IEnumerator task;
        private Action onComplete;

        public event Action OnComplete
        {
            add
            {
                onComplete += value;
                if (completed)
                {
                    value?.Invoke();
                }
            }
            remove => onComplete -= value;
        }

        public override bool keepWaiting => !completed;


        private bool completed = false;
        private Coroutine coroutine, subCoroutine;

        public YieldTask(IEnumerator task)
        {
            this.task = task;
        }

        public YieldTask Start()
        {
            coroutine = CoroutineRunner.RunCoroutine(CompleteCoroutine(task));
            return this;
        }

        private IEnumerator CompleteCoroutine(IEnumerator cor)
        {
            subCoroutine = CoroutineRunner.RunCoroutine(cor);
            yield return subCoroutine;
            Complete();
        }

        private void Complete()
        {
            onComplete?.Invoke();
            completed = true;
        }

        public void Stop()
        {
            if (coroutine != null)
                CoroutineRunner.Stop(coroutine);
            if (subCoroutine != null)
                CoroutineRunner.Stop(subCoroutine);
        }
    }
}