using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Domain
{
    internal struct AgentOnTileInfo
    {
        public AgentId AgentId;
        public Vector2 Position;
    }

    internal sealed class Map
    {
        // Read-only data data
        private readonly Tile[] tiles;
        private readonly List<TileId>[] neigboringTiles;
        // Dynamic data
        private readonly List<AgentOnTileInfo>[] agentsOnTile;

        private readonly Random random = new Random();

        public int TileCount => tiles.Length;

        public ref readonly Tile GetTile(TileId tileId)
        {
            return ref tiles[tileId.Id];
        }

        public IReadOnlyList<AgentOnTileInfo> GetAgentsOnTileInfo(TileId tile)
        {
            return agentsOnTile[tile.Id];
        }

        public void SpawnAgentOnTile(TileId tile, AgentId agentId, out Vector2 position)
        {
            position = GetTargetPositionOnTile(tile);
            agentsOnTile[tile.Id].Add(new AgentOnTileInfo { AgentId = agentId, Position = position });
        }

        public void MoveAgentToTile(TileId from, TileId to, AgentId agentId, out Vector2 targetPosition)
        {
            int removedCount = agentsOnTile[from.Id].RemoveAll(x => x.AgentId.Id == agentId.Id);
            if (removedCount != 1)
            {
                throw new InvalidOperationException("Cannot move agent to a new tile, was not on the old tile");
            }

            targetPosition = GetTargetPositionOnTile(to);
            agentsOnTile[to.Id].Add(new AgentOnTileInfo {AgentId = agentId, Position = targetPosition});
        }

        private Vector2 GetTargetPositionOnTile(TileId tileId)
        {
            // TODO: more sophisticated random generation, maybe need some data stored on tile
            // TODO: also add seeded random so unit tests are stable
            var tile = tiles[tileId.Id];
            return tile.Position +
                   new Vector2((float) random.NextDouble() * 2 - 1, (float) random.NextDouble() * 2 - 1);
        }

        internal TileId GetNextTileOnPath(TileId currentTile, TileId target, bool canIgnoreTileLimits)
        {
            // TODO: if simple implementation, can be here, otherwise delegate to algorithm
            return new TileId();
        }

        public TileId GetClosest(TileType tileType, TileId currentTile)
        {
            // TODO: if simple implementation, can be here, otherwise delegate to algorithm
            return new TileId();
        }


    }
}
