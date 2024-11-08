using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LegendOfZelda.Command
{
    class EnemyItem : ICommand
    {
        private readonly IEnemy _enemy;
        private IItems item;

        public EnemyItem(IEnemy enemy, IItems items)
        {
            _enemy = enemy;
            item = items;
        }

        public void Execute()
        {
            int damage = item.getDamage();
            _enemy.TakeDamage(damage);
            _enemy.DropItem();
        }
    }
}