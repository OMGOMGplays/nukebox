namespace Sandbox.Tools
{
	[Library( "shooter_tsarbombashooter", Title = "Tsar Bomba Shooter", Description = "Shoot Tsar Bombas, fuck up the planet", Group = "fun" )]
	public class TsarBombaShooter : BaseTool
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

			ent.SetModel( "models/bombs/tsarbomba.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 2000;
		}
	}
}
