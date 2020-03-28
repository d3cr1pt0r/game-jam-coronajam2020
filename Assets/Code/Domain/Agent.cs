using System.Collections.Generic;
using UnityEngine;

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
        public float TimeInState { get; private set; }

        public Health(HealthState state, float duration)
        {
            Duration = duration;
            State = state;
            TimeInState = 0;
        }

        public void Update(float deltaTime)
        {
            TimeInState += deltaTime;
        }

        public bool IsIll => State != HealthState.Normal && State != HealthState.Dead && State != HealthState.Immune;

        public bool IsStateFinished => IsIll && TimeInState > Duration;
    }

    public struct Happiness
    {
        public float Value;
    }

    public struct Hunger
    {
        public float Value;
    }

    public struct AgentMovement
    {
        public TileId TargetTile;
        public TileId CurrentTile;
        public Vector2 CurrentLocation;
        public TileId ImmediateTarget;
        public Vector2 ImmediateTargetLocation;
    }

    public sealed class AgentConfiguration
    {
        public TileId HomeTile { get; }
        public TileId WorkTile { get; }

        public AgentConfiguration(TileId home, TileId work)
        {
            HomeTile = home;
            WorkTile = work;
        }
    }

    public struct AgentId
    {
        public int Id;
    }

    public struct Agent
    {
        public Health Health;
        public Happiness Happiness;
        public AgentMovement Movement;
        public Hunger Hunger;
        public List<Action> ActionQueue;
        public AgentConfiguration Configuration;
    }

}
