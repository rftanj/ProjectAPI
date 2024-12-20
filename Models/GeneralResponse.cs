namespace ProjectAPI.Models
{
    public class GeneralResponse<T>
    {
        public GeneralResponse()
        {
            Data = new List<T>();
        }
        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public List<T> Data { get; set; }

    }
}
