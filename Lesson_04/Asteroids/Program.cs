﻿using Asteroids.Scenes;
using System;
using System.Windows.Forms;

namespace Asteroids
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var form = new Form()
            {
                MinimumSize = new System.Drawing.Size(800, 600),
                MaximumSize = new System.Drawing.Size(800, 600),
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Asteroids"
            };
            form.Show();

            SceneManager
                .Get()
                .Init<MenuScene>(form, 5)
                .Draw();

            Application.Run(form);
        }
    }
}
