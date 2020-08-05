using System;
using SFML.Audio;
using SFML.Graphics;


namespace Pong
{
	public class HUD
	{

		public static int player1_Score;
		public static int player2_Score;

		SoundBuffer sb = new SoundBuffer("Data/coll1.wav");        
		Sound pointSound;

		public HUD()
		{
			player1_Score = 0;
			player2_Score = 0;

			pointSound = new Sound(sb); 
			pointSound.Pitch = 0.4f;
		}

		public void IncreasePlayerScore(int player)
		{
			pointSound.Play();

			if (player == 1 || player == 2)
			{
				if (player == 1)
				{
					player1_Score++;
				}
				else if (player == 2)
				{
					player2_Score++;
				}

			}

		}

		public string GetHudScore(int player)
		{
			if (player == 1) return player1_Score.ToString();
			else if (player == 2) return player2_Score.ToString();
			else
			{
				return ("ERROR");
			}
		}

	}
}
