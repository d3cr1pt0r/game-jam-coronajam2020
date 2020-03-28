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
        public TileType Type;
        public Vector2 Position;
        public List<AgentId> AgentsOnTile;
        public int NumberOfAgents => AgentsOnTile.Count;
    }
}
