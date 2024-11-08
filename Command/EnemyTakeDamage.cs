using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// I don't think this command is in use anymore.
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