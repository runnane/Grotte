using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Grotte
{

    enum BlockType { leaves, dirt, wood };


    public class Block
    {
        float xPos;
        float zPos;

        public VertexPositionColor[] vertices;
        public short[] indexes;

        public Block(float x, float z, Color color)
        {
            Color c = color;
            //Color.A = 0xff;
            indexes = new short[14];
            vertices = new VertexPositionColor[8];
            xPos = x;
            zPos = z;
            float y = 0f;

            // Bottom side
            vertices[0].Position = new Vector3(x + 1f, y, z);
            vertices[1].Position = new Vector3(x + 1f, y, z + 1f);
            vertices[2].Position = new Vector3(x, y, z);
            vertices[3].Position = new Vector3(x, y, z + 1f);
            vertices[4].Position = new Vector3(x, y + 1f, z);
            vertices[5].Position = new Vector3(x, y + 1f, z + 1f);
            vertices[5].Position = new Vector3(x, y + 1f, z + 1f);
            vertices[5].Position = new Vector3(x, y + 1f, z + 1f);

            vertices[0] = new VertexPositionColor(new Vector3(x + 1.0f, y - 1.0f, z + 1.0f), color);
            vertices[1] = new VertexPositionColor(new Vector3(x + 1.0f, y - 1.0f, z - 1.0f), color);
            vertices[2] = new VertexPositionColor(new Vector3(x - 1.0f, y - 1.0f, z - 1.0f), color);
            vertices[3] = new VertexPositionColor(new Vector3(x - 1.0f, y - 1.0f, z + 1.0f), color);
            vertices[4] = new VertexPositionColor(new Vector3(x + 1.0f, y + 1.0f, z + 1.0f), color);
            vertices[5] = new VertexPositionColor(new Vector3(x + 1.0f, y + 1.0f, z - 1.0f), color);
            vertices[6] = new VertexPositionColor(new Vector3(x - 1.0f, y + 1.0f, z - 1.0f), color);
            vertices[7] = new VertexPositionColor(new Vector3(x - 1.0f, y + 1.0f, z + 1.0f), color);



            indexes[0] = 1;
            indexes[1] = 2;
            indexes[2] = 0;
            indexes[3] = 3;
            indexes[4] = 7;
            indexes[5] = 6;
            indexes[6] = 2;
            indexes[7] = 5;
            indexes[8] = 1;
            indexes[9] = 4;
            indexes[10] = 0;
            indexes[11] = 7;
            indexes[12] = 5;
            indexes[13] = 6;

            // south side z-5


            // west side x+5


            // east side x-5
        }

        public void Draw(GameTime gameTime, GraphicsDevice device)
        {
            device.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, vertices, 0, vertices.Length, indexes, 0, indexes.Length - 2);
        }

    }
}
