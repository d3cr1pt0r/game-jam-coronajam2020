using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Policies
{
    public class HospitalLimitPolicy : Policy<int>
    {
        private Map map;

        internal HospitalLimitPolicy(Map map) : base("Hospital Limit")
        {
            this.map = map;
        }

        protected override void ValueChanged()
        {
            map.SetTileAgentLimit(TileType.Hospital, Value);
        }
    }
}