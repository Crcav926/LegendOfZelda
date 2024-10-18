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
        private readonly DynamicSprite _enemy;

        public EnemyBlockTop(DynamicSprite enemy) => _enemy = enemy;

        public void Execute()
        {
            _enemy.position = new Vector2(_enemy.position.X, _enemy.position.Y + 1);
        }
    }
}