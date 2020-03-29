using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum HealthState
    {
        Normal,
        Infected,
        InfectedConfirmed,
        NeedsMedicalTreatment,
        Immune,
        Dead
    }

    public struct Health
    {
        public HealthState State { get; }
        public float Duration { get; }
        public float TimeInState { get; }

        public Health(HealthState state, float duration)
        {
            Duration = duration;
            State = state;
            TimeInState = 0;
        }

        private Health(HealthState state, float duration, float timeInState)
        {
            Duration = duration;
            State = state;
            TimeInState = timeInState;
        }

        public Health IncrementTime(float deltaTime)
        {
            return new Health(State, Duration, TimeInState + deltaTime);
        }

        public bool IsIll => State == HealthState.Infected || State == HealthState.InfectedConfirmed || State == HealthState.NeedsMedicalTreatment;

        public bool IsStateFinished => IsIll && TimeInState > Duration;
    }

    public struct Happiness
    {
        public float Value;
    }

    public struct Hunger
    {
        public float Value { get; }

        public Hunger(float value)
        {
            Value = value;
        }

        public static readonly Hunger Min = new Hunger(1.0f);
        public static readonly Hunger Max = new Hunger(1.0f);
    }
}
