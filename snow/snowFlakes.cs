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
    int textY = -250;
    int textX = Raylib.GetScreenWidth() / 2;



    public Snow(int sizeVariety, int speedVariety, int scale)
    {

        Raylib.DrawText("SNOW", textX - 10, textY, 30, Color.RED);

        for (int i = 0; i < 3000; i++)
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


            _snowFlakes.y += snowSpeeds[i] / 2;
            _snowFlakes.width += scale;
            _snowFlakes.x -= scale / 2;

            float mouseDiff = 100;

            float diffX = _snowFlakes.x - (Raylib.GetMouseX() - _snowFlakes.width / 2);
            float diffY = _snowFlakes.y - Raylib.GetMouseY();


            if (MathF.Abs(diffX) < mouseDiff + (_snowFlakes.width * 3) && diffY > -(mouseDiff / 2) && diffY < mouseDiff)
            {
                int tX = diffX >= 0 ? 1 : -1;

                _snowFlakes.x += Convert.ToSingle((3 * _snowFlakes.width) / MathF.Abs(diffX)) * tX;
            }

            snowFlakes[i] = _snowFlakes;

            Raylib.DrawRectangleRec(snowFlakes[i], Color.WHITE);
        }
        textY += 10;
        Raylib.DrawText("SNOW", textX - 140, textY, 100, Color.WHITE);

    }
}
