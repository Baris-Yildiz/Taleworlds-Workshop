namespace TaleworldsWorkshopProject
{
    public class Potion
    {
        public int EffectRatio { get => _effectRatio; }
        private int _effectRatio;

        public int Cost { get => _cost; }
        private int _cost;

        public enum Type
        {
            Health,
            Attack
        }

        private Type _type;

        private Random _random = new Random();

        public Potion(Type type, int cost) {
            
            _type = type;
            _effectRatio = _random.Next(10, 30);
            _cost = cost;
        } 
    }
}
