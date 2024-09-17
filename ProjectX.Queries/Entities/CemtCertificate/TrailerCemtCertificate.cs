﻿using ProjectX.Queries.Entities.Common;

namespace ProjectX.Queries.Entities.CemtCertificate
{
    public class TrailerCemtCertificate : BaseEntity
    {
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired { get; set; }

        public int TrailerId { get; set; }

        public virtual Trailer.Trailer Trailer { get; set; } = null!;
    }
}