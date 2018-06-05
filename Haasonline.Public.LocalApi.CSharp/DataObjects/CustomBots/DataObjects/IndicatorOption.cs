using System.Collections.Generic;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class IndicatorOption
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public List<object> Options { get; set; }
    }
}