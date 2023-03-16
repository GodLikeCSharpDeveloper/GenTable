namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class Wrapper<T>
    {
        public T t;
        public string WrapperParameter1 { get; set; }
        public string WrapperParameter2 { get; set; }
        public bool OrderBool { get; set; }
        public Wrapper(T t)
        {
            this.t = t;
        }
    }
}
