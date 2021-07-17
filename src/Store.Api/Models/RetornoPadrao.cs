﻿using System.Collections.Generic;

namespace Store.Api.Models
{
    public class RetornoPadrao<TData> where TData : new()
    {
        public bool Sucesso { get; set; }
        public IList<string> Mensagens { get; set; }
        public TData Data { get; set; }

        public RetornoPadrao()
        {
            this.Mensagens = new List<string>();
        }
    }
}
