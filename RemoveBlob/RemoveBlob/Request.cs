﻿namespace RemoveBlob
{
    public class Request
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Bucket { get; set; }
        public string Key { get; set; }
    }
}
