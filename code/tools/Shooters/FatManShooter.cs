namespace Sandbox.Tools
{
	[Library( "shooter_fatmanshooter", Title = "Fat Man Shooter", Description = "Shoot Fat Mans (Americans)", Group = "fun" )]
	public class FatManShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootFatMan();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootFatMan();
				}
			}
		}

		void ShootFatMan()
		{
			var ent = new Prop
			{
				Position = Owner.EyePos + Owner.EyeRot.Forward * 100,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/bombs/fatman.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 2000;
		}
	}
}
