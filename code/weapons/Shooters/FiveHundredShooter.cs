using Sandbox;
using Sandbox.Tools;

namespace Nukebox.tools.Shooters
{
	[Library( "shooter_fivehundredshooter", Title = "500lb Shooter", Description = "Shoot 500lb bombs at rapids amount of speeds.", Group = "fun" )]
	public class FiveHundredShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack) )
				{
					ShootFiveHundred();
				}

				if ( Input.Down( InputButton.SecondaryAttack ) && timeSinceShoot > 0.05f )
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
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 100,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( "models/bombs/fivehundredlbbomb.vmdl" );
			ent.Velocity = Owner.EyeRotation.Forward * 2000;
		}
	}
}
