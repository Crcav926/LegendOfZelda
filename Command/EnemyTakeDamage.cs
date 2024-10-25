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
        private IItems item;

        public EnemyTakeDamage(IItems items, IEnemy enemy) {
            _enemy = enemy;
            item = items;
        }

        public void Execute()
        {
            int damage = item.getDamage();
            _enemy.TakeDamage(damage);
        }
    }
}