using System.Text;

namespace TaleworldsWorkshopProject
{
    public class BossTurn
    {
        private int _turnIndex;
        public Enemy Boss { get => _boss; }
        private Enemy _boss;

        public BossTurn (int turnIndex)
        {
            if (!Game.CallFromGame)
            {
                return;
            }
            _turnIndex = turnIndex;
            _boss = EntityFactory.BossesInGame[_turnIndex-1];

            Console.WriteLine(_description());
        }

        private string _description()
        {
            StringBuilder prompt = new StringBuilder();
            prompt.Append("----------------------BOSS TURN----------------------");
            prompt.Append($"Boss Turn {_turnIndex} / 3\n");
            prompt.Append($"Boss: {_boss.Name} with {_boss.Health} hp and {_boss.AttackPower} attack power.");

            return prompt.ToString();
        }
    }
}
