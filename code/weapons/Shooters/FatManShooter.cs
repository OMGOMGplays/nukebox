using Sandbox;

namespace Nukebox.weapons.Shooters
{
	[Library( "shooter_fatmanshooter", Title = "Fat Man Shooter", Description = "Shoot Fat Mans (Americans)", Group = "fun" )]
	public class FatManShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					ShootFatMan();
				}

				if ( Input.Down( InputButton.SecondaryAttack ) && timeSinceShoot > 0.05f )
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
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 100,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( "models/bombs/fatman.vmdl" );
			ent.Velocity = Owner.EyeRotation.Forward * 2000;
		}
	}
}
