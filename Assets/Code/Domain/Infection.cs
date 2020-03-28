using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IInfection
    {
        float MaxInfectionRadius { get; }

        bool WillInfect(float radius, HealthState sourceState);

        bool NeedsTreatment();

        bool WillDieUntreated();

    }
}
