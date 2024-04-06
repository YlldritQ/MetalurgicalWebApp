﻿using backend_dotnet7.Core.Dtos.General;
using backend_dotnet7.Core.Dtos.Message;
using System.Security.Claims;

namespace backend_dotnet7.Core.Interfaces
{
    public interface IMessageService
    {
        Task<GenerealServiceResponseDto> CreateNewMessageAsync(ClaimsPrincipal User, CreateMessageDto createMessageDto);
        Task<IEnumerable<GetMessageDto>> GetMessageAsync();
        Task<IEnumerable<GetMessageDto>> GetMyMessagesAsync(ClaimsPrincipal User);
    }
}
