using UnityEngine;

namespace Domain
{
    public struct AgentMovement
    {
        public TileId TargetTile;
        public TileId CurrentTile;
        public Vector2 CurrentLocation;
        public TileId ImmediateTarget;
        public Vector2 ImmediateTargetLocation;
    }
}
