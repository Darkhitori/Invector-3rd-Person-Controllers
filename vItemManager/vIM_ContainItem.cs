using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip("Check if Item List contains a  Item ")]
	public class vIM_ContainItem : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		public enum ContainItem
		{
			id,
			itemName,
			id_amount,
			itemName_amount
		}
		
		public ContainItem methods;
		
		public FsmInt id;
		
		public FsmString itemName;
		
		public FsmInt amount;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool containItem;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			methods = ContainItem.id;
			id = null;
			itemName = "";
			amount = null;
			containItem = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vItemManager>();


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
			case ContainItem.id:
				containItem.Value = theScript.ContainItem(id.Value);
				break;
			case ContainItem.itemName:
				containItem.Value = theScript.ContainItem(itemName.Value);
				break;
			case ContainItem.id_amount:
				containItem.Value = theScript.ContainItem(id.Value, amount.Value);
				break;
			case ContainItem.itemName_amount:
				containItem.Value = theScript.ContainItem(itemName.Value, amount.Value);
				break;
			}
			
		}

	}
}