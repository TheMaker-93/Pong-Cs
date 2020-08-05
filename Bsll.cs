using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.Window;

namespace Pong
{
	public class Ball : CircleShape
	{
		HUD hud = new HUD();

		float sp;        
		float startingSpeed;
		float maxSp;
		float deltaSp;

		public static Paddle _paddle1;
		public static Paddle _paddle2;

		Vector2f direction = new Vector2f(1f, 1f);     
		Random alea = new Random();

		SoundBuffer sb = new SoundBuffer("Data/collBorder.wav");
		Sound borderColl;
		SoundBuffer sb2 = new SoundBuffer("Data/coll1.wav");        
		Sound paddleColl;

		public Ball()
		{
			Radius = 8f;
			Position = new Vector2f(640 / 2 - Radius, 480 / 2 - Radius);

			sp = 4f;
			startingSpeed = sp;

			maxSp = 10f;
			deltaSp = sp * 0.1f;

			borderColl = new Sound(sb);
			paddleColl = new Sound(sb2);

		}

		private void ResetPosition()
		{
			Position = new Vector2f(640 / 2 - Radius, 480 / 2 - Radius);
			SetRandomDirection(ref direction, alea);
			sp = startingSpeed;
			RestartMovement();
		}

		private void RestartMovement()
		{
			bool move = false;
			while (move == false)
			{
				if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
				{
					move = true;
				}
			}
		}


		public void Movement()
		{

			if (Position.Y <= 0f || Position.Y + 2 * Radius >= 480)
			{
				IncreaseBallSpeed();
				borderColl.Play();
			}

			if (Position.X <= 0f || Position.X + 2 * Radius >= 640)
			{
				IncreaseBallSpeed();
				direction.X = -1 * direction.X;     

				if (Position.X <= 0f)
				{
					hud.IncreasePlayerScore(2);
					ResetPosition();
				}
				else if (Position.X + 2 * Radius >= 640)
				{
					hud.IncreasePlayerScore(1);
					ResetPosition();
				}

			}

			if (Position.Y <= 0f || Position.Y + 2 * Radius >= 480)
			{
				direction.Y = -1 * direction.Y ;		
			}

			if ( (Position.X <= _paddle1.Position.X + _paddle1.Size.X && ( Position.Y >= _paddle1.Position.Y &&  Position.Y + Radius*2 <= _paddle1.Position.Y + _paddle1.Size.Y )) || 
			    ( Position.X + Radius * 2 >= _paddle2.Position.X && ( Position.Y >= _paddle2.Position.Y && Position.Y + 2*Radius <= _paddle2.Position.Y + _paddle2.Size.Y))  )
			{

				if (Position.X <= _paddle1.Position.X + _paddle1.Size.X && 
				    (Position.Y >= _paddle1.Position.Y && 
				     Position.Y + 2*Radius <= _paddle1.Position.Y + _paddle1.Size.Y))
				{
					
					paddleColl.Play();

					//
					Position = new Vector2f(_paddle1.Position.X + _paddle1.Size.X, Position.Y);
					//
				}
				else if (Position.X + Radius * 2 >= _paddle2.Position.X && 
				         (Position.Y >= _paddle2.Position.Y && 
				          Position.Y + 2*Radius <= _paddle2.Position.Y + _paddle2.Size.Y)) 
				{

					paddleColl.Play();

					// 
					Position = new Vector2f(_paddle2.Position.X - 2 * Radius, Position.Y);
					//
				}

				direction.X = -1 * direction.X;
			}

			Position = new Vector2f(Position.X + direction.X * sp, Position.Y + direction.Y * sp);

		}

		public static void SetRandomDirection(ref Vector2f dir, Random rd)
		{
			int dirX = rd.Next(-1, 2);
           	int dirY = rd.Next(-1, 2);

			while (dirX == 0 || dirY == 0)
			{
				dirX = rd.Next(-1, 2);
				dirY = rd.Next(-1, 2);
			}

			dir.X = dirX;
			dir.Y = dirY;
		}

		public void IncreaseBallSpeed()
		{
			if (sp <= maxSp)
			{
				sp += deltaSp;
			}
		}



	}
}
