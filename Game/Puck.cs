using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Game
{
	public class Puck : DrawableGameComponent
	{
		private readonly Ping _ping;

		private Texture2D _texture;

		private Vector2 _position;
		private Vector2 _velocity;

		public Puck(Ping game) : base(game)
		{
			_ping = game;

			_position = new Vector2(10.0f, 10.0f);
			_velocity = new Vector2(1.0f, 1.0f);
		}

		protected override void LoadContent()
		{
			_texture = Game.Content.Load<Texture2D>("puck");
		}

		public override void Draw(GameTime gameTime)
		{
			_ping.SpriteBatch.Begin();
			_ping.SpriteBatch.Draw(_texture, _position, Color.White);
			_ping.SpriteBatch.End();
		}

		public override void Update(GameTime gameTime)
		{
			_position = _position + _velocity;
		}
	}
}