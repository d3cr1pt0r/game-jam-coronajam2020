using System;
using System.Threading;


namespace Domain
{
    public abstract class Policy
    {
        public string Name { get; }

        protected Policy(string name)
        {
            Name = name;
        }
    }

    public abstract class Policy<T> : Policy where T: struct
    {
        private T policyValue;

        public T Value
        {
            get => policyValue;
            set 
            {
                policyValue = value;
                ValueChanged();
            }
        }

        public Policy(string name)
            : base(name)
        {
        }

        protected virtual void ValueChanged()
        {

        }

        protected virtual bool DoesAllowAction(Type actionType, ref Agent agent)
        {
            return true;
        }

    }
}
