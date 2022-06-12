using Sandbox;
using Sandbox.Tools;

namespace Nukebox.tools.Shooters
{
	[Library( "shooter_thousandshooter", Title = "1000lb Shooter", Description = "Shoot 1000lb bombs at rapids amount of speeds.", Group = "fun" )]
	public class ThousandShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					ShootThousand();
				}

				if ( Input.Down( InputButton.SecondaryAttack ) && timeSinceShoot > 0.05f )
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
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 100,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( "models/bombs/thousandlbbomb.vmdl" );
			ent.Velocity = Owner.EyeRotation.Forward * 2000;
		}
	}
}
