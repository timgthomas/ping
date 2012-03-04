using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Game
{
	public class Paddle : DrawableGameComponent
	{
		private readonly Ping _ping;

		private Texture2D _texture;

		private Vector2 _position;

		public Paddle(Ping game, float location) : base(game)
		{
			_ping = game;
			_position = new Vector2(location, 10f);
		}

		protected override void LoadContent()
		{
			_texture = Game.Content.Load<Texture2D>("paddle");
		}

		public override void Draw(GameTime gameTime)
		{
			_ping.SpriteBatch.Begin();
			_ping.SpriteBatch.Draw(_texture, _position, Color.White);
			_ping.SpriteBatch.End();
		}
	}
}