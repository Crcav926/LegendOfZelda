using LegendOfZelda.Command;
using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.Xna.Framework.Audio;
using LegendOfZelda.Sounds;
using LegendOfZelda.HUD;

namespace LegendOfZelda
{
    public class ResetWatchdog
    {
        //so this variable is the only reason we need all this
        public bool resetCheck = false;
        public ResetWatchdog(){}
        //is there a reason we need this private var? why can't we just have the public one?
        private static ResetWatchdog instance = new ResetWatchdog();
        public static ResetWatchdog Instance
        {
            get
            {
                return instance;
            }
        }
    }
}