﻿using System;
using WcfDemo.Contracts;

namespace WcfDemo
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRequestRepository _messageRequestRepository;
        private readonly IMessageResponseRepository _messageResponseRepository;
        private readonly IContactRepository _contactRepository;

        public MessageService(
            IMessageRequestRepository messageRequestRepository,
            IMessageResponseRepository messageResponseRepository,
            IContactRepository contactRepository)
        {
            _messageRequestRepository = messageRequestRepository;
            _messageResponseRepository = messageResponseRepository;
            _contactRepository = contactRepository;
        }

        public MessageResponse Send(MessageRequest message)
        {
            var messageResponse = ValidationHelper.ValidateMessage(message);
            if (messageResponse.ReturnCode != ReturnCode.Success)
            {
                return messageResponse;
            }

            try
            {
                var response = SmtpClientHelper.SendMessage(message);
                messageResponse = response;

            }
            catch (Exception e)
            {
                return new MessageResponse
                {
                    ReturnCode = ReturnCode.InternalError,
                    ErrorMessage = $"Wystąpił błąd związany z dostarczeniem wiadomości e-mail{Environment.NewLine}{e}"
                };
            }

            return messageResponse;
        }
    }
}
