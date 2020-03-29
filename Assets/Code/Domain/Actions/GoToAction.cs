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
            ref var movement = ref agent.Movement;
            if (movement.CurrentTile.Id == target.Id)
            {
                return ActionUpdateResult.FinishedAction;
            }

            // Movement system will take over from here (this is still weird, must use API instead of setting value)
            movement.TargetTile = target;
            return ActionUpdateResult.StayInAction;
        }
    }
}
