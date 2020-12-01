using System;

namespace Utils
{
    public class ObservableData<TType>
    {
        public delegate void OnChangeHandler(TType data);

        private TType data;

        private OnChangeHandler subscriptions;


        public TType Data
        {
            get => data;
            set
            {
                if (!Equals(data, value))
                {
                    data = value;
                    subscriptions?.Invoke(value);
                }
            }
        }

        public void Subscribe(OnChangeHandler call, bool instantUpdate = false)
        {
            subscriptions += call;
            if (instantUpdate)
            {
                call(data);
            }
        }


        public void RemoveSubscription(OnChangeHandler call)
        {
            subscriptions -= call;
        }
    }
}