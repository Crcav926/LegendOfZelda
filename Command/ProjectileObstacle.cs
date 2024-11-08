using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class ProjectileObstacle : ICommand
    {
        private readonly IProjectile proj;

        public ProjectileObstacle(IProjectile projectile) => proj = projectile;

        public void Execute()
        {
            //delete the projectile.
            proj.deleteSelf();
        }
    }
}
