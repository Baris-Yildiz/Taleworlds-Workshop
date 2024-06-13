namespace TaleworldsWorkshopProject
{
    public class Potion
    {
        public enum Type
        {
            Health,
            Attack
        }

        private Type _type;
        public float EffectRatio { get => _effectRatio; }
        private float _effectRatio;

        public int Cost { get => _cost; }
        private int _cost;

        private Random _random = new Random();

        public Potion(Type type, int cost) {
            
            _type = type;
            _effectRatio = (float)(_random.NextDouble() * 20.0); 
            _cost = cost;
        } 
    }
}
