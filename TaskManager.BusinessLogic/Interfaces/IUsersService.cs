﻿namespace TaskManager.BusinessLogic.Interfaces
{
    public interface IUsersService
    {
        Task<string> Login(string email, string password);
        Task Register(string userName, string email, string password);
    }
}