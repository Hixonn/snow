using System;
using System.Collections.Generic;
using Raylib_cs;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int globalIndent = 10;

            Raylib.InitWindow(Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), "balls");
            Raylib.SetTargetFPS(60);
            Raylib.ToggleFullscreen();

            List<Slider> sliderList = new List<Slider>();

            sliderList.Add(new Slider(0, 5, Convert.ToInt32((Raylib.GetScreenWidth() / 7) * 6), 100, 100, globalIndent));
            sliderList.Add(new Slider(0, 120, sliderList[0].Bar.width, 100, 30, globalIndent, 0));

            snowFlakes snow = new snowFlakes(1000, sliderList[0].SliderValue, sliderList[1].SliderValue);

            while (Raylib.WindowShouldClose() == false)

            {

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLUE);

                for (int i = 0; i < sliderList.Count; i++)
                {
                    sliderList[i].Update();
                    sliderList[i].Draw();
                }

                snow.Draw(sliderList[0].SliderValue, sliderList[1].SliderValue);

                Raylib.EndDrawing();

            }
        }
    }
}
