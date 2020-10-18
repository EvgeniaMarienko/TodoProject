using System;

namespace TodoWeb.Models
{
    public class TodoResponseModel<T>
    {
        public DateTime Time { get; set; }
        public bool IsSuccessful { get; set; }
        public T Result { get; set; }

        public static TodoResponseModel<T> Ok(T response)
        {
            return new TodoResponseModel<T>
            {
                Time = DateTime.Now,
                IsSuccessful = true,
                Result = response
            };
        }

        public static TodoResponseModel<ErrorResponseModel> Fail(ErrorResponseModel responseModel)
        {
            return new TodoResponseModel<ErrorResponseModel>
            {
                Time = DateTime.Now,
                IsSuccessful = false,
                Result = responseModel
            };
        }
    }
}
