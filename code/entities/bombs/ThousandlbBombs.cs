using Sandbox;

[Library("bombs_1000lbbomb", Title = "1000lb Bomb", Spawnable = true)]
public partial class TlbBomb : BombProp
{
    int takenDamage;

    public override void Spawn() 
    {
        base.Spawn();

        SetModel("models/bombs/thousandlbbomb.vmdl");

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