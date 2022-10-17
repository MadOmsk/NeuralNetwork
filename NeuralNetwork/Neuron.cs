namespace NeuralNetwork
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public double Output { get; private set; }
        public Layer Layer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputCount">Количество входящих нейронов</param>
        public Neuron(int inputCount)
        {
            Weights = new List<double>();

            for (int i = 0; i < inputCount; i++)
            {
                Weights.Add(1);
            }
        }
        
        public double FeedForward(List<double> inputs)
        {
            double sum = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weights[i];
            }
            if (Layer.NeuronType != NeuronType.Input)
                return Sigmoid(sum);
            else
                return sum;
        }

        /// <summary>
        /// Сигмоида
        /// </summary>
        /// <param name="x">Аргумент</param>
        /// <returns>Значение функции сигмоида</returns>
        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public void SetWeight(params double[] weights)
        {
            // TODO: удалить после добавления возможности обучения сети.
            if (weights.Length != Weights.Count)
                throw new ArgumentException("Количество параметров не соответствует количеству входных данных нейрона.");

            for (int i = 0; i < weights.Length; i++)
            {
                Weights[i] = weights[i];
            }
        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
