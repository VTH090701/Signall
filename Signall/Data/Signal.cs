namespace Signall.Data
{

    public class Signal
     {
         public string code { get; set; }
         public string display { get; set; }
     }
    
    public class ApiResult<T>
    {
        public string code { get; set; }
        public string type { get; set; }
        public string hints { get; set; }
        public List<T> value { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }

    public class Response
    {
        public string code { get; set; }
        public string type { get; set; }
        public string hints { get; set; }
        public string value { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }

    public class AllorListSignal
    {

        public string id { get; set; }
        public string seq { get; set; }
        public string code { get; set; }
        public string note { get; set; }
        public string unit { get; set; }
        public string status { get; set; }
        public string display { get; set; }
        public DateTime authored { get; set; }
        public string location { get; set; }
        public string performer { get; set; }
        public string requester { get; set; }
        public string unit_root { get; set; }
        public string organization { get; set; }
        public string value_string { get; set; }
    }

    

    
}

