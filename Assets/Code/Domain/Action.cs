using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum ActionType
    {
        GoTo,
        Work,
        Entertain,
        CureIllness
    }

    public struct Action
    {
        public ActionType Type;
        public TileId Target;
        public float TimeInAction;
        public float Duration;
    }
}
