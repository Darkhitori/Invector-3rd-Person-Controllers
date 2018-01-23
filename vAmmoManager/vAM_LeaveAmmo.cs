using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vAmmoManager")]
	[Tooltip(" ")]
	public class vAM_LeaveAmmo : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vAmmoManager))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vItem))]
		public FsmObject item;
		
		public FsmInt amount;
		
		public FsmBool everyFrame;

		vAmmoManager theScript;
  
		public override void Reset()
		{
			gameObject = null;
			item = null;
			amount = null;
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
			var aItem = item.Value as vItem;
			if (aItem == null)
			{
				return;
			}
			
			theScript.LeaveAmmo(aItem, amount.Value);            
		}

	}
}