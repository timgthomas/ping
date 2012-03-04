using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Game
{
	public class Paddle : DrawableGameComponent
	{
		private readonly Ping _ping;

		private Texture2D _texture;

		private Vector2 _size;
		private Vector2 _position;
		private Vector2 _velocity;

		private bool _movingUp;
		private bool _movingDown;

		public Paddle(Ping game, float location) : base(game)
		{
			_ping = game;

			_size = new Vector2(24f, 88f);
			_position = new Vector2(location, 10f);
			_velocity = new Vector2(0f);
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

		public override void Update(GameTime gameTime)
		{
			const float maxSpeed = 5f;

			_velocity.Y = 0;

			if (_movingUp && _position.Y > 8)
			{
				_velocity.Y = _velocity.Y - maxSpeed;
			}

			if (_movingDown && _position.Y < _ping.ScreenHeight - _size.Y - 8)
			{
				_velocity.Y = _velocity.Y + maxSpeed;
			}

			_position = _position + _velocity;
		}

		public Rectangle GetBoundingBox()
		{
			return new Rectangle((int)_position.X, (int)_position.Y, (int)_size.X, (int)_size.Y);
		}

		public void MoveUp()
		{
			_movingUp = true;
		}

		public void StopMovingUp()
		{
			_movingUp = false;
		}

		public void MoveDown()
		{
			_movingDown = true;
		}

		public void StopMovingDown()
		{
			_movingDown = false;
		}
	}
}