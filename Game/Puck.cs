using System;
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

		private double _secondsSinceLastFrameTick;
		private int _frameIndex;

		public Puck(Ping game, Vector2 position) : base(game)
		{
			_ping = game;

			_size = new Vector2(32f, 32f);
			_position = position;
			_velocity = new Vector2(5f);
		}

		protected override void LoadContent()
		{
			_texture = Game.Content.Load<Texture2D>("puck");
		}

		public override void Draw(GameTime gameTime)
		{
			var textureFrame = new Rectangle(0, 32 * _frameIndex, 32, 32);

			_ping.SpriteBatch.Begin();
			_ping.SpriteBatch.Draw(_texture, _position, textureFrame, Color.White);
			_ping.SpriteBatch.End();

			if (gameTime.TotalGameTime.TotalSeconds - _secondsSinceLastFrameTick < 0.0625f) return;
			_frameIndex++;
			if (_frameIndex > 7) _frameIndex = 0;

			_secondsSinceLastFrameTick = gameTime.TotalGameTime.TotalSeconds;
		}

		public override void Update(GameTime gameTime)
		{
			if (!_ping.GameRunning) return;

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