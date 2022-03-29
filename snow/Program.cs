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

            Raylib.InitWindow(1270, 720, "balls");
            Raylib.SetTargetFPS(60);

            List<Slider> sliderList = new List<Slider>();

            sliderList.Add(new Slider(10, 10, Convert.ToInt32((Raylib.GetScreenWidth() / 7) * 6), 100, 100, globalIndent));
            sliderList.Add(new Slider(10, 120, sliderList[0].Bar.width, 50, 5, globalIndent, 0));
            sliderList.Add(new Slider(10, 230, sliderList[0].Bar.width, 50, 5, globalIndent, 0));

            Snow snow = new Snow(sliderList[0].SliderValue, sliderList[1].SliderValue, sliderList[2].SliderValue * 2);

            while (Raylib.WindowShouldClose() == false)

            {

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLUE);

                for (int i = 0; i < sliderList.Count; i++)
                {
                    sliderList[i].Update();
                    sliderList[i].Draw();
                }

                snow.Draw(sliderList[0].SliderValue, sliderList[1].SliderValue, sliderList[2].SliderValue * 2);
                Raylib.EndDrawing();

            }
        }
    }
}
