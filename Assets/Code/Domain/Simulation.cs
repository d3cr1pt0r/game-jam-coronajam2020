﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Domain;

namespace Domain
{
    public class Simulation
    {
        private readonly InfectionSpreadingSystem spreadingSystem;
        private readonly InfectionProgressionSystem progressionSystem;
        private readonly ActionUpdateSystem agentActionSystem;
        private readonly MovementSystem movementSystem;

        private Agent[] agents;
        private Map map;



        public void Update(float deltaTime)
        {
            int count = agents.Length;
            for (int i = 0; i < count; ++i)
            {
                ref var agent = ref agents[i];
                progressionSystem.Update(ref agent.Health);
            }

            for (int i = 0; i < count; ++i)
            {
                ref var agent = ref agents[i];
                movementSystem.Update(ref agent.Movement);
            }

            int tileCount = map.TileCount;
            for (int i = 0; i < tileCount; ++i)
            {
                var tileId = new TileId(i);
                spreadingSystem.Update(tileId);
            }

            for (int i = 0; i < count; ++i)
            {
                ref var agent = ref agents[i];
                agentActionSystem.Update(ref agent);
            }


        }
    }
}
