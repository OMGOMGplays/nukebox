namespace Sandbox.Tools
{
	[Library( "tool_tnt", Title = "TNT Shooter", Description = "Shoot TNT", Group = "fun" )]
	public class TNTShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootTNT();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
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
				Position = Owner.EyePos + Owner.EyeRot.Forward * 50,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/bombs/tnt.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 1000;
		}
	}
}
