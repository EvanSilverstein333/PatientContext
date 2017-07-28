﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherSubscriberService;
using ApplicationServices.CrossCuttingConcerns;

namespace Infrastructure.AbstractFactories
{
    public class ExternalMessagePublisher : IExternalMessagePublisher
    {
        private Publisher _publisher;

        public ExternalMessagePublisher(Publisher publisher)
        {
            _publisher = publisher;
            
        }

        public void Publish<TMessage>(TMessage message)
        {
            var messageWrapper = new MessageWrapper(message.GetType().ToString(), message);
            _publisher.Publish(messageWrapper);
        }
    }
}
