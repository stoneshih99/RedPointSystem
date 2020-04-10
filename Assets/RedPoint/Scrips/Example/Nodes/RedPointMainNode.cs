using RedPoint.Scrips.Example.Models;
using RedPoint.Scrips.Imp;
using UnityEngine;

namespace RedPoint.Scrips.Example.Nodes
{
    [RequireComponent(typeof(RedPointDisplayImp))]
    public class RedPointMainNode : RedPointAbstractNode
    {
#pragma warning disable
        [SerializeField] private ERedPointMainNode eNode;
#pragma warning restore
        protected override void DoStart()
        {
        }

        protected override void DoAwake()
        {
            SetNodeName(eNode);
        }

        /// <summary>
        /// 根節點
        /// </summary>
        /// <param name="dataObject"></param>
        protected override void DoDispatch(object dataObject)
        {
            SetNumCount(0);
        }
    }
}