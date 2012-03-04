using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Game
{
	public class Puck : DrawableGameComponent
	{
		private readonly Ping _ping;

		private Texture2D _texture;

		private Vector2 _size;
		private Vector2 _position;
		private Vector2 _velocity;

		public Puck(Ping game) : base(game)
		{
			_ping = game;

			_size = new Vector2(32f, 32f);
			_position = new Vector2(10f, 10f);
			_velocity = new Vector2(5f);
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
			if (_position.Y < 0 || (_position.Y + _size.Y) > _ping.ScreenHeight)
			{
				_velocity.Y = -_velocity.Y;
			}

			if (_position.X < 0)
			{
				ReflectHorizontally();

				_ping.SideHit(PlayerIndex.Two);
			}

			if (_position.X + _size.X > _ping.ScreenWidth)
			{
				_velocity.X = -_velocity.X;

				_ping.SideHit(PlayerIndex.One);
			}

			_position = _position + _velocity;
		}

		public Rectangle GetBoundingBox()
		{
			return new Rectangle((int)_position.X, (int)_position.Y, (int)_size.X, (int)_size.Y);
		}

		public void ReflectHorizontally()
		{
			_velocity.X = -_velocity.X;
		}
	}
}