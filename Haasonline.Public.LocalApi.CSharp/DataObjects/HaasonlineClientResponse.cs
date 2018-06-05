namespace Haasonline.Public.LocalApi.CSharp.DataObjects
{
    public class HaasonlineClientResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}