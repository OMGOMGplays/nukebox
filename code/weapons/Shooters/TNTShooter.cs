using Sandbox;

namespace Nukebox.weapons.Shooters
{
	[Library( "tool_tnt", Title = "TNT Shooter", Description = "Shoot TNT", Group = "fun" )]
	public class TNTShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					ShootTNT();
				}

				if ( Input.Down( InputButton.SecondaryAttack ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootTNT();
				}
			}
		}

		void ShootTNT()
		{
			var ent = new Prop
			{
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 50,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( "models/bombs/tnt.vmdl" );
			ent.Velocity = Owner.EyeRotation.Forward * 1000;
		}
	}
}
