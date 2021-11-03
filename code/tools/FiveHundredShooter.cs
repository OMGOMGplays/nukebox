namespace Sandbox.Tools
{
	[Library( "shooter_fivehundredshooter", Title = "500lb Shooter", Description = "Shoot 500lb bombs at rapids amount of speeds.", Group = "fun" )]
	public class FiveHundredShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootFiveHundred();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootFiveHundred();
				}
			}
		}

		void ShootFiveHundred()
		{
			var ent = new Prop
			{
				Position = Owner.EyePos + Owner.EyeRot.Forward * 100,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/bombs/fivehundredlbbomb.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 2000;
		}
	}
}
