using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip(" ")]
	public class vIM_CollectItem : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vTriggerGenericAction))]
		public FsmObject action;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			action = null;
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
			
			var vTAction = action.Value as vTriggerGenericAction;
			if (vTAction == null)
			{
				return;
			}
			
			theScript.CollectItem(vTAction);
			
		}

	}
}