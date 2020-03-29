using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Actions
{
    internal class GoToAction : Action
    {
        private TileId target;

        public GoToAction(TileId target)
        {
            this.target = target;
        }

        public override ActionUpdateResult Update(float deltaTime, ref Agent agent)
        {
            var movement = agent.Movement;

            // Movement system will take over from here
            movement.SetTarget(target);

            if (movement.GetHasReachedTarget())
            {
                return ActionUpdateResult.FinishedAction;
            }
            return ActionUpdateResult.StayInAction;
        }
    }
}
