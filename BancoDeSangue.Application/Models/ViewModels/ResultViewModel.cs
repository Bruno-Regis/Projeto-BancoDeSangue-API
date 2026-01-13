using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.ViewModels
{
    public class ResultViewModel
    {
        public ResultViewModel(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static ResultViewModel Success()
        {
            return new ResultViewModel();
        }

        public static ResultViewModel Error(string message)
        {
            return new ResultViewModel(false, message);
        }
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, bool isSuccess = true, string message = "")
            : base(isSuccess, message)
        {
            Data = data;
        }
        public T? Data { get; set; }

        public static ResultViewModel<T> Success(T? data)
        {
            return new ResultViewModel<T>(data);
        }

        public static ResultViewModel<T> Error(string message)
        {
            return new ResultViewModel<T>(default, false, message);
        }
    }
}
