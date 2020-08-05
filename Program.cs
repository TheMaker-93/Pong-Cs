using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.Window;

namespace Pong
{
	class MainClass
	{

		public static void Main(string[] args)
		{

			VideoMode vMode = new VideoMode(640, 480);
			RenderWindow rWindow = new RenderWindow(vMode, "Pong");     // creamos la ventana de juego
			rWindow.SetFramerateLimit(60);

			HUD hud = new HUD();

			bool playing;


			RectangleShape line = new RectangleShape();
			line.Size = new Vector2f(2, 480);
			line.Position = new Vector2f(640 / 2, 0);
			line.FillColor = new Color(Color.White);


			Text player1_Score;
			Text player2_Score;
			Font fuente = new Font("Data/consola.ttf");

			player1_Score = new Text(hud.GetHudScore(1), fuente,65);
			player1_Score.Position = new Vector2f(160, 10);
			player2_Score = new Text(hud.GetHudScore(2), fuente,65);
			player2_Score.Position = new Vector2f(480, 10);


			Paddle paddle1 = new Paddle(1);
			Paddle paddle2 = new Paddle(2);

			paddle1.FillColor = new Color(Color.White);
			paddle2.FillColor = new Color(Color.White);


			Ball ball = new Ball();
			ball.FillColor = new Color(Color.White);


			playing = true;
			while (playing) {

				playing = CheckForEnd(hud);

				player1_Score = new Text(hud.GetHudScore(1), fuente, 65);
				player1_Score.Position = new Vector2f(160, 10);
				player2_Score = new Text(hud.GetHudScore(2), fuente, 65);
				player2_Score.Position = new Vector2f(480, 10);

				paddle1.Movement(1);    
				paddle2.Movement(2);    

				SendPaddlePosition(paddle1, paddle2);
				ball.Movement();

				rWindow.Draw(line);
				rWindow.Draw(ball);
				rWindow.Draw(paddle1);
				rWindow.Draw(paddle2);
				rWindow.Draw(player1_Score);
				rWindow.Draw(player2_Score);

				rWindow.Display();
				rWindow.Clear(Color.Black);

			}

			rWindow.Close();

		}

		public static void SendPaddlePosition(Paddle pd1, Paddle pd2)
		{
			Ball._paddle1 = pd1;
			Ball._paddle2 = pd2;

		}

		public static bool CheckForEnd (HUD hud)
		{
			if (hud.GetHudScore(1) == "10" || hud.GetHudScore(2) == "10")
			{
				return false;
			}
			else
			{
				return true;
			}
		}


	}





}
