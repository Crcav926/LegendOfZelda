using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    internal class SpriteItemData
    {
        //vert arrow is 1, horiz arrow is 2, boomerang is 3
        // rectangle goes x pos y xpos x to the right y down
        public static List<Rectangle> noItem = new List<Rectangle> { new Rectangle(0, 64, 1, 1) };
        public static List<Rectangle> upArrow = new List<Rectangle> { new Rectangle(1, 36, 5, 16) };
        public static List<Rectangle> rightArrow = new List<Rectangle> { new Rectangle(7, 41, 16, 5) };

        public static List<Rectangle> boomer = new List<Rectangle> { new Rectangle(62, 39, 5, 9), new Rectangle(70, 39, 8, 9), new Rectangle(79, 39, 8, 9) };
        // goes 1 2 3 then down 1 4 3 2
        public static List<Rectangle> boomer2 = new List<Rectangle> { new Rectangle(61, 39, 6, 9), new Rectangle(69, 39, 9, 9), new Rectangle(78, 39, 9, 9), new Rectangle(87, 49, 9, 9), new Rectangle(87, 76, 9, 9), new Rectangle(87, 69, 9, 6), new Rectangle(87, 60, 9, 9), };
        public static List<Rectangle> boomerBlue = new List<Rectangle> { new Rectangle(88, 39, 7, 10), new Rectangle(94, 39, 10, 10), new Rectangle(105, 39, 10, 10) };

        public static List<Rectangle> downArrow = new List<Rectangle> { new Rectangle(65, 56, 6, 16) };
        public static List<Rectangle> leftArrow = new List<Rectangle> { new Rectangle(46, 57, 17, 7) };

        public static List<Rectangle> upBArrow = new List<Rectangle> { new Rectangle(25, 35, 7, 18) };
        public static List<Rectangle> downBArrow = new List<Rectangle> { new Rectangle(74, 56, 7, 18) };
        public static List<Rectangle> rightBArrow = new List<Rectangle> { new Rectangle(32, 40, 18, 8) };
        public static List<Rectangle> leftBArrow = new List<Rectangle> { new Rectangle(45, 65, 18, 8) };
        public static List<Rectangle> bow = new List<Rectangle> { new Rectangle(144, 0, 9, 16) };

        public static List<Rectangle> leekUp = new List<Rectangle> { new Rectangle(0, 54, 10, 20) };
        public static List<Rectangle> leekDown = new List<Rectangle> { new Rectangle(0, 74, 10, 20) };
        public static List<Rectangle> leekRight = new List<Rectangle> { new Rectangle(11, 61, 17, 9) };
        public static List<Rectangle> leekLeft = new List<Rectangle> { new Rectangle(11, 79, 17, 9) };

        public static List<Rectangle> fire = new List<Rectangle> { new Rectangle(188, 36, 16, 16) };
        public static List<Rectangle> tornado = new List<Rectangle> { new Rectangle(207, 36, 16, 16), new Rectangle(224, 36, 16, 16), new Rectangle(241, 36, 16, 16), new Rectangle(258, 36, 16, 16) };

        public static List<Rectangle> heartRed = new List<Rectangle> { new Rectangle(0, 0, 7, 7) };
        public static List<Rectangle> halfHeart = new List<Rectangle> { new Rectangle(8, 0, 7, 7) };
        public static List<Rectangle> emptyHeart = new List<Rectangle> { new Rectangle(16, 0, 7, 7) };
        public static List<Rectangle> heartBlue = new List<Rectangle> { new Rectangle(0, 8, 7, 7) };
        public static List<Rectangle> heartBig = new List<Rectangle> { new Rectangle(25, 0, 13, 13) };

        public static List<Rectangle> fairy = new List<Rectangle> { new Rectangle(40, 0, 8, 16), new Rectangle(48, 0, 8, 16) };
        public static List<Rectangle> clock = new List<Rectangle> { new Rectangle(58, 0, 11, 16) };

        public static List<Rectangle> jewelOrange = new List<Rectangle> { new Rectangle(72, 0, 8, 16) };
        public static List<Rectangle> jewelBlue = new List<Rectangle> { new Rectangle(72, 16, 8, 16) };

        public static List<Rectangle> potionRed = new List<Rectangle> { new Rectangle(80, 0, 8, 16) };
        public static List<Rectangle> potionBlue = new List<Rectangle> { new Rectangle(80, 16, 8, 16) };

        public static List<Rectangle> scroll = new List<Rectangle> { new Rectangle(87, 0, 8, 16) };
        public static List<Rectangle> scrollBlue = new List<Rectangle> { new Rectangle(88, 16, 8, 16) };

        public static List<Rectangle> meat = new List<Rectangle> { new Rectangle(88, 0, 8, 16) };

        public static List<Rectangle> sword = new List<Rectangle> { new Rectangle(104, 0, 8, 16) };
        public static List<Rectangle> swordBlue = new List<Rectangle> { new Rectangle(104, 16, 8, 16) };
        public static List<Rectangle> swordFancy = new List<Rectangle> { new Rectangle(112, 0, 8, 16) };

        public static List<Rectangle> shield = new List<Rectangle> { new Rectangle(120, 0, 8, 16) };
        public static List<Rectangle> boomerang = new List<Rectangle> { new Rectangle(128, 0, 8, 16) };
        public static List<Rectangle> boomerangBlue = new List<Rectangle> { new Rectangle(128, 16, 8, 16) };

        public static List<Rectangle> bomb = new List<Rectangle> { new Rectangle(124, 35, 11, 18), new Rectangle(135, 35, 16, 18), new Rectangle(152, 35, 16, 18), new Rectangle(169, 35, 16, 18) };

        public static List<Rectangle> candle = new List<Rectangle> { new Rectangle(160, 0, 8, 16) };
        public static List<Rectangle> candleBlue = new List<Rectangle> { new Rectangle(160, 16, 8, 16) };

        public static List<Rectangle> ring = new List<Rectangle> { new Rectangle(169, 0, 8, 16) };
        public static List<Rectangle> ringBlue = new List<Rectangle> { new Rectangle(169, 16, 8, 16) };
        public static List<Rectangle> ringIsh = new List<Rectangle> { new Rectangle(176, 0, 8, 16) };

        public static List<Rectangle> chain = new List<Rectangle> { new Rectangle(185, 0, 8, 16) };
        public static List<Rectangle> logs = new List<Rectangle> { new Rectangle(193, 0, 16, 16) };
        public static List<Rectangle> ladder = new List<Rectangle> { new Rectangle(208, 0, 16, 16) };

        public static List<Rectangle> wand = new List<Rectangle> { new Rectangle(225, 0, 7, 16) };

        public static List<Rectangle> healthPack = new List<Rectangle> { new Rectangle(232, 0, 8, 16) };

        public static List<Rectangle> key = new List<Rectangle> { new Rectangle(240, 0, 8, 16) };
        public static List<Rectangle> key2 = new List<Rectangle> { new Rectangle(248, 0, 8, 16) };

        public static List<Rectangle> compass = new List<Rectangle> { new Rectangle(258, 0, 16, 16) };
        public static List<Rectangle> triforce = new List<Rectangle> { new Rectangle(275, 1, 16, 16) };
        public static List<Rectangle> triforceBlue = new List<Rectangle> { new Rectangle(275, 18, 16, 16) };




        public static List<List<Rectangle>> SpriteFrames = new List<List<Rectangle>> { noItem,upArrow, rightArrow, boomer, boomerBlue, downArrow, leftArrow,bomb,upBArrow,downBArrow, rightBArrow, leftBArrow, bow, leekUp, leekDown,
        leekRight, leekLeft, fire, tornado,heartRed, halfHeart, emptyHeart,
        heartBlue, heartBig, fairy, clock, jewelOrange, jewelBlue, potionRed, potionBlue,scroll, scrollBlue, meat, sword, swordBlue, swordFancy, shield, boomerang, boomerangBlue, candle, candleBlue, ring, ringBlue, ringIsh, chain, logs,
    ladder, wand , healthPack, key, key2, compass, triforce, triforceBlue};




        public static List<Rectangle> GetRectangleData(int spriteValue)
        {
            // return the list of frames
            return SpriteFrames[spriteValue];

        }

        public static int ListLength() { return SpriteFrames.Count; }


    }
}