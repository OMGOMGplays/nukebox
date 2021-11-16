namespace Sandbox.Tools
{
	[Library( "shooter_tsarprotombashooter", Title = "Tsar Protomba Shooter", Description = "Shoot a bunch of OMGplays' mom's", Group = "fun" )]
	public class TsarProtombaShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootTsarBomba();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
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
				Position = Owner.EyePos + Owner.EyeRot.Forward * 150,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/bombs/tsarprotomba.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 2000;
		}
	}
}
