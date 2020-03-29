using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Policies
{
    public class PublicPlacesLimitPolicy : Policy<int>
    {
        private Map map;

        internal PublicPlacesLimitPolicy(Map map) : base("Zone Limit")
        {
            this.map = map;
        }

        protected override void ValueChanged()
        {
            map.SetTileAgentLimit(TileType.Market, Value);
            map.SetTileAgentLimit(TileType.Entertainment, Value);
        }
    }
}
