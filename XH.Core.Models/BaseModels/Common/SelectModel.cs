namespace XH.Core.Models.BaseModels.Common
{
    public class SelectModel
    {
        /// <summary>
       /// 状态
       /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 页
        /// </summary>
        public PageModel pageModel { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public object  Content { get; set; }

    }
}
