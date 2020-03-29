using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Domain
{
    public struct AgentId
    {
        public int Id { get; }

        public AgentId(int id)
        {
            Id = id;
        }
    }

    public sealed class Agent
    {
        private readonly Happiness abidesByPoliciesThreshold;

        // Read-only (init) properties
        public TileId HomeTile { get; }
        public TileId WorkTile { get; }
        public bool IsWorkFromHomeViable { get; }

        // State properties
        // TODO: I don't like this too much but I guess it is fine-ish
        public Health Health { get; set; }
        public Happiness Happiness { get; set; }
        public AgentMovement Movement { get; set; }
        public Hunger Hunger { get; set; }
        public Queue<Action> ActionQueue { get; set; }

        public bool AbidesByPolicies(Happiness happiness)
        {
            return happiness.Value >= abidesByPoliciesThreshold.Value;
        }

        public Agent(TileId home, TileId work, bool isWorkFromHomeViable, Happiness abidesByPoliciesThreshold)
        {
            HomeTile = home;
            WorkTile = work;
            IsWorkFromHomeViable = isWorkFromHomeViable;
            this.abidesByPoliciesThreshold = abidesByPoliciesThreshold;
        }
    }

}
