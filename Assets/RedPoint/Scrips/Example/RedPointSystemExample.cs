using RedPoint.Scrips.Example.Models;
using RedPoint.Scrips.Nodes;

namespace RedPoint.Scrips.Example
{
    /// <summary>
    /// 指定 TreeMap 建立紅點樹結構
    /// </summary>
    public class RedPointSystemExample : RedPointSystemBase
    {
        private void Awake()
        {
            InitTree(RedPointTreeMapExample.Create(typeof(ERedPointMainNode)));
        }
    }
}