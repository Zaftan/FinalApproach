using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Physics;

    class MetalWall : PhysicsRectangle
    {
        public MetalWall(int length, int pX, int pY) : base(2, 2, 0, 0)
        {
            build(length);

            x = pX + width / 2;
            y = pY + height / 2;
        }

        void build(int length)
        {
            Sprite body;

            for (int i = 0; i < length;)
            {
                body = new Sprite(Settings.ASSET_PATH + "Art/metal_wall.png");
                //body.SetOrigin(body.width/2, body.height/2);

                body.x = i;

                _height = body.height;

                i += body.width;
                AddChild(body);

                _width = i;
            }
        }
    }

