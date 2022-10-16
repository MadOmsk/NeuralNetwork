using System.Linq;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {

        public List<Layer> Layers { get; }
        public Topology Topology { get; }

        public NeuralNetwork(Topology topology)
        {
            Layers = new List<Layer>();

            Topology = topology;

            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutputLayer();
        }

        public Neuron FeedForward(List<double> inputSignals)
        {
            SendSignalsToInputLayer(inputSignals);
            FeedForwardAllLayersAfterInput();

            if (Topology.OutputCount == 1)
                return Layers.Last().Neurons[0];
            else 
                return Layers.Last().Neurons.OrderByDescending(n => n.Output).First();
        }

        private void FeedForwardAllLayersAfterInput()
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                var prevLayerSignals = Layers[i - 1].GetSignals();
                var layer = Layers[i];
                foreach (var neuron in layer.Neurons)
                {
                    neuron.FeedForward(prevLayerSignals);
                }
            }
        }

        private void SendSignalsToInputLayer(List<double> inputSignals)
        {
            if (inputSignals.Count != Topology.InputCount)
                throw new ArgumentException("Число входных сигналов не равно числу входных сигналов нейронной сети");

            for (int i = 0; i < inputSignals.Count; i++)
            {
                var signal = new List<double> { inputSignals[i] };
                var neuron = Layers[0].Neurons[i];
                neuron.FeedForward(signal);
            }
        }

        private void CreateOutputLayer()
        {
            var outputNeurons = new List<Neuron>();
            var prevLayer = Layers.Last();
            for (int i = 0; i < Topology.OutputCount; i++)
            {
                var neuron = new Neuron(prevLayer.Count);
                outputNeurons.Add(neuron);
            }
            var outputLayer = new Layer(outputNeurons, NeuronType.Output);
            Layers.Add(outputLayer);
        }

        private void CreateHiddenLayers()
        {
            for (int j = 0; j < Topology.HiddenLayers.Count; j++)
            {


                var hiddenNeurons = new List<Neuron>();
                var prevLayer = Layers.Last();
                for (int i = 0; i < Topology.HiddenLayers[j]; i++)
                {
                    var neuron = new Neuron(prevLayer.Count);
                    hiddenNeurons.Add(neuron);
                }
                var hiddenLayer = new Layer(hiddenNeurons);
                Layers.Add(hiddenLayer);
            }
        }

        private void CreateInputLayer()
        {
            var inputNeurons = new List<Neuron>();
            for (int i = 0; i < Topology.InputCount; i++)
            {
                var neuron = new Neuron(1);
                inputNeurons.Add(neuron);
            }
            var inputLayer = new Layer(inputNeurons, NeuronType.Input);
            Layers.Add(inputLayer);
        }
    }
}
