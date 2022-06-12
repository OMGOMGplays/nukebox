using Sandbox;
using Sandbox.Tools;

namespace Nukebox.tools.Shooters
{
	[Library( "shooter_thermobaricshooter", Title = "Thermobaric Bomb Shooter", Description = "haha, explosion goes Boom... BOOM", Group = "fun" )]
	public class ThermobaricShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					ShootThermo();
				}

				if ( Input.Down( InputButton.SecondaryAttack ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootThermo();
				}
			}
		}

		void ShootThermo()
		{
			var ent = new Prop
			{
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 100,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( "models/bombs/thermobaricbomb.vmdl" );
			ent.Velocity = Owner.EyeRotation.Forward * 2000;
		}
	}
}
