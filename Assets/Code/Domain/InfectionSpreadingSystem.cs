using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Domain
{

    public interface IInfectionSpreading
    {
        (bool hasInfected, float duration) WillInfect(float radius);
    }

    /// <summary>
    /// Simulates the infection spreading
    /// </summary>
    public class InfectionSpreadingSystem
    {
        private IInfectionSpreading infectionSpreading;
        private Map map;
        private Agent[] agents;

        public void Update(TileId tileId)
        {
            var agentsOnTileInfo = map.GetAgentsOnTileInfo(tileId);

            var count = agentsOnTileInfo.Count;
            for (int i = 0; i < count; ++i)
            {
                var agentInfo = agentsOnTileInfo[i];
                var agentId = agentInfo.AgentId;
                ref var agent = ref GetAgent(agentId);

                if (!agent.Health.IsIll)
                    continue;

                SpreadDisease(agent.Movement.CurrentLocation, agentsOnTileInfo);

            }
        }

        private void SpreadDisease(Vector2 spreadLocation, IReadOnlyList<AgentOnTileInfo> otherAgentsTileInfo)
        {
            for (int i = 0; i < otherAgentsTileInfo.Count; ++i)
            {
                var otherAgent = GetAgent(otherAgentsTileInfo[i].AgentId);

                var distance = Mathf.Sqrt(Vector2.Distance(spreadLocation, otherAgent.Movement.CurrentLocation));
                var (hasInfected, duration) = infectionSpreading.WillInfect(distance);

                if(hasInfected)
                {
                    otherAgent.Health = new Health(HealthState.Infected, duration);
                }
            }
        }

        private ref Agent GetAgent(AgentId id)
        {
            return ref agents[id.Id];
        }
    }
}
