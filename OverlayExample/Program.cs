using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using HijackOverlay;
using HijackOverlay.Render;
using HijackOverlay.Render.Font;
using Application = System.Windows.Application;

namespace OverlayExample
{
    internal class Program : Application
    {
        public static void Main(string[] args)
        {
            var width = Screen.PrimaryScreen.Bounds.Width;
            var height = Screen.PrimaryScreen.Bounds.Height;
            var overlay = new Overlay(width, height);
            var draw = true;

            var rainbow = new[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet };
            var test = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789?!";
            var font = new FontRenderer("Arial", 32);
            var font2 = new FontRenderer("Arial", 64);
            var font3 = new FontRenderer("Arial", 300);
            var font4 = new FontRenderer("Bahnschrift", 64);
            var font5 = new FontRenderer("Algerian", 64);

            while (draw)
            {
                Thread.Sleep(1);

                overlay.StartDraw(0, 0, width, height);

                var bufferBuilder = Renderer.StartPositionColorTris();
                Renderer.BufferColorRect(bufferBuilder, 800, 300, 300, 300, Color.Red);
                Renderer.BufferColorRect(bufferBuilder, 300, 300, 300, 300, Color.Black);
                Renderer.BufferColorRect(bufferBuilder, 1300, 300, 300, 300, Color.Black);
                Renderer.BufferColorRect(bufferBuilder, 0, 0, 100, 100, Color.Red);
                Renderer.BufferColorRect(bufferBuilder, width - 100, height - 100, 100, 100, Color.Red);
                Renderer.End(bufferBuilder);

                bufferBuilder = Renderer.StartPositionColorLines();
                Renderer.BufferColorLine(bufferBuilder, 300, 300, 600, 600, rainbow);
                Renderer.BufferColorGradientLineGroup(bufferBuilder,
                    new float[] { 1300, 1600, 1400, 1500, 1400, 1500, 1400, 1500, 1400 },
                    new float[] { 300, 600, 300, 343, 386, 429, 472, 515, 558 },
                    new float[] { 1300, 1600, 1500, 1400, 1500, 1400, 1500, 1400, 1500 },
                    new float[] { 600, 300, 343, 386, 429, 472, 515, 558, 600 },
                    rainbow);
                Renderer.End(bufferBuilder);

                font5.DrawString("This is a test text.", 300, 900, rainbow);
                font4.DrawString("This is a test text.", 300, 800, Color.Blue, Color.Purple);
                font3.DrawString("Large Test", 300, 1000, Color.Black);
                font2.DrawString(test, 300, 1350, Color.Red);
                font.DrawString(test, 300, 1450, Color.Aqua, Color.Blue);

                overlay.EndDraw();
            }
        }
    }
}