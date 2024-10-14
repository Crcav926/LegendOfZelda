using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
	public class collObject
	{

		public ICollideable obj1;
		public ICollideable obj2;
		public Rectangle overlap;

		public collObject(ICollideable o1, ICollideable o2, Rectangle over)
		{
			obj1 = o1;
			obj2 = o2;
			overlap = over;
		}


	}
}


