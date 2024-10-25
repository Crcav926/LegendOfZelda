using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEnemy
{
    Vector2 position { get; set; }
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
    void ChangeDirection();
    void TakeDamage(int damage);
    Boolean isAlive();
    void Attack();
}

