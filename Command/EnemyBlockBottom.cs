using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class EnemyBlockBottom : ICommand
    {
        private readonly IEnemy _enemy;

        public EnemyBlockBottom(IEnemy enemy) => _enemy = enemy;

        public void Execute()
        {
            _enemy.position = new Vector2(_enemy.position.X, _enemy.position.Y + 2);
            _enemy.ChangeDirection();
        }
    }
}