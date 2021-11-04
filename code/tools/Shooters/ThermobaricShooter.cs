namespace Sandbox.Tools
{
	[Library( "shooter_thermobaricshooter", Title = "Thermobaric Bomb Shooter", Description = "haha, explosion goes Boom... BOOM", Group = "fun" )]
	public class ThermobaricShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootThermo();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
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
				Position = Owner.EyePos + Owner.EyeRot.Forward * 100,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/bombs/thermobaricbomb.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 2000;
		}
	}
}
