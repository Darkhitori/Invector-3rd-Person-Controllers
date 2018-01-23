using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip("Get item of the equipPoint ")]
	public class vIM_GetItemInEquipPoint : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString equipPointName;
		
		[ActionSection("Return")]
		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(vItem))]
		public FsmObject getItem;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			equipPointName = "";
			getItem = null;
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
			
			getItem.Value = theScript.GetItemInEquipPoint(equipPointName.Value);
				
		}

	}
}