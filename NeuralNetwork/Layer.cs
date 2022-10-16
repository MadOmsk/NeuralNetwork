namespace NeuralNetwork
{
    public class Layer
    {
        public List<Neuron> Neurons { get; set; }
        public int Count => Neurons?.Count ?? 0;
        public NeuronType NeuronType { get; }

        public Layer(List<Neuron> neurons, NeuronType type = NeuronType.Normal)
        {
            NeuronType = type;
            Neurons = neurons;
        }

        public List<double> GetSignals()
        {
            var result = new List<double>();
            foreach (var neuron in Neurons)
            {
                result.Add(neuron.Output);
            }
            return result;
        }
    }
}
