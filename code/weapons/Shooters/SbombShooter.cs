using Sandbox;
using Sandbox.Tools;

namespace Nukebox.tools.Shooters
{
	[Library( "shooter_sbombshooter", Title = "S&bomb Shooter", Description = "KEYS FOR EVERYONE!!!", Group = "fun" )]
	public class SbombShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					ShootSbomb();
				}

				if ( Input.Down( InputButton.SecondaryAttack ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootSbomb();
				}
			}
		}

		void ShootSbomb()
		{
			var ent = new Prop
			{
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 100,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( "models/bombs/sbomb.vmdl" );
			ent.Velocity = Owner.EyeRotation.Forward * 2000;
		}
	}
}
