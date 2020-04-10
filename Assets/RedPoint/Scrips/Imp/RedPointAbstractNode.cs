using System;
using System.Collections.Generic;
using RedPoint.Scrips.Nodes;
using UnityEngine;
using UnityEngine.Serialization;

namespace RedPoint.Scrips.Imp
{
    [RequireComponent(typeof(RedPointDisplayImp))]
    public abstract class RedPointAbstractNode : RedPointNodeBase
    {
        [FormerlySerializedAs("redPointDisplay")] [SerializeField] protected RedPointDisplayImp redPointDisplayImp;
        
        private readonly Dictionary<string, Action<object>> _listener = new Dictionary<string, Action<object>>();

        /// <summary>
        /// 監聽註冊
        /// </summary>
        /// <param name="e"></param>
        /// <param name="action"></param>
        protected void RegisterListener(Enum e, Action<object> action)
        {
            _listener.Add(e.ToString(), action);
        }
        
        protected override void DoDispatch(object dataObject)
        {
            _listener[NodeEnum.ToString()]?.Invoke(dataObject);
        }

        /// <summary>
        /// 設置紅點點數
        /// </summary>
        /// <param name="value"></param>
        protected void SetNumCount(int value)
        {
            if(!RedPointNode.HasChildren())
                RedPointNode.NumCount = value;
            var total = RedPointNode.TotalNumCount();
            redPointDisplayImp.SetNumCount(total.ToString());

            SetVisibleImage(total > 0);
        }

        /// <summary>
        /// 設置是否可以看到紅點提示圖片
        /// </summary>
        /// <param name="value"></param>
        private void SetVisibleImage(bool value)
        {
            redPointDisplayImp.SetVisibleImage(value);
        }
    }
}