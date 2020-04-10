using System;
using UnityEngine;

namespace RedPoint.Scrips.Nodes
{
    /// <summary>
    /// 紅點提示的基礎類別
    /// 主要是包涵: RedPointSystemBase 與 RedPointNode reference
    /// </summary>
    public abstract class RedPointNodeBase : MonoBehaviour
    {
        /// <summary>
        /// 紅點系統
        /// </summary>
        private RedPointSystemBase _redPointSystem;
        /// <summary>
        /// 紅點提示節點
        /// </summary>
        protected RedPointNode RedPointNode;
        /// <summary>
        /// 節點名稱
        /// </summary>
        protected Enum NodeEnum;
        
        /// <summary>
        /// 設置節點名稱
        /// </summary>
        /// <param name="e"></param>
        protected void SetNodeName(Enum e)
        {
            NodeEnum = e;
        }
        protected abstract void DoStart();
        protected abstract void DoAwake();
        protected abstract void DoDispatch(object dataObject);

        private void OnDestroy()
        {
            if (RedPointNode != null)
                RedPointNode.OnUpdate -= OnUpdate;
        }

        private void Awake()
        {
            DoAwake();
        }

        private void Start()
        {
            ConnectNode();
            DoStart();
        }

        /// <summary>
        /// 與節點進行連線
        /// </summary>
        private void ConnectNode()
        {
            _redPointSystem = GameObject.FindWithTag(RedPointSystem.GameTag).GetComponent<RedPointSystemBase>();
            var currentNodeEnum = NodeEnum;
            RedPointNode = _redPointSystem.Find(currentNodeEnum);
            RedPointNode.OnUpdate += OnUpdate;
        }

        /// <summary>
        /// 節點更新
        /// </summary>
        /// <param name="dataObject"></param>
        private void OnUpdate(object dataObject)
        {
            if (RedPointNode == null) return;
            DoDispatch(dataObject);
        }
    }
}