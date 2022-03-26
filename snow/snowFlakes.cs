using System;
using System.Collections.Generic;
using Raylib_cs;


public class snowFlakes
{
    List<Rectangle> snowFlakeList = new List<Rectangle>();
    List<float> snowSpeedList = new List<float>();
    Random yRand = new Random();
    Random xRand = new Random();
    Random ranNum = new Random();

    public snowFlakes(int numOfFlakes, int _sizeVariety, int _speedVariety)
    {
        for (int i = 0; i < numOfFlakes; i++)
        {
            int size = ranNum.Next(1, Convert.ToInt32(_sizeVariety) + 10);
            int speed = size * ranNum.Next(-10, Convert.ToInt32(_speedVariety) + 10);

            int x = xRand.Next(Raylib.GetScreenWidth());
            int y = yRand.Next(Raylib.GetScreenHeight());

            snowFlakeList.Add(new Rectangle(x, y, size, size));
            snowSpeedList.Add(speed);
        }
    }

    public void Draw(int _sizeVariety, int _speedVariety)
    {
        for (int i = 0; i < snowFlakeList.Count; i++)
        {
            Rectangle flake = snowFlakeList[i];

            snowSpeedList[i] = flake.width + ranNum.Next(0, Convert.ToInt32(_speedVariety));
            flake.height = flake.width;
            flake.y += snowSpeedList[i];
            snowFlakeList[i] = flake;

            if (flake.y > Raylib.GetScreenHeight())
            {

                flake = snowFlakeList[i];
                flake.width = ranNum.Next(1, Convert.ToInt32(_sizeVariety) + 10);
                flake.x = xRand.Next(-Convert.ToInt32(flake.width), Raylib.GetScreenWidth());
                flake.y = -yRand.Next(Raylib.GetScreenHeight());
                snowFlakeList[i] = flake;
                Raylib.DrawRectangleRec(snowFlakeList[i], Color.WHITE);
            }
            Raylib.DrawRectangleRec(snowFlakeList[i], Color.WHITE);
        }
    }
}
