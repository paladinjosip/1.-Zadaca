using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class CollisionDetector
    {

        public static bool Overlaps(Sprite s1, Sprite s2) {
            bool HitY;
            if (s1.Position.Y > s2.Position.Y) { 
                 HitY = ((s1.Position.Y - s2.Size.Height) <= s2.Position.Y);
            }else
                 HitY  = ((s1.Position.Y + s1.Size.Height) >= s2.Position.Y);
             
            bool HitX = (s1.Position.X >= s2.Position.X ) && ((s1.Position.X) <=( s2.Position.X + s2.Size.Width));
            return HitY && HitX;
        }
    }
}
