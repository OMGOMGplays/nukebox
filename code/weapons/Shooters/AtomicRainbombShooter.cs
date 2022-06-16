using Sandbox;

namespace Nukebox.weapons.Shooters
{
	[Library( "shooter_atomicrainbombshooter", Title = "Atomic Rainbomb Shooter", Description = "Shoot rainbows eveyrwhere!!!", Group = "fun" )]
	public class AtomicRainbombShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					ShootAtomicRainbomb();
				}

				if ( Input.Down( InputButton.SecondaryAttack ) && timeSinceShoot > 0.05f )
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
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 100,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( "models/bombs/atomicrainbomb.vmdl" );
			ent.Velocity = Owner.EyeRotation.Forward * 2000;
		}
	}
}
