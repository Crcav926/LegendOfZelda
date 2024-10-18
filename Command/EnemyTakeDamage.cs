using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class EnemyTakeDamage : ICommand
    {
        private readonly IEnemy _enemy;

        public EnemyTakeDamage(IEnemy enemy) => _enemy = enemy;

        public void Execute()
        {
            _enemy.takendamage();
        }
    }
}