using Sandbox;
using Sandbox.Tools;

namespace Nukebox.tools.Shooters
{
	[Library( "shooter_atombombshooter", Title = "Atom Bomb Shooter", Description = "Shoot Atom Bombs, because fuck you and everyone within a 1000 meter radius", Group = "fun" )]
	public class AtomBombShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					ShootAtomBomb();
				}

				if ( Input.Down( InputButton.SecondaryAttack ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootAtomBomb();
				}
			}
		}

		void ShootAtomBomb()
		{
			var ent = new Prop
			{
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 100,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( "models/bombs/atombomb.vmdl" );
			ent.Velocity = Owner.EyeRotation.Forward * 2000;
		}
	}
}
