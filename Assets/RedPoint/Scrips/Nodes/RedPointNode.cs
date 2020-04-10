using System;
using System.Collections.Generic;

namespace RedPoint.Scrips.Nodes
{
    /// <summary>
    /// 紅點提示節點。
    /// 主要功能是用來記錄當前節點的點數包函此節點以下的所有子節點
    /// </summary>
    public class RedPointNode
    {
        public event Action<Object> OnUpdate;
        
        public string Name { get; private set; }
        /// <summary>
        /// 此節點的紅點數量
        /// </summary>
        public int NumCount { get; set; }

        /// <summary>
        /// 子節點
        /// </summary>
        public readonly List<RedPointNode> Children = new List<RedPointNode>();

        public RedPointNode(string n)
        {
            Name = n;
        }
        
        public void AddChild(RedPointNode node)
        {
            Children.Add(node);
        }
        
        /// <summary>
        /// 依據子節點名稱進行查找子節點實體
        /// </summary>
        /// <param name="childName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public RedPointNode FindChildByName(string childName)
        {
            foreach (var child in Children)
            {
                if (child.Name.Equals(childName))
                {
                    return child;
                }
            }
            throw new ArgumentException("not found by node name:" + childName);
        }

        /// <summary>
        /// 此節點所有的紅點數量
        /// </summary>
        /// <returns></returns>
        public int TotalNumCount()
        {
            return NumCount + TotalNumCount(this);
        }

        /// <summary>
        /// 更新並通知
        /// </summary>
        /// <param name="dataObject"></param>
        public void Update(Object dataObject)
        {
            OnUpdate?.Invoke(dataObject);
        }

        /// <summary>
        /// 此節點以下是否還有節點
        /// </summary>
        /// <returns></returns>
        public bool HasChildren()
        {
            return Children.Count > 0;
        }
        
        /// <summary>
        /// 遞迴找出所有子物件的紅點數量
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int TotalNumCount(RedPointNode node)
        {
            if (node == null) return 0;
            if (node.Children.Count == 0) return 0;

            var total = 0;
            foreach (var child in node.Children)
            {
                total += child.NumCount + TotalNumCount(child);
            }
            return total;
        }
    }
}