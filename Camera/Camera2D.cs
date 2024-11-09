﻿using Microsoft.Xna.Framework;
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
        public Boolean isSliding;

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
            if (!isSliding)
            {
                isSliding = true;
                targetPosition.X = (int)position.X + 800;
            }
        }
        public void slideRight()
        {
            if (!isSliding)
            {
                isSliding = true;
                targetPosition.X = (int)position.X - 800;
            }
        }
        public void slideUp()
        {
            if (!isSliding)
            {
                isSliding = true;
                targetPosition.Y = (int)position.Y + 480;
            }
        }
        public void slideDown() 
        {
            if (!isSliding)
            {
                isSliding = true;
                targetPosition.Y = (int)position.Y - 480;
            }
        }
        public void Update()
        {
            if (isSliding)
            {
                float threshold = 5f; // Set a threshold, e.g., 1 pixel

                // Smoothly interpolate the position towards the target
                position = Vector2.Lerp(position, targetPosition, .03f);

                // Check if the camera is close enough to the target position
                if (Vector2.Distance(position, targetPosition) < threshold)
                {
                    position = targetPosition; // Snap to the exact target
                    isSliding = false; // Stop sliding
                }
            }
        }
        public Vector2 getPosition()
        {
            return targetPosition;
        }
    }
}