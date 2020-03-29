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
        public Health Health;
        public Happiness Happiness;
        public AgentMovement Movement;
        public Hunger Hunger;
        public Queue<Action> ActionQueue;
        public AgentSpecification Specification;
    }

}
