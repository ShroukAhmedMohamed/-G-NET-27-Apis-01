using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.G02.Application.Common
{
 

public record Error(string Code, string Description, ErrorType ErrorType =ErrorType.Failure)
    {
public static Error Falier(string code = "General.Falier", string description = "General Falier has occurred") => new(code, description, ErrorType.Failure);
        public static Error Validation(string code = "General.Validation", string description = "General Validation error has occurred") => new(code, description, ErrorType.Validation);
        public static Error NotFound(string code = "General.NotFound ", string description = "General  NotFound error  has occurred") => new(code, description, ErrorType.NotFound);
        public static Error Confilct(string code = "General.Confilct ", string description = "General   Confilct error has occurred") => new(code, description, ErrorType.Confilct);
        public static Error Unauthorized(string code = "General.Unauthorized", string description = "General Unauthorized error has occurred") => new(code, description, ErrorType.Unauthorized);
        public static Error Forbidden(string code = "General.Forbidden", string description = "General Forbidden error has occurred") => new(code, description, ErrorType.Forbidden);
        public static Error InvalidCredentials(string code = "General.InvalidCredentials", string description = "General InvalidCredentials error has occurred") => new(code, description, ErrorType.InvalidCredentials);
    }

public enum ErrorType
{

    Failure = 8,

    Validation = 1,

    NotFound = 2,

    Confilct = 3,

    Unauthorized = 4,

    Forbidden = 5,

    InvalidCredentials = 6,
}















}


