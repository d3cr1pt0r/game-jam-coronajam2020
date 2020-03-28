using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Domain
{

    public struct AgentMovement
    {
        public TileId TargetTile;
        public TileId CurrentTile;
        public Vector2 CurrentLocation;
        public TileId ImmediateTarget;
        public Vector2 ImmediateTargetLocation;
    }

    public struct AgentId
    {
        public int Id;
    }

    public sealed class AgentConfiguration
    {
        public TileId HomeTile { get; }
        public TileId WorkTile { get; }
        public bool IsWorkFromHomeViable { get; }

        public bool GetIgnorePolicies(Happiness happiness)
        {
            return false;
        }

        public AgentConfiguration(TileId home, TileId work)
        {
            HomeTile = home;
            WorkTile = work;
            IsWorkFromHomeViable = true;
        }
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
