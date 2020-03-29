using System;
using Domain.Actions;


namespace Domain
{
    public class ActionScheduleSystem
    {
        private float deltaTime;
        private Map map;
        private Random random = new Random();

        public void Update(ref Agent agent)
        {
            if (agent.ActionQueue.Count != 0)
                return;

            // TODO: add other actions & policies affect
            // Maybe refactor later into factory functions

            if (agent.Health.State == HealthState.NeedsMedicalTreatment)
            {
                var nearestHospital = map.GetClosest(TileType.Hospital, agent.Movement.CurrentTile);

                agent.ActionQueue.Enqueue(new GoToAction(nearestHospital));
                agent.ActionQueue.Enqueue(new CureIllnessAction());
                return;
            }
        }
    }
}
