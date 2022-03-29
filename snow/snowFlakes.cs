using System;
using System.Collections.Generic;
using Raylib_cs;


public class Snow
{
    List<Rectangle> snowFlakes = new List<Rectangle>();
    List<float> snowSpeeds = new List<float>();
    Random yRand = new Random(1080);
    Random xRand = new Random(1920);
    Random ranNum = new Random(100);
    public Snow(int sizeVariety, int speedVariety, int scale)
    {
        for (int i = 0; i < 1000; i++)
        {
            int size = ranNum.Next(5, Convert.ToInt32(sizeVariety) + 5);
            int speed = size + ranNum.Next(5, Convert.ToInt32(speedVariety) + 5);

            size += scale;

            int x = xRand.Next(Raylib.GetScreenWidth());
            int y = yRand.Next(Raylib.GetScreenHeight());

            snowFlakes.Add(new Rectangle(x, y, size, size));
            snowSpeeds.Add(speed);
        }
    }

    public void Draw(int sizeVariety, int speedVariety, int scale)
    {
        for (int i = 0; i < snowFlakes.Count; i++)
        {
            Rectangle _snowFlakes = snowFlakes[i];

            if (_snowFlakes.y > Raylib.GetScreenHeight())
            {
                _snowFlakes = snowFlakes[i];

                _snowFlakes.width = ranNum.Next(5, Convert.ToInt32(sizeVariety) + 5);
                snowSpeeds[i] = _snowFlakes.width + ranNum.Next(1, Convert.ToInt32(speedVariety) + 1) - ranNum.Next(1, Convert.ToInt32(speedVariety) + 1);

                _snowFlakes.height = _snowFlakes.width;
                _snowFlakes.x = xRand.Next(Raylib.GetScreenWidth() + Convert.ToInt32(_snowFlakes.width));
                _snowFlakes.y = -yRand.Next(Raylib.GetScreenHeight());

                snowFlakes[i] = _snowFlakes;
            }

            _snowFlakes.y += snowSpeeds[i];
            _snowFlakes.width += scale;
            _snowFlakes.x -= scale / 2;
            snowFlakes[i] = _snowFlakes;

            Raylib.DrawRectangleRec(snowFlakes[i], Color.WHITE);
        }


    }
}
