﻿namespace QueueDemo.Model.Dto
{
    public class DecryptRequest
    {
        public string UserIndex { get; set; } = "test";
        public string EncryptedPwd { get; set; }
        public string PrivateKey { get; set; }
    }
}
