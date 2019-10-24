namespace OnlineRetailPortal.Contracts
{
   public class GetProductsServiceRequest
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

    }

}