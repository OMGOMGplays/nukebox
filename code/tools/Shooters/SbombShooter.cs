namespace Sandbox.Tools
{
	[Library( "shooter_sbombshooter", Title = "S&bomb Shooter", Description = "KEYS FOR EVERYONE!!!", Group = "fun" )]
	public class SbombShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootSbomb();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
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
				Position = Owner.EyePos + Owner.EyeRot.Forward * 100,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/bombs/sbomb.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 2000;
		}
	}
}
