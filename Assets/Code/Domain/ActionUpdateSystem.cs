using System;
using System.Collections.Generic;
using System.Linq;


namespace Domain
{
    public class ActionUpdateSystem
    {
        private float deltaTime;

        public void Update(ref Agent agent)
        {
            var actionQueue = agent.ActionQueue;
            if (actionQueue.Count == 0)
                return;

            var executingAction = actionQueue.Peek();
            var result = executingAction.Update(deltaTime, ref agent);

            if (result == ActionUpdateResult.FinishedAction)
                actionQueue.Dequeue();
        }
    }
}
