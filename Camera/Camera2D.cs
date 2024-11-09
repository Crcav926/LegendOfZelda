using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class Camera2D
    {
        Matrix cameraMatrix;
        Vector2 position = new Vector2(0, Constants.HUDHeight);
        Vector2 targetPosition = new Vector2(0, Constants.HUDHeight);

        private static Camera2D instance = new Camera2D();

        public static Camera2D Instance
        {
            get
            {
                return instance;
            }
        }
        public Camera2D()
        {
            cameraMatrix = Matrix.CreateTranslation(new Vector3(position, 0)) * Matrix.CreateScale(Constants.ScaleX, Constants.ScaleY, 1.0f);
        }
        public Matrix getMatrix()
        {
            cameraMatrix = Matrix.CreateTranslation(new Vector3(position, 0)) * Matrix.CreateScale(Constants.ScaleX, Constants.ScaleY, 1.0f);
            return cameraMatrix;
        }
        public void slideLeft()
        {
            targetPosition.X = (int)position.X + 800;
        }
        public void slideRight()
        {
            targetPosition.X = (int)position.X - 800;
        }
        public void slideUp()
        {
            targetPosition.Y = (int)position.Y - 480;
        }
        public void slideDown() 
        {
            targetPosition.Y = (int)position.Y + 480;
        }
        public void Update()
        {
            position = Vector2.Lerp(position, targetPosition, .05f);
        }
        public Vector2 getPosition()
        {
            Debug.WriteLine(position);
            return position;
        }
    }
}
