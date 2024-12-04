using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ObjectManagementExamples;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using LegendOfZelda.Collision;
using System.Xml;
using Microsoft.VisualBasic;
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;
using LegendOfZelda.Sounds;
using LegendOfZelda.HUD;
using System.ComponentModel.Design;

namespace LegendOfZelda
{
    public class Globals
    {
        //0 is adventure/default 1 is rogue/holiday
        public static int tex { get; set; } = 0;
        public static int mode { get; set; } = 0;
        public static bool inMenus { get; set; } = true;
        public static bool hasMap { get; set; } = false;
        public static int menuType {get;set;} = 0;
        public static int gameOverMode { get; set; } = 0;
        public static int winMode { get; set; } = 0;
    }
}
