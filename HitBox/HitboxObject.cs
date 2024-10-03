using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HitboxObject
{
    public Rectangle Hitbox { get; private set; }

    public HitboxObject(Rectangle hitbox)
    {
        Hitbox = hitbox;
    }

    // Update hitbox if the object moves
    public void UpdatePosition(Vector2 newPosition, int width, int height)
    {
        Hitbox = new Rectangle((int)newPosition.X, (int)newPosition.Y, width, height);
    }

    public bool IsColliding(Rectangle playerHitbox, List<HitboxObject> obstacles)
    {
        foreach (var obstacle in obstacles)
        {
            if (playerHitbox.Intersects(obstacle.Hitbox))
            {
                return true;
            }
        }
        return false;
    }

    public void HandleCollision(HitboxObject hitObject, List<HitboxObject> obstacles, Vector2 velocity)
    {
        foreach (var obstacle in obstacles)
        {
            if (hitObject.Hitbox.Intersects(obstacle.Hitbox))
            {
                //  reverse velocity for collide
                if (velocity.X > 0) // Moving right, collision on the right
                {

                    hitObject.UpdatePosition(new Vector2(obstacle.Hitbox.Left - hitObject.Hitbox.Width, hitObject.Hitbox.Y), hitObject.Hitbox.Width, hitObject.Hitbox.Height);
                }
                else if (velocity.X < 0) // Moving left, collision on the left
                {
                    hitObject.UpdatePosition(new Vector2(obstacle.Hitbox.Right, hitObject.Hitbox.Y), hitObject.Hitbox.Width, hitObject.Hitbox.Height);
                }

                if (velocity.Y > 0) // Moving down, collision on the bottom
                {
                    hitObject.UpdatePosition(new Vector2(hitObject.Hitbox.X, obstacle.Hitbox.Top - hitObject.Hitbox.Height), hitObject.Hitbox.Width, hitObject.Hitbox.Height);
                }
                else if (velocity.Y < 0) // Moving up, collision on the top
                {
                    hitObject.UpdatePosition(new Vector2(hitObject.Hitbox.X, obstacle.Hitbox.Bottom), hitObject.Hitbox.Width, hitObject.Hitbox.Height);
                }
            }
        }
    }

    // Maybe just call this class
    public class HitboxManager
    {
        private List<HitboxObject> obstacles;

        public HitboxManager()
        {
            obstacles = new List<HitboxObject>();
        }

        // Add the wall or block
        public void AddObstacle(HitboxObject obstacle)
        {
            obstacles.Add(obstacle);
        }

        public bool CheckCollision(HitboxObject player)
        {
            foreach (var obstacle in obstacles)
            {
                if (player.Hitbox.Intersects(obstacle.Hitbox))
                {
                    return true;
                }
            }
            return false;
        }

        public void HandleCollision(HitboxObject player, Vector2 velocity)
        {
            // Collision resolution, draw a red dot?

        }
    }
}
