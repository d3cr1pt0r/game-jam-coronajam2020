using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Actions
{
    internal sealed class EatAction : Action
    {
        private float remainingTime;

        public EatAction(float eatingTime)
        {
            remainingTime = eatingTime;
        }

        public override ActionUpdateResult Update(float deltaTime, ref Agent agent)
        {
            remainingTime -= deltaTime;
            if (remainingTime > 0)
            {
                return ActionUpdateResult.StayInAction;
            }

            agent.Hunger = Hunger.Max;
            return ActionUpdateResult.FinishedAction;
        }
    }
}
