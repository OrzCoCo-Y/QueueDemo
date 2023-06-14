namespace QueueDemo.Model.Dto
{
    public class VerifyResponse
    {
        public VerifyResponse(string userIndex, bool verifyResult)
        {
            UserIndex = userIndex;
            VerifyResult = verifyResult;
        }

        public string UserIndex { get; set; }
        public bool VerifyResult { get; set; }
    }
}
