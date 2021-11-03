namespace Sandbox.Tools
{
	[Library( "shooter_atomicrainbombshooter", Title = "Atomic Rainbomb Shooter", Description = "Shoot rainbows eveyrwhere!!!", Group = "fun" )]
	public class AtomicRainbombShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootAtomicRainbomb();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootAtomicRainbomb();
				}
			}
		}

		void ShootAtomicRainbomb()
		{
			var ent = new Prop
			{
				Position = Owner.EyePos + Owner.EyeRot.Forward * 100,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/bombs/atomicrainbomb.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 2000;
		}
	}
}
