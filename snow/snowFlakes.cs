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



    public Snow(int sizeVariety, int scaleY, int scaleX, int numOfFlakes)
    {

        Raylib.DrawText("SNOW", textX - 10, textY, 30, Color.RED);

        for (int i = 0; i < numOfFlakes; i++)
        {
            int size = Convert.ToInt32(i / 500 * sizeVariety * sizeVariety / 20) + 2;
            int speed = size;

            size += scaleX;

            int x = xRand.Next(Raylib.GetScreenWidth());
            int y = yRand.Next(Raylib.GetScreenHeight());

            snowFlakes.Add(new Rectangle(x, y, size, size));
            snowSpeeds.Add(speed);
        }
    }

    public void Draw(int sizeVariety, int scaleY, int scaleX)
    {
        textY += 10;
        int textSize = 200;
        int textXOffset = (textSize / 7) * 10;
        Raylib.DrawText("SNOW", textX - textXOffset - 2, textY, textSize, Color.BLACK);
        Raylib.DrawText("SNOW", textX - textXOffset + 2, textY, textSize, Color.BLACK);
        Raylib.DrawText("SNOW", textX - textXOffset - 2, textY - 2, textSize, Color.BLACK);
        Raylib.DrawText("SNOW", textX - textXOffset + 2, textY + 2, textSize, Color.BLACK);
        Raylib.DrawText("SNOW", textX - textXOffset, textY, textSize, Color.WHITE);

        for (int i = 0; i < snowFlakes.Count; i++)
        {
            Rectangle _snowFlakes = snowFlakes[i];

            if (_snowFlakes.y > Raylib.GetScreenHeight())
            {
                _snowFlakes = snowFlakes[i];

                _snowFlakes.width = Convert.ToInt32(i / 500 * sizeVariety * sizeVariety / 100) + 10;
                snowSpeeds[i] = _snowFlakes.width;

                _snowFlakes.height = _snowFlakes.width;
                _snowFlakes.x = xRand.Next(Raylib.GetScreenWidth() + Convert.ToInt32(_snowFlakes.width));
                _snowFlakes.y = -yRand.Next(Raylib.GetScreenHeight());

                snowFlakes[i] = _snowFlakes;
            }


            _snowFlakes.y += snowSpeeds[i] / 2;
            _snowFlakes.width += scaleX;
            _snowFlakes.x -= scaleX / 2;

            float mouseDiff = 5;

            float diffX = _snowFlakes.x - Raylib.GetMouseX();
            float diffY = _snowFlakes.y - Raylib.GetMouseY() - mouseDiff;


            if (MathF.Abs(diffX) - ((_snowFlakes.width / 2) * (_snowFlakes.width / 2) - (100 * scaleX)) < mouseDiff && diffY > -mouseDiff - (((_snowFlakes.width * _snowFlakes.width) - (100 * scaleX)) / 10) && diffY < 1)
            {
                int tX = diffX >= 0 ? 1 : -1;

                _snowFlakes.x += (Convert.ToSingle((MathF.Abs(diffY - mouseDiff) + (300 / diffX) + scaleY) / (MathF.Abs(diffX * scaleY + (_snowFlakes.width * (scaleX * scaleX)) + mouseDiff)) * tX * (_snowFlakes.width * _snowFlakes.width) / 5));
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
    }
}
