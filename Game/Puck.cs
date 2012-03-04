using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Game
{
	public class Puck : DrawableGameComponent
	{
		private readonly Ping _ping;

		private Texture2D _texture;

		public Puck(Ping game) : base(game)
		{
			_ping = game;
		}

		protected override void LoadContent()
		{
			_texture = Game.Content.Load<Texture2D>("puck");

			base.LoadContent();
		}

		public override void Draw(GameTime gameTime)
		{
			_ping.SpriteBatch.Begin();

			_ping.SpriteBatch.Draw(_texture, Vector2.Zero, Color.White);

			_ping.SpriteBatch.End();
		}
	}
}