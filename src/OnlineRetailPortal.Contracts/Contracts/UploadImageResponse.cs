namespace OnlineRetailPortal.Contracts.Contracts
{
    public class UploadImageResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public IImageWriterResponse[] info;
        public UploadImageResponse()
        {
            info = new IImageWriterResponse[1];
        }

    }
}
