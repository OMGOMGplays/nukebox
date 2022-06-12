using Sandbox;
using Sandbox.Tools;

namespace Nukebox.tools.Shooters
{
	[Library( "shooter_tsarbombashooter", Title = "Tsar Bomba Shooter", Description = "Shoot Tsar Bombas, fuck up the planet", Group = "fun" )]
	public class TsarBombaShooter : BaseTool
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

			ent.SetModel( "models/bombs/tsarbomba.vmdl" );
			ent.Velocity = Owner.EyeRotation.Forward * 2000;
		}
	}
}
