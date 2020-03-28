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

        public void Update(float deltaTime, ref Health health)
        {
            health.Update(deltaTime);
            if (!health.IsStateFinished)
                return;

            var result = infectionProgression.NextState(health.State);
            health = new Health(result.state, result.duration);
        }
    }
}
