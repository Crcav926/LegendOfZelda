using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class EnemyItem : ICommand
    {
        private readonly IEnemy enemy;

        public EnemyItem(IEnemy en) => enemy = en;

        public void Execute()
        {
            //take damage
            enemy.takendamage();
        }
    }
}