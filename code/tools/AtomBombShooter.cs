namespace Sandbox.Tools
{
	[Library( "shooter_atombombshooter", Title = "Atom Bomb Shooter", Description = "Shoot Atom Bombs, because fuck you and everyone within a 1000 meter radius", Group = "fun" )]
	public class AtomBombShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootAtomBomb();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
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
				Position = Owner.EyePos + Owner.EyeRot.Forward * 100,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/bombs/atombomb.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 2000;
		}
	}
}
