namespace NeuralNetwork
{
    public class Topology
    {
        // Количество входных данных.
        public int InputCount { get; }
        // Количество выходных данных.
        public int OutputCount { get; }
        // Количество скрытых слоёв.
        public List<int> HiddenLayers { get; }

        public Topology(int inputCount, int outputCount, params int[] layers)
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            HiddenLayers = layers.ToList<int>();
        }
    }
}
