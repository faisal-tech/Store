using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Dtos
{
    public class ApiResponseDto<T>
    {
        public int Code { get; set; }=(int)HttpStatusCode.OK;
        public T? Data { get; set; }
        public string Message { get; set; } = "Request Succeeded";


        public static ApiResponseDto<T> IsSuccess(T data)
        {
            return new ApiResponseDto<T>
            {
                Data = data,
            };
        }

        public static ApiResponseDto<T> IsError(string message)
        {
            return new ApiResponseDto<T>
            {

                Message = message,
                Code = (int)HttpStatusCode.InternalServerError,
            };

        }

    }
}
