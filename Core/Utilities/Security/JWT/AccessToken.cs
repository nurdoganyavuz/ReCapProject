﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //Token
        public DateTime Expiration { get; set; } //Token'ın geçerlilik süresi
    }
}
