﻿using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
