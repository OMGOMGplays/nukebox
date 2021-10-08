using Sandbox;

[Library("bombs_500lbbomb", Title = "500lb Bomb", Spawnable = true)]
public partial class FivehundredlbBomb : BombProp
{
    int takenDamage;

    public override void Spawn() 
    {
        base.Spawn();

        SetModel("models/bombs/fivehundredlbbomb.vmdl");

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
		if ( eventData.Speed >= 500.0f && takenDamage > 1 )
		{
			ExplodeAsync(0.25f);
		}
        
        else if (eventData.Speed >= 500.0f && takenDamage < 1) 
        {
            PlaySound("rmine_blip3");
            takenDamage++;
        }
	}

    public override void OnKilled() 
    {
        base.OnKilled();

        ExplodeAsync(0.25f);

        takenDamage = 0;
    }
}