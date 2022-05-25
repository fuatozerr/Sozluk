﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Common
{
    public class SozlukConstants
    {
        public const string RabbitMQHost = "localhost";
        public const string DefaultExchangeType = "direct";

        public const string UserExchangeName = "UserExchange";
        public const string UserEmailChangedQueueName = "UserEmailChangedQueue";

        public const string FavExchangeName = "FavExchangeName";
        public const string CreateEntryFavQueueName = "CreateEntryFavQueueName";
        public const string CreateEntryCommentFavQueueName = "CreateEntryCommentFavQueue";
    }
}
