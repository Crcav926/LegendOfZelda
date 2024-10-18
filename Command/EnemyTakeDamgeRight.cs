using Microsoft.Xna.Framework;

namespace LegendOfZelda.Command
{
    class EnemyTakeDamageRight : ICommand
    {
        private readonly IEnemy _enemy;

        public EnemyTakeDamageRight(IEnemy enemy) => _enemy = enemy;

        public void Execute()
        {
            _enemy.position = new Vector2(_enemy.position.X + 4, _enemy.position.Y);
            _enemy.TakeDamage();
        }
    }
}