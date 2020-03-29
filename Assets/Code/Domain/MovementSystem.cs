using UnityEngine;

namespace Domain
{
    public class MovementSystem
    {
        private Map map;
        private float deltaTime;
        private float movementSpeed;

        // TODO: canIgnoreTileLimits should probably be passed differently
        public void Update(AgentId agentId, AgentMovement movement, bool canIgnoreTileLimits)
        {
            // We are still doing path-finding if target is different from current
            if (movement.TargetTile.Id != movement.CurrentTile.Id)
                UpdatePathFindingIfNeeded(agentId, movement, canIgnoreTileLimits);
            

            var deltaMovement = movementSpeed * deltaTime;
            movement.UpdateMoveTo(deltaMovement);
        }

        private void UpdatePathFindingIfNeeded(AgentId agentId, AgentMovement movement, bool canIgnoreTileLimits)
        {
            if (!movement.GetHasReachedImmediateTarget())
                return;

            var immediateTarget = map.GetNextTileOnPath(movement.CurrentTile, movement.TargetTile, canIgnoreTileLimits);
            map.MoveAgentToTile(movement.CurrentTile, immediateTarget, agentId, out Vector2 immediateTargetPosition);
            movement.UpdateImmediateTarget(immediateTarget, immediateTargetPosition);

        }

    }
}
