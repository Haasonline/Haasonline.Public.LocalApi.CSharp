using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects
{
    public class HaasonlineClientResponse<T>
    {
        public EnumErrorCode ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public T Result { get; set; }
    }
}