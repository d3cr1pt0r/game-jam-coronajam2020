using System.Collections.Generic;
using System.Numerics;

namespace Domain
{
    public struct TileId
    {
        public int Id;
    }

    public enum TileType
    {
        Household,
        Market,
        Workplace,
        Hospital,
        Entertainment
    }

    public struct Tile
    {
        public TileType Type { get; }
        public Vector2 Position { get; }
        public List<AgentId> AgentsOnTile;
        public int NumberOfAgents => AgentsOnTile.Count;
    }

    public sealed class Map
    {
        private readonly Tile[] tiles;
        // Maybe need some neighbour information

        public Tile GetTile(TileId tileId)
        {
            return tiles[tileId.Id];
        }

        public ref Tile GetClosestNeighborForTarget(Tile currentTile, TileId target, bool canIgnoreTileLimits)
        {
            return ref tiles[0];
        }

        public TileId GetClosest(TileType tileType, TileId currentTile)
        {
            return new TileId();
        }
    }
}
