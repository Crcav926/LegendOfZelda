using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LegendOfZelda.Collision
{
    internal class detectionManager
    {
        private List<hitbox> stationaryHitboxes;
        private List<hitbox> movingHitboxes;
        public List<Rectangle> collisions;
        int room;

        public detectionManager()
        {
            stationaryHitboxes = new List<hitbox>();
            movingHitboxes = new List<hitbox>();
            collisions= new List<Rectangle> ();
        }

        private void loadHitboxes(int roomNumber)
        {
            room = roomNumber;
            //depending on what room we're in load the hitboxes,
            // for now just load the ones for room 1.
            // stationary is blocks and walls and items
            stationaryHitboxes.Add(new hitbox("leftWall"));
            stationaryHitboxes.Add(new hitbox("rightWall"));
            stationaryHitboxes.Add(new hitbox("topWall"));
            stationaryHitboxes.Add(new hitbox("bottomWall"));

            //moving is link and enemies and link's items (arrow, boomerang, fire, tornado, sword)
            movingHitboxes.Add(new hitbox("link"));
            // items here
            movingHitboxes.Add(new hitbox("boomerang"));

            //enemies here
        }

        public void update()
        {
            //only moving items can initiate collision
            // so for all moving hitboxes
            for (int i = 0; i < movingHitboxes.Count; i++)
            {
                //check collision with all other moving hitboxes
                for (int j=i+1; j<movingHitboxes.Count; j++)
                {
                    //only collide with "bottom triangle"
                    // if theres a collision
                    if (movingHitboxes[i].box.IntersectsWith(movingHitboxes[j].box))
                    {
                        //add it to the collides list.
                        Rectangle intersection = Rectangle.Intersect(movingHitboxes[i].box, movingHitboxes[j].box);
                        collisions.Add(intersection);
                    }
                }
                //check collision with all stationary hitboxes
                for (int j = i + 1; j < stationaryHitboxes.Count; j++)
                {
                    //only collide with "bottom triangle"
                    // if theres a collision
                    if (movingHitboxes[i].box.IntersectsWith(stationaryHitboxes[j].box))
                    {
                        //add it to the collides list.
                        Rectangle intersection = Rectangle.Intersect(movingHitboxes[i].box, stationaryHitboxes[j].box);
                        collisions.Add(intersection);
                    }
                }
            }
        }
    }
}
