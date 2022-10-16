namespace NeuralNetwork
{
    public class Neuron
    {
        public List<double> Weigths { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputCount">Количество входящих нейронов</param>
        /// <param name="neuronType">Тип нейрона</param>
        public Neuron(int inputCount, NeuronType neuronType = NeuronType.Normal)
        {
            NeuronType = neuronType;
            Weigths = new List<double>();

            for (int i = 0; i < inputCount; i++)
            {

            }
        }


    }
}
