using System.Numerics;

namespace Domain
{
    public struct TileId
    {
        public int Id { get; }

        public TileId(int id)
        {
            Id = id;
        }

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
        public TileId Id { get; }
        public TileType Type { get; }
        public Vector2 Position { get; }

        internal Tile(TileId id, TileType type, Vector2 position)
        {
            Id = id;
            Type = type;
            Position = position;
        }

    }
}
