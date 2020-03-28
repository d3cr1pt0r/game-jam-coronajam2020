using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Domain;

namespace Domain
{
    public class Simulation
    {
        private InfectionSpreadingSystem spreadingSystem;
        private InfectionProgressionSystem progressionSystem;

        private List<Agent> agents = new List<Agent>();
        private List<Tile> tiles = new List<Tile>();

    }
}
