namespace QueueDemo.Model.Dto
{
    public class SignResponse
    {
        public SignResponse(string userIndex, string signText)
        {
            UserIndex = userIndex;
            SignText = signText;
        }
        public string UserIndex { get; set; }
        public string SignText { get; set; }
    }
}
