using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vAmmoManager")]
	[Tooltip(" ")]
	public class vAM_AddAmmo : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vAmmoManager))] 
		public FsmOwnerDefault gameObject;
		
		public enum AddAmmo
		{
			ammoName_id_amount,
			id_amount,
			item
		}
		
		public AddAmmo methods;
		
		public FsmString ammoName;
		
		public FsmInt id;
		
		public FsmInt amount;
		
		[ObjectType(typeof(vItem))]
		public FsmObject item;
		
		public FsmBool everyFrame;

		vAmmoManager theScript;
  
		public override void Reset()
		{
			gameObject = null;
			methods = AddAmmo.ammoName_id_amount;
			ammoName = "";
			id = null;
			amount = null;
			item = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vAmmoManager>();


			if (!everyFrame.Value)
			{
				DoTheMagic();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoTheMagic();
			}
		}

		void DoTheMagic()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			
			switch(methods)
			{
			case AddAmmo.ammoName_id_amount:
				theScript.AddAmmo(ammoName.Value, id.Value, amount.Value);
				break;
			case AddAmmo.id_amount:
				theScript.AddAmmo(id.Value, amount.Value);
				break;
			case AddAmmo.item:
				var aItem = item.Value as vItem;
				if (aItem == null)
				{
					return;
				}
				theScript.AddAmmo(aItem);
				break;
			}
			            
		}

	}
}