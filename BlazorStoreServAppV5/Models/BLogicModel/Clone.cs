namespace BlazorStoreServAppV5.Models.BLogicModel
{
    public class Clone
    {
        public ProductModel prods;
        public Clone(ProductModel prods)
        {
            this.prods = prods;
        }

        public ProductModel getProds()
        {
            return prods;
        }
    }
}
