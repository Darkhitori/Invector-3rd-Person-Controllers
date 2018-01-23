using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip("Check if the list contains a certain count of items, or more ")]
	public class vIM_ContainItems : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		public enum ContainItems
		{
			id_count,
			itemName_count
		}
		
		public ContainItems methods;
		
		public FsmInt id;
		
		public FsmString itemName;
		
		public FsmInt count;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool containItems;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			methods =  ContainItems.id_count;
			id = null;
			itemName = "";
			count = null;
			containItems = false;
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
			case ContainItems.id_count:
				containItems.Value = theScript.ContainItems(id.Value, count.Value);
				break;
			case ContainItems.itemName_count:
				containItems.Value = theScript.ContainItems(itemName.Value, count.Value);
				break;
			}
			
		}

	}
}