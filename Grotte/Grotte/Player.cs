using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Grotte
{
    public class Player
    {
        public Vector3 Position;
        public Vector3 Direction;
       // public float DirectionLength = 1f;

        public float Angle { 
            get {
                return (float)Math.Atan(Direction.Z / Direction.X);
            } 
            set { 
                var angle = value;
                Direction.X = (float)Math.Cos(angle);
                Direction.Z = (float)Math.Sin(angle);
            } 
        }


        //internal Vector3 Direction
        //{
        //    get
        //    {
        //        var v = new Vector3();
        //        v.X = (float)Math.Sin(Angle);
        //        v.Y = .5f;
        //        v.Z = (float)Math.Cos(Angle) ;

        //        return v;
        //    }
        //}

        public Player()
        {
            Position = new Vector3(0f, .5f, 0f);
            Direction = new Vector3(0f, .5f, 1f);
            
            //Direction = new Vector3(0f, .5f, 1f);
        }

       public void Update(GameTime gameTime)
       {
           if (Keyboard.GetState().IsKeyDown(Keys.D))
           {
               Position.X -= 0.1f;
               Direction.X -= 0.1f;
           }
           if (Keyboard.GetState().IsKeyDown(Keys.A))
           {
               Position.X += 0.1f;
               Direction.X += 0.1f;
           }
           if (Keyboard.GetState().IsKeyDown(Keys.W))
           {
               Position.Z += 0.1f;
               Direction.Z += 0.1f;
           }
           if (Keyboard.GetState().IsKeyDown(Keys.S))
           {
               Position.Z -= 0.1f;
               Direction.Z -= 0.1f;
           }

           if (Keyboard.GetState().IsKeyDown(Keys.Q))
           {
               Angle -= 0.05f;
           }

               
           if (Keyboard.GetState().IsKeyDown(Keys.E))
           {
               Angle += 0.05f;
           }
           
       }
    }
}
