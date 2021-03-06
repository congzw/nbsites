﻿using System.Collections.Generic;
using System.Linq;

namespace NbSites.Common
{
    public class MessageResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static MessageResult Create(bool success, string message, object data = null)
        {
            return new MessageResult() { Success = success, Message = message, Data = data };
        }

        public static MessageResult MethodResult(string method, bool success, object data = null)
        {
            var result = new MessageResult();
            result.Success = success;
            result.Data = data;
            result.Message = string.Format("{0}: {1} => {2}", method, success ? " Success" : " Fail", data);
            return result;
        }

        public static MessageResult SuccessResult(string message, object data = null)
        {
            var result = new MessageResult() { Message = message, Success = true, Data = data };
            return result;
        }

        public static MessageResult FailResult(string message, object data = null)
        {
            var result = new MessageResult() { Message = message, Success = false, Data = data };
            return result;
        }
    }
    
    public static class BatchMessageResultExtensions
    {
        public static MessageResult ToBatchResults(this IEnumerable<MessageResult> messageResults)
        {
            var batchResult = new MessageResult();
            var results = messageResults.ToList();
            batchResult.Message = "Total: " + results.Count;
            batchResult.Success = results.All(x => x.Success);
            batchResult.Data = results;
            return batchResult;
        }
    }
}