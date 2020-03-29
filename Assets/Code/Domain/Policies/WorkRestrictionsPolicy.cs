using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Actions;

namespace Assets.Code.Domain.Policies
{
    public enum WorkRestriction
    {
        NoRestrictions,
        WorkFromHomeIfPossible,
        WorkFromHomeOnly
    }

    public class WorkRestrictionsPolicy : Policy<WorkRestriction>
    {
        internal WorkRestrictionsPolicy() : base("Work Restriction")
        {
        }

        protected override bool DoesAllowAction(Type actionType, ref Agent agent)
        {
            if (actionType != typeof(WorkAction))
                return true;

            switch (Value)
            {
                case WorkRestriction.NoRestrictions:
                    return true;
                case WorkRestriction.WorkFromHomeIfPossible:
                    return true;
                case WorkRestriction.WorkFromHomeOnly:
                    return agent.IsWorkFromHomeViable;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
