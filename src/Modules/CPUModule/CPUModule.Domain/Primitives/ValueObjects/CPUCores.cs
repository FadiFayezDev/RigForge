using BuildingBlocks.Domain.Bases;

namespace CPUModule.Domain.Primitives.ValueObjects
{
    public class CPUCores : ValueObject
    {
        public int PerformanceCores { get; private set; }

        public int EfficiencyCores { get; private set; }

        public int TotalCores =>
            PerformanceCores + EfficiencyCores;


        private CPUCores(int performanceCores, int efficiencyCores)
        {
            PerformanceCores = performanceCores;
            EfficiencyCores = efficiencyCores;
        }


        public static CPUCores Create(
            int performanceCores,
            int efficiencyCores)
        {
            Validate(performanceCores, efficiencyCores);

            return new CPUCores(
                performanceCores,
                efficiencyCores);
        }


        public void SetCores(
            int performanceCores,
            int efficiencyCores = 0)
        {
            Validate(performanceCores, efficiencyCores);

            PerformanceCores = performanceCores;
            EfficiencyCores = efficiencyCores;
        }


        private static void Validate(
            int performanceCores,
            int efficiencyCores)
        {
            if (performanceCores < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(performanceCores));

            if (efficiencyCores < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(efficiencyCores));

            if (performanceCores == 0 &&
                efficiencyCores == 0)
            {
                throw new ArgumentException(
                    "CPU must have at least one core.");
            }
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return PerformanceCores;
            yield return EfficiencyCores;
        }
    }
}