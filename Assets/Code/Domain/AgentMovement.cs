using UnityEngine;

namespace Domain
{
    public sealed class AgentMovement
    {
        private const float ReachedThresholdSquared = 0.1f * 0.1f;

        private TileId immediateTarget;
        private Vector2 immediateTargetLocation;

        public TileId TargetTile { get; private set; }
        public TileId CurrentTile { get; private set; }
        public Vector2 CurrentLocation { get; private set; }


        public AgentMovement(TileId tile, Vector2 location)
        {
            TargetTile = tile;
            CurrentTile = tile;
            immediateTarget = tile;
            CurrentLocation = location;
            immediateTargetLocation = location;
        }

        internal void SetTarget(TileId tileId)
        {
            TargetTile = tileId;
        }

        internal void UpdateMoveTo(float deltaMovement)
        {
            var distance = Vector2.Distance(immediateTargetLocation, CurrentLocation);

            CurrentLocation += (immediateTargetLocation - CurrentLocation).normalized *
                               Mathf.Min(distance, deltaMovement);
        }

        internal bool GetHasReachedImmediateTarget()
        {
            return Vector2.SqrMagnitude(immediateTargetLocation - CurrentLocation) < ReachedThresholdSquared;
        }

        internal bool GetHasReachedTarget()
        {
            return immediateTarget.Id == TargetTile.Id && GetHasReachedImmediateTarget();
        }

        internal void UpdateImmediateTarget(TileId tileId, Vector2 location)
        {
            immediateTargetLocation = location;
            immediateTarget = tileId;
        }


    }
}
