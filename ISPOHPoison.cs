using System;
using Sonigon;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public class ISPOHPoison : RayHitEffect
{
	// Token: 0x060003E7 RID: 999 RVA: 0x00017E5B File Offset: 0x0001605B
	private void Start()
	{
		base.GetComponentInParent<ProjectileHit>().bulletCanDealDeamage = false;
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x00017E6C File Offset: 0x0001606C
	public override HasToReturn DoHitEffect(HitInfo hit)
	{
		if (!hit.transform)
		{
			return HasToReturn.canContinue;
		}
		ISPOHPoison[] componentsInChildren = base.transform.root.GetComponentsInChildren<ISPOHPoison>();
		ProjectileHit componentInParent = base.GetComponentInParent<ProjectileHit>();
		DamageOverTime component = hit.transform.GetComponent<DamageOverTime>();
		if (component)
		{
			component.TakeDamageOverTime(componentInParent.damage * base.transform.forward / (float)componentsInChildren.Length, base.transform.position, this.time, this.interval, this.color, this.soundEventDamageOverTime, base.GetComponentInParent<ProjectileHit>().ownWeapon, base.GetComponentInParent<ProjectileHit>().ownPlayer, true);
		}
		return HasToReturn.canContinue;
	}

	// Token: 0x04000554 RID: 1364
	[Header("Sounds")]
	public SoundEvent soundEventDamageOverTime;

	// Token: 0x04000555 RID: 1365
	[Header("Settings")]
	public float time = 0.01f;

	// Token: 0x04000556 RID: 1366
	public float interval = 0.01f;

	// Token: 0x04000557 RID: 1367
	public Color color = Color.white;
}
