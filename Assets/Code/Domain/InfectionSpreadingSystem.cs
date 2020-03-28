using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public interface IInfectionSpreading
    {
        bool WillInfect(float radius);
    }

    /// <summary>
    /// Simulates the infection spreading
    /// </summary>
    public class InfectionSpreadingSystem
    {
        private IInfectionSpreading infectionSpreading;

        public void Update(ref Tile tile, IReadOnlyList<Agent> agents)
        {
            var agentsOnTile = tile.AgentsOnTile;
            foreach (var agentId in agentsOnTile)
            {
                
            }
        }
    }
}
