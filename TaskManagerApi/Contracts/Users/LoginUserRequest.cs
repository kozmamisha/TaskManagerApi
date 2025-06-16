﻿using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Contracts.Users
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required] string Password);
}
