using Sandbox;
using BombProp = Nukebox.bombs.@base.BombProp;

namespace Nukebox.bombs;

[Spawnable]
[Library("bombs_fatman", Title = "Fat Man")]
public partial class FatMan : BombProp, IUse
{
	int takenDamage;

	public override void Spawn() 
	{
		base.Spawn();

		SetModel( "models/bombs/fatman.vmdl" );

		takenDamage = 0;
	}

	public override void TakeDamage(DamageInfo info) 
	{
		takenDamage++;

		if (takenDamage == 1)
		{
			PlaySound("rmine_blip3");
		}
		else if (takenDamage > 1)
		{
			ExplodeAsync(0.25f);
		}
	}

	public bool IsUsable( Entity user )
	{
		return true;
	}

	public bool OnUse(Entity user) 
	{
		if (user is Player player && takenDamage < 1)
		{
			takenDamage++;
			PlaySound( "rmine_blip3" );
		}
		return false;
	}

	protected override void OnPhysicsCollision( CollisionEventData eventData )
	{
		if (eventData.Speed >= 500.0f && takenDamage < 1) 
		{
			PlaySound("rmine_blip3");
			takenDamage++;
		}

		else if ( eventData.Speed >= 500.0f && takenDamage >= 1)
		{
			ExplodeAsync(0.25f);
		}
	}

	public override void OnKilled() 
	{
		base.OnKilled();

		ExplodeAsync(0.25f);

		takenDamage = 0;
	}
}
