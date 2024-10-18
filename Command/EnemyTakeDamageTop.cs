using Microsoft.Xna.Framework;

namespace LegendOfZelda.Command
{
    class EnemyTakeDamageTop : ICommand
    {
        private readonly IEnemy _enemy;

        public EnemyTakeDamageTop(IEnemy enemy) => _enemy = enemy;

        public void Execute()
        {
            _enemy.position = new Vector2(_enemy.position.X, _enemy.position.Y - 4);
            _enemy.TakeDamage();
        }
    }
}