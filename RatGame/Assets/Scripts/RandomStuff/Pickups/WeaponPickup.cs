using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponPickup : Interactable {

	public Weapon wep;
	public Animator scrollAnimator;
	public WeaponPickup yellow;
	public WeaponPickup purple;
	public WeaponPickup green;
	public WeaponPickup orange;
	public WeaponPickup thunder;
	public Crosshair cross;
	private GameObject p;
	private WeaponPickup inst; 

	void Start() {
		p = GameObject.FindWithTag("Entity");
		cross = p.GetComponent<Player>().crosshair;
	}

	new void Update () {
		if (!wasInside && isInside) {
			if (!scrollAnimator.GetCurrentAnimatorStateInfo (0).IsName ("ScrollAppear")) {
				scrollAnimator.Play ("ScrollAppear");
			}
		} else if (wasInside && !isInside) {
			if (!scrollAnimator.GetCurrentAnimatorStateInfo (0).IsName ("ScrollDisappear")) {
				scrollAnimator.Play ("ScrollDisappear");
			}
		}

		base.Update ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		OnTriggerEnter2DFunc (col);
	}

	void OnTriggerStay2D(Collider2D col) {
		OnTriggerStay2DFunc (col);
	}

	void OnTriggerExit2D(Collider2D col) {
		OnTriggerExit2DFunc (col);
	}

	protected override void OnPlayerTrigger (Player player)
	{
		base.OnPlayerTrigger (player);
		//WeaponPickup newPick = Instantiate(pickup, new Vector2(player.transform.position.x, player.transform.position.y), transform.rotation) as WeaponPickup;
		//newPick.sprite.GetComponent<SpriteRenderer>().sprite = player.weapon.spriteRenderer.GetComponent<SpriteRenderer>().sprite;
		//Weapon pWep = Instantiate(player.weapon, new Vector2(player.transform.position.x, player.transform.position.y), transform.rotation) as Weapon;
		//pWep.enabled = false;
		//newPick.wep = pWep;
		
		cross.nameCross = wep.gunName;

		if (player.weapon != null){
			string name = player.weapon.gunName;

			if(name == wep.gunName){
				Pickable = true;
				return;
			}
			
			if (name == "YellowGun") {
				inst  = Instantiate(yellow, new Vector2(player.transform.position.x, player.transform.position.y), transform.rotation);
			} else if (name == "PurpleGun") {
				inst  = Instantiate(purple, new Vector2(player.transform.position.x, player.transform.position.y), transform.rotation);
			} else if (name == "OrangeGun") {
				inst  = Instantiate(orange, new Vector2(player.transform.position.x, player.transform.position.y), transform.rotation);
			} else if (name == "GreenGun") {
				inst  = Instantiate(green, new Vector2(player.transform.position.x, player.transform.position.y), transform.rotation);
			} else if (name == "ThunderGun") {
				inst  = Instantiate(thunder, new Vector2(player.transform.position.x, player.transform.position.y), transform.rotation);
			}

			inst.cross = player.crosshair;
		}

		player.EquipWeapon (wep);
		Destroy (gameObject);
	} 
}
