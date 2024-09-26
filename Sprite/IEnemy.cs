using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//update to Ienemy
public interface IEnemy
{
    void Update(GameTime gameTime);
    void Draw();

    void takendamage();

    void attack();
}

