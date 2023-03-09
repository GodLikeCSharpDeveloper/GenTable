namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class Wrapper<T>
    {
        public T t;
        public bool OrderBool { get; set; }
        public Wrapper(T t)
        {
            this.t = t;
        }
    }
}
