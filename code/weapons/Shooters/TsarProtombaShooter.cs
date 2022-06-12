using Sandbox;
using Sandbox.Tools;

namespace Nukebox.tools.Shooters
{
	[Library( "shooter_tsarprotombashooter", Title = "Tsar Protomba Shooter", Description = "Shoot a bunch of OMGplays' mom's", Group = "fun" )]
	public class TsarProtombaShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					ShootTsarBomba();
				}

				if ( Input.Down( InputButton.SecondaryAttack ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootTsarBomba();
				}
			}
		}

		void ShootTsarBomba()
		{
			var ent = new Prop
			{
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 150,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( "models/bombs/tsarprotomba.vmdl" );
			ent.Velocity = Owner.EyeRotation.Forward * 2000;
		}
	}
}
