using System;
using RedPoint.Scrips.Nodes;

namespace RedPoint.Scrips
{
    public class RedPointSystem
    {
        /// <summary>
        /// RedPointSystem GameObject TAG 名稱
        /// 主要是為了在 runtime 提升查找速度
        /// </summary>
        public const string GameTag = "RedPointSystemImp";
        /// <summary>
        /// 主節點名稱
        /// </summary>
        private const string RootName = "Root";
        private RedPointNode _root;
        public RedPointNode Root => _root;

        /// <summary>
        /// 依據 TreeMap 裡面所建立的關聯進行子父節點的建立
        /// </summary>
        /// <param name="treeMap"></param>
        public RedPointSystem(IRedPointTreeMap treeMap)
        {
            CreateTreeMap(treeMap);
        }

        /// <summary>
        /// 依據 Enum 的定義建立出對應的節點
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="childrenNode"></param>
        public void CreateNode(Enum parentNode, Type childrenNode)
        {
            // parentNode.ToString()
            var n = parentNode.GetType().Name + parentNode;
            CreateNode(n, childrenNode);
        }
        
        /// <summary>
        /// 依據 enum 遍尋出指定的節點
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public RedPointNode Find(Enum e)
        {
            // var n = e.ToString();
            var n = e.GetType().Name + e;
            var node = Find(_root, n);
            return node;
        }
        
        /// <summary>
        /// 依據 RedPointTreeMap 建立關聯節點
        /// </summary>
        /// <param name="treeMap"></param>
        private void CreateTreeMap(IRedPointTreeMap treeMap)
        {
            _root = new RedPointNode(RootName);
            foreach (var e in Enum.GetValues(treeMap.Nodes))
            {
                
                // var n = e.ToString();
                var n = e.GetType().Name + e;
                var node = new RedPointNode(n);
                _root.Children.Add(node);
            }
            foreach (var parent in treeMap.Tree.Keys)
            {
                var children = treeMap.Tree[parent];
                CreateNode(parent, children);
            }
        }
        
        /// <summary>
        /// 依據指定的節點名稱建立出對應的節點樹
        /// </summary>
        /// <param name="parentNodeName"></param>
        /// <param name="children"></param>
        private void CreateNode(string parentNodeName, Type children)
        {
            var parentNode = Find(parentNodeName);
            foreach (var obj in Enum.GetValues(children))
            {
                // var n = obj.ToString();
                var n = obj.GetType().Name + obj;
                var node = new RedPointNode(n);
                parentNode.AddChild(node);
            }
        }
        
        /// <summary>
        /// 依據節點名稱遍尋出指定的節點
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private RedPointNode Find(string n)
        {
            var node = Find(_root, n);
            return node;
        }

       
        
        /// <summary>
        /// 依據節點名稱遍尋出指定的節點
        /// </summary>
        /// <param name="node"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private RedPointNode Find(RedPointNode node, string n)
        {
            if (node == null) return null;

            foreach (var child in node.Children)
            {
                RedPointNode targetNode = null;
                if (child.Name.Equals(n))
                {
                    targetNode = child;
                    return targetNode;
                }
                targetNode = Find(child, n);
                if (targetNode != null)
                    return targetNode;
            }
            return null;
        }
    }
}