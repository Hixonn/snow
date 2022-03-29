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
    int textY = -30;
    int textX = Raylib.GetScreenWidth() / 2;



    public Snow(int sizeVariety, int speedVariety, int scale)
    {

        Raylib.DrawText("SNOW", textX - 10, textY, 30, Color.RED);

        for (int i = 0; i < 1000; i++)
        {
            int size = ranNum.Next(10, Convert.ToInt32(sizeVariety) + 10);
            int speed = size + ranNum.Next(5, Convert.ToInt32(speedVariety) + 5);

            size += scale;

            int x = xRand.Next(Raylib.GetScreenWidth());
            int y = yRand.Next(Raylib.GetScreenHeight());

            snowFlakes.Add(new Rectangle(x, y, size, size));
            snowSpeeds.Add(speed);
        }

        Raylib.DrawText("SNOW", textX - 10, textY, 30, Color.BLACK);
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


            float diff = _snowFlakes.x - Raylib.GetMouseX();

            if (MathF.Abs(diff) < 100)
            {
                int t = diff > 0 ? 1 : -1;

                if (_snowFlakes.x > Raylib.GetMouseX() - 20 || _snowFlakes.x < Raylib.GetMouseX() + 20)
                {
                    _snowFlakes.x += Convert.ToInt32((5 / (MathF.Abs(diff)) * t));
                }
            }

            snowFlakes[i] = _snowFlakes;

            Raylib.DrawRectangleRec(snowFlakes[i], Color.WHITE);
        }
        textY += 10;
        Raylib.DrawText("SNOW", textX - 140, textY, 100, Color.WHITE);

    }
}
