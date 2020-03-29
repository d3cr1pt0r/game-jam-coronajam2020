using System;
using Domain;

namespace Assets.Code.Domain
{
    public interface IInfectionProgression
    {
        (HealthState state, float duration) NextState(HealthState currentState);
    }

    public class InfectionProgressionSystem
    {
        private IInfectionProgression infectionProgression;
        private float deltaTime;

        public Health Update(Health health)
        {
            var newHealth = health.IncrementTime(deltaTime);
            if (!newHealth.IsStateFinished)
                return newHealth;

            var result = infectionProgression.NextState(newHealth.State);
            return new Health(result.state, result.duration);
        }
    }
}
