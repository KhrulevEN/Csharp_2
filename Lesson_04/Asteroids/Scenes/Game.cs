using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids.Scenes
{
    public class Game : BaseScene
    {
        private int _countAsteroid;
        static List<BaseObject> _asteroids = new List<BaseObject>();
        private BaseObject[] _stars;
        //private BaseObject[] _healths;        
        private BaseObject _health;
        //static List<BaseObject> _health = new List<BaseObject>();
        static List<Bullet> _bullets = new List<Bullet>();
        private Ship _ship;
        private Timer _timer;
        private Random random = new Random();

        public override void Init(Form form, int countAsteroid)
        {
            base.Init(form, countAsteroid);
            _countAsteroid = countAsteroid;
            Load();

            _timer = new Timer { Interval = 60 };
            _timer.Start();
            _timer.Tick += Timer_Tick;
            Ship.DieEvent += Finish;            
        }

        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                if (_bullets.Count < 5)
                    _bullets.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 21), new Point(5, 0), new Size(54, 9)));
            }
            if (e.KeyCode == Keys.Up)
            {
                _ship.Up();
            }
            if (e.KeyCode == Keys.Down)
            {
                _ship.Down();
            }
            if (e.KeyCode == Keys.Left)
            {
                _ship.Left();
            }
            if (e.KeyCode == Keys.Right)
            {
                _ship.Right();
            }
            if (e.KeyCode == Keys.Back)
            {                
                SceneManager
                    .Get()
                    .Init<MenuScene>(_form, _countAsteroid)
                    .Draw();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public override void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            foreach (var obj in _stars)
                obj.Draw();

            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, new Size(200, 200)), 100, 100);

            foreach (var asteroid in _asteroids)
                if (asteroid != null)
                    asteroid.Draw();

            foreach (var bullet in _bullets)
                bullet.Draw();

            if (_ship != null)
            {
                _ship.Draw();
                Buffer.Graphics.DrawString($"Energy: {_ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
            }

            Buffer.Graphics.DrawString($"Количество астероидов {_asteroids.Count}", SystemFonts.DefaultFont, Brushes.White, 0, 15);//_asteroids.Length
            if (_asteroids.Count == 0)
            {
                _timer.Enabled = false;
                Buffer.Graphics.DrawString("You win!!!", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.Yellow, 180, 100);
                Buffer.Graphics.DrawString("<Backspace> - в меню", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.Yellow, 80, 200);
                _countAsteroid++;
            }

            _health.Draw();


            Buffer.Render();
        }

        public void Load()
        {
             _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(45, 50));
            Ship.DieEvent += Finish;

            var random = new Random();            
            //var countAteroids = random.Next(25, 30);

            for (int i = 0; i < _countAsteroid; i++)
            {
                var sizeAsteroid = random.Next(30, 40);
                var speedAsteroid = random.Next(5, 15);
                _asteroids.Add(new Asteroid(new Point(750, i * (600 / _countAsteroid)), new Point(-speedAsteroid, 0), new Size(sizeAsteroid, sizeAsteroid)));
            }
            _stars = new Star[20];
            for (int i = 0; i < _stars.Length; i++)
                _stars[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(3, 3));

            var speedHealth = random.Next(3, 8);
            var sizeHealth = random.Next(30, 40);
            var xHealth = random.Next(300, 700);
            var yHealth = random.Next(100, 500);
            _health = new Health(new Point(xHealth, yHealth), new Point(-speedHealth, 0), new Size(sizeHealth, sizeHealth));
            
        }

        public void Update()
        {
            // Пройдемся по всем астероидам ( с конца в начало)
            for (var i = _asteroids.Count - 1; i >= 0; i--)
            {
                // Проверим столкновение с кораблем
                if (_asteroids[i].Collision(_ship))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    _ship.EnergyLow(random.Next(10, 15));
                    if (_ship.Energy <= 0)
                        _ship.Die();
                    _asteroids.RemoveAt(i);
                }
                else
                {
                    // Проверим столкновение с пулей
                    for (var j = _bullets.Count - 1; j >= 0; j--)
                    {
                        if (_asteroids[i].Collision(_bullets[j]))
                        {
                            System.Media.SystemSounds.Hand.Play();
                            _asteroids.RemoveAt(i);
                            _bullets.RemoveAt(j);
                            break;
                        }
                    }
                }
            }

            // Проверка пули (за пределами экрана)
            for (var j = _bullets.Count - 1; j >= 0; j--)
            {
                if (_bullets[j].Rect.X > Game.Width)
                {
                    _bullets.RemoveAt(j);
                }
            }

            if (_ship != null && _ship.Collision(_health))
            {
                _ship.EnergyHigh(random.Next(1, 10));
                System.Media.SystemSounds.Hand.Play();
                _health.Die();
            }

            foreach (var stars in _stars)
                stars.Update();

            foreach (var asteroids in _asteroids)
                asteroids.Update();

            foreach (var bullet in _bullets)
                bullet.Update();


            _health.Update();

        }

        private void Finish(object sender, EventArgs e)
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.White, 180, 100);
            Buffer.Graphics.DrawString("<Backspace> - в меню", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 80, 200);
            Buffer.Render();
        }

        public override void Dispose()
        {
            base.Dispose();
            _timer.Stop();
        }

    }
}
