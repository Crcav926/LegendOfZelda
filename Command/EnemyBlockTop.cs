using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class EnemyBlockTop : ICommand
    {
        private readonly IEnemy _enemy;

        public EnemyBlockTop(IEnemy enemy) => _enemy = enemy;

        public void Execute()
        {
            _enemy.position = new Vector2(_enemy.position.X, _enemy.position.Y - Constants.CollisionPushDistance);
            _enemy.ChangeDirection();
        }
    }
}