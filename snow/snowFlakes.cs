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



    public Snow(int sizeVariety, int scaleY, int scaleX)
    {

        Raylib.DrawText("SNOW", textX - 10, textY, 30, Color.RED);

        for (int i = 0; i < 5000; i++)
        {
            int size = Convert.ToInt32(i / 500 * sizeVariety) + 5;
            int speed = size;

            size += scaleX;

            int x = xRand.Next(Raylib.GetScreenWidth());
            int y = yRand.Next(Raylib.GetScreenHeight());

            snowFlakes.Add(new Rectangle(x, y, size, size));
            snowSpeeds.Add(speed);
        }

        Raylib.DrawText("SNOW", textX - 10, textY, 30, Color.BLACK);
    }

    public void Draw(int sizeVariety, int scaleY, int scaleX)
    {
        for (int i = 0; i < snowFlakes.Count; i++)
        {
            Rectangle _snowFlakes = snowFlakes[i];

            if (_snowFlakes.y > Raylib.GetScreenHeight())
            {
                _snowFlakes = snowFlakes[i];

                _snowFlakes.width = Convert.ToInt32(i / 500 * sizeVariety / 5) + 5;
                snowSpeeds[i] = _snowFlakes.width;

                _snowFlakes.height = _snowFlakes.width;
                _snowFlakes.x = xRand.Next(Raylib.GetScreenWidth() + Convert.ToInt32(_snowFlakes.width));
                _snowFlakes.y = -yRand.Next(Raylib.GetScreenHeight());

                snowFlakes[i] = _snowFlakes;
            }


            _snowFlakes.y += snowSpeeds[i] / 2;
            _snowFlakes.width += scaleX;
            _snowFlakes.x -= scaleX / 2;

            float mouseDiff = 100;

            float diffX = _snowFlakes.x - Raylib.GetMouseX();
            float diffY = _snowFlakes.y - Raylib.GetMouseY() - mouseDiff;


            if (MathF.Abs(diffX) - (_snowFlakes.width / 2) * (_snowFlakes.width / 2) < mouseDiff && diffY > -mouseDiff && diffY < 1)
            {
                int tX = diffX >= 0 ? 1 : -1;

                _snowFlakes.x += (Convert.ToSingle((MathF.Abs(diffY - mouseDiff) + 500) / (MathF.Abs(diffX * 20) + mouseDiff)) * tX * ((_snowFlakes.width * _snowFlakes.width) / 10));
            }


            snowFlakes[i] = _snowFlakes;

            Rectangle[] snowFlakesBG = new Rectangle[snowFlakes.Count];

            Rectangle balls;
            balls = snowFlakes[i];
            balls.width += 4;
            balls.height += 4;
            balls.x -= 2;
            balls.y -= 2;
            snowFlakesBG[i] = balls;

            Raylib.DrawRectangleRec(snowFlakesBG[i], Color.BLACK);
            Raylib.DrawRectangleRec(snowFlakes[i], Color.WHITE);
        }
        textY += 10;
        Raylib.DrawText("SNOW", textX - 140, textY, 100, Color.WHITE);

    }
}
