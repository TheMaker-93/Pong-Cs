using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.Window;

namespace Pong
{
	public class Paddle : RectangleShape
	{

		int posX;
		int posY;
		int width;
		int height;

		public Paddle(int player)
		{
			height = 60;
			posY = 240 - height / 2;
			width = 10;

			if (player == 1)
			{
				posX = 20;
			}
			else if (player == 2)
			{
				posX = 640 - 20 - width;
			}

			Position = new Vector2f(posX, posY);
			Size = new Vector2f(width, height);
		}


		public void Movement(int player)
		{

			Vector2f delta = new Vector2f(0, 0);
			int speed = 6;

			if (player == 1)
			{
				if (Keyboard.IsKeyPressed(Keyboard.Key.W) && Position.Y > 0)
				{
					delta = new Vector2f(0, -speed);

				}
				else if (Keyboard.IsKeyPressed(Keyboard.Key.S) && Position.Y < 480 - this.height)
				{
					delta = new Vector2f(0, +speed);

				}
			}
			else if (player == 2)
			{

				if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && Position.Y > 0)
				{
					delta = new Vector2f(0, -speed);

				}
				else if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && Position.Y < 480 - this.height)
				{
					delta = new Vector2f(0, +speed);

				}

			}

			Position = Position + delta;

		}



	}

}