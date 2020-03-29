

namespace Domain
{
    public sealed class AgentSpecification
    {
        private readonly bool isWorkFromHomeViable;
        private readonly Happiness abidesByPoliciesThreshold;

        public TileId HomeTile { get; }
        public TileId WorkTile { get; }

        public bool CanWork(bool onlyWorkFromHomePossible)
        {
            if (onlyWorkFromHomePossible)
            {
                return isWorkFromHomeViable;
            }

            return true;
        }

        public bool AbidesByPolicies(Happiness happiness)
        {
            return happiness.Value >= abidesByPoliciesThreshold.Value;
        }

        public AgentSpecification(TileId home, TileId work, bool isWorkFromHomeViable, Happiness abidesByPoliciesThreshold)
        {
            HomeTile = home;
            WorkTile = work;
            this.isWorkFromHomeViable = isWorkFromHomeViable;
            this.abidesByPoliciesThreshold = abidesByPoliciesThreshold;
        }
    }
}
