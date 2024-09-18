namespace InnovaSat24.Extensions
{
    public static class RandomExtensions
    {
        public static TValue PickOne<TValue>(this Random random, params TValue[] values)
        {
            return values[random.Next(values.Length)];
        }
        public static double NextGaussian(this Random random, double mean = 0, double stdDev = 1)
        {
            var u1 = 1.0 - random.NextDouble();
            var u2 = 1.0 - random.NextDouble();
            var normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + stdDev * normal;
        }
        public static float NextGaussianSingle(this Random random, float mean = 0, float stdDev = 1)
        {
            return (float)random.NextGaussian(mean, stdDev);
        }

        public static float NextSingle(this Random random, float min, float max) => random.NextSingle() * (max - min) + min;
        public static float NextSingle(this Random random, float max) => random.NextSingle() * max;

        public static double NextDouble(this Random random, double min, double max) => random.NextDouble() * (max - min) + min;
        public static double NextDouble(this Random random, double max) => random.NextDouble() * max;

        public static TimeSpan NextTimeSpan(this Random random, TimeSpan min, TimeSpan max) => TimeSpan.FromMilliseconds(random.NextDouble(min.TotalMilliseconds, max.TotalMilliseconds));
        public static TimeSpan NextTimeSpan(this Random random, TimeSpan max) => TimeSpan.FromMilliseconds(random.NextDouble(max.TotalMilliseconds));

    }
}
