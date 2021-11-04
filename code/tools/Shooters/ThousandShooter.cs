namespace Sandbox.Tools
{
	[Library( "shooter_thousandshooter", Title = "1000lb Shooter", Description = "Shoot 1000lb bombs at rapids amount of speeds.", Group = "fun" )]
	public class ThousandShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootThousand();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootThousand();
				}
			}
		}

		void ShootThousand()
		{
			var ent = new Prop
			{
				Position = Owner.EyePos + Owner.EyeRot.Forward * 100,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/bombs/thousandlbbomb.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 2000;
		}
	}
}
