namespace CodeBase.Weapons.Modifiers
{
    public interface IOperationStrategy
    {
        float Value { get; }
        float Calculate(float value);
    }
    public class AddOperation : IOperationStrategy
    {
        private readonly float value;
        public float Value => value;
        public AddOperation(float value)
        {
            this.value = value;
        }


        public float Calculate(float value) => (dynamic)value + this.value;
    }
    public class MultiplyOperation : IOperationStrategy
    {
        private readonly float value;
        public float Value => value;
        public MultiplyOperation(float value)
        {
            this.value = value;
        }


        public float Calculate(float value) => (dynamic)value * this.value;
    }
    //public class Enable : IOperationStrategy<bool>
    //{
    //    public bool Calculate(bool value)
    //    {
    //        return true;
    //    }
    //}
}
