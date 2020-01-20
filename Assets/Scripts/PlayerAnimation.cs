﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	public Animator PlayerBodyAnimator;
	public Animator PlayerEyeAnimator;
	public SpriteRenderer PlayerSpriteRenderer;
	public Rigidbody2D BodyRB;
	public Rigidbody2D GlassesRB;

	[Header("Layers")]
	public int DefaultLayer;
	public int PlayerLayer;
	public int GlassesLayer;

	private float health;

	private void Start()
	{
		health = 100f;
		PlayerSpriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		GlassesRB.isKinematic = true;
		BodyRB.velocity = new Vector2(Random.Range(-3f, 3f), Random.Range(1f, 3f));
		BodyRB.angularVelocity = Random.Range(-45f, 45f);
	}

	private void LoseGlasses()
	{
		if (GlassesRB.isKinematic)
		{
			GlassesRB.isKinematic = false;
			GlassesRB.velocity = new Vector2(Random.Range(-4f, 4f), Random.Range(5f, 7f));
			GlassesRB.angularVelocity = Random.Range(-65f, 65f);
			GlassesRB.transform.SetParent(null);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.layer == PlayerLayer)
		{
			health -= 25f;
			PlayerBodyAnimator.SetTrigger("Hit");
			PlayerEyeAnimator.SetTrigger("Hit");
			if(health <= 0f)
			{
				LoseGlasses();
			}
		}
	}
}
