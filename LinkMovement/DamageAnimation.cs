﻿using Microsoft.Xna.Framework;

using System.Collections.Generic;


namespace LegendOfZelda.LinkMovement
{
    internal class DamageAnimation
    {
        private double timeElapsed = 0;
        // How long per color change.
        private double colorChangeInterval;
        // Index of current color from damageColors. 
        private int currentColorIndex;
        // How many times Miku will cycle through the damage animation.
        private int cycleCount;
        private int maxCycles;
        private List<Color> damageColors = new List<Color> { Color.White, Color.Red, Color.OrangeRed, Color.DarkGray, Color.Gray };
        private bool isDamaged;
        public bool IsDamaged
        {
            get { return isDamaged; }
            set { isDamaged = value; }
        }
        public DamageAnimation()
        {
            // Initializations
            isDamaged = false;
            // How many times it cycles through the colors.
            maxCycles = 6;
            timeElapsed = 0;
            // Time between each color frame change.
            colorChangeInterval = 0.05;
        }

        public void StartDamageEffect()
        {
            // Sets isDamaged to true and timer, idx, 
            isDamaged = true;
            timeElapsed = 0;
            currentColorIndex = 0;
            cycleCount = 0;
        }

        public void Update(GameTime gameTime)
        {

            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            // Checks if enough time has elapsed to meet the interval
            if (timeElapsed >= colorChangeInterval)
            {
                currentColorIndex = (currentColorIndex + 1) % damageColors.Count;

                if (currentColorIndex == 0)
                {
                    cycleCount++;
                }

                timeElapsed = 0;

                if (cycleCount >= maxCycles)
                {
                    isDamaged = false;
                }
            }
        }


        public Color GetCurrentColor()
        {
            if (isDamaged)
            {
                return damageColors[currentColorIndex];
            }
            else
            {
                return Color.White;
            }
        }
    }
}