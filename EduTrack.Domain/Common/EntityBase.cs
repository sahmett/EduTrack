﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Common
{
    public abstract class EntityBase<TKey> : ICreatedByEntity, IModifiedByEntity, IDeletedByEntity
    {
        public TKey Id { get; set; }

        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public string? ModifiedByUserId { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedByUserId { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }

        public bool Equals(TKey? other)
        {
            throw new NotImplementedException();
        }
    }
}