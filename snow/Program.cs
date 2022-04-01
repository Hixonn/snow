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

            Raylib.InitWindow(1920, 1080, "Snow");
            Raylib.SetTargetFPS(120);
            Raylib.ToggleFullscreen();

            List<Slider> sliderList = new List<Slider>();

            sliderList.Add(new Slider(15, -230 + Raylib.GetScreenHeight(), Convert.ToInt32((Raylib.GetScreenWidth() / 7) * 6), 100, 25, globalIndent, 20));
            sliderList.Add(new Slider(15, -120 + Raylib.GetScreenHeight(), sliderList[0].Bar.width, 50, 20, globalIndent, 15));
            sliderList.Add(new Slider(15, -60 + Raylib.GetScreenHeight(), sliderList[0].Bar.width / 10, 50, 1, globalIndent, 0));

            Snow snow = new Snow(sliderList[0].SliderValue, sliderList[1].SliderValue, sliderList[2].SliderValue * 2, 6000);

            while (Raylib.WindowShouldClose() == false)

            {
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_ALT) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT_ALT)))
                {
                    Raylib.ToggleFullscreen();
                }
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLUE);

                snow.Draw(sliderList[0].SliderValue, sliderList[1].SliderValue, sliderList[2].SliderValue * 2);

                for (int i = 0; i < sliderList.Count; i++)
                {
                    sliderList[i].Update();
                    sliderList[i].Draw();
                }

                Raylib.EndDrawing();

            }
        }
    }
}
