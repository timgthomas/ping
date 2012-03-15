using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Game
{
	public class Messages : DrawableGameComponent
	{
		public const string Empty = "";
		public const string Start = "Press [enter] to start";
		public const string Paused = "Paused";

		private readonly Ping _ping;

		private SpriteFont _monofur;
		private string _message;

		public Messages(Ping ping) : base(ping)
		{
			_ping = ping;
		}

		protected override void LoadContent()
		{
			_monofur = Game.Content.Load<SpriteFont>("verdana");
		}

		public override void Draw(GameTime gameTime)
		{
			var location = new Vector2(
				_ping.ScreenWidth / 2.0f - _monofur.MeasureString(_message).X / 2.0f,
				_ping.ScreenHeight / 2.0f - _monofur.MeasureString(_message).Y / 2.0f);

			_ping.SpriteBatch.Begin();
			_ping.SpriteBatch.DrawString(_monofur, _message, location, Color.White);
			_ping.SpriteBatch.End();
		}

		public void SetMessage(string message)
		{
			_message = message;
		}
	}
}